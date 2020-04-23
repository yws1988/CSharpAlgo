namespace Math
{
    using System.Collections.Generic;

    public sealed class HungarianMatching
    {
        private static int[,] _costMatrix;
        private static int _inf;
        private static int _n; //number of elements
        private static int[] _lx; //labels for workers
        private static int[] _ly; //labels for jobs 
        private static bool[] _s;
        private static bool[] _t;
        private static int[] _matchX; //vertex matched with x
        private static int[] _matchY; //vertex matched with y
        private static int _maxMatch;
        private static int[] _slack;
        private static int[] _slackx;
        private static int[] _prev; //memorizing paths

        public static int[] GetAssignmentsWithMinimunCost(int[,] costMatrix)
        {
            _costMatrix = costMatrix;
            _n = _costMatrix.GetLength(0);

            _lx = new int[_n];
            _ly = new int[_n];
            _s = new bool[_n];
            _t = new bool[_n];
            _matchX = new int[_n];
            _matchY = new int[_n];
            _slack = new int[_n];
            _slackx = new int[_n];
            _prev = new int[_n];
            _inf = int.MaxValue;

            InitMatches();

            InitLowerValuesForRowsAndColumns();

            _maxMatch = 0;

            InitialMatching();

            var q = new Queue<int>();

            #region augment

            while (_maxMatch != _n)
            {
                q.Clear();
                InitSt();

                //parameters for keeping the position of root node and two other nodes
                var root = 0;
                int x;
                var y = 0;

                //find root of the tree
                for (x = 0; x < _n; x++)
                {
                    if (_matchX[x] != -1) continue;
                    q.Enqueue(x);
                    root = x;
                    _prev[x] = -2;

                    _s[x] = true;
                    break;
                }

                //init slack
                for (var i = 0; i < _n; i++)
                {
                    _slack[i] = _costMatrix[root, i] - _lx[root] - _ly[i];
                    _slackx[i] = root;
                }

                //finding augmenting path
                while (true)
                {
                    while (q.Count != 0)
                    {
                        x = q.Dequeue();
                        var lxx = _lx[x];
                        for (y = 0; y < _n; y++)
                        {
                            if (_costMatrix[x, y] != lxx + _ly[y] || _t[y]) continue;
                            if (_matchY[y] == -1) break; //augmenting path found!
                            _t[y] = true;
                            q.Enqueue(_matchY[y]);

                            AddToTree(_matchY[y], x);
                        }
                        if (y < _n) break; //augmenting path found!
                    }
                    if (y < _n) break; //augmenting path found!
                    UpdateLabels(); //augmenting path not found, update labels

                    for (y = 0; y < _n; y++)
                    {
                        //in this cycle we add edges that were added to the equality graph as a
                        //result of improving the labeling, we add edge (slackx[y], y) to the tree if
                        //and only if !T[y] &&  slack[y] == 0, also with this edge we add another one
                        //(y, yx[y]) or augment the matching, if y was exposed

                        if (_t[y] || _slack[y] != 0) continue;
                        if (_matchY[y] == -1) //found exposed vertex-augmenting path exists
                        {
                            x = _slackx[y];
                            break;
                        }
                        _t[y] = true;
                        if (_s[_matchY[y]]) continue;
                        q.Enqueue(_matchY[y]);
                        AddToTree(_matchY[y], _slackx[y]);
                    }
                    if (y < _n) break;
                }

                _maxMatch++;

                //inverse edges along the augmenting path
                int ty;
                for (int cx = x, cy = y; cx != -2; cx = _prev[cx], cy = ty)
                {
                    ty = _matchX[cx];
                    _matchY[cy] = cx;
                    _matchX[cx] = cy;
                }
            }

            #endregion

            return _matchX;
        }

        private static void InitMatches()
        {
            for (var i = 0; i < _n; i++)
            {
                _matchX[i] = -1;
                _matchY[i] = -1;
            }
        }

        private static void InitLowerValuesForRowsAndColumns()
        {
            for (var i = 0; i < _n; i++)
            {
                var minRow = _costMatrix[i, 0];
                for (var j = 0; j < _n; j++)
                {
                    if (_costMatrix[i, j] < minRow) minRow = _costMatrix[i, j];
                    if (minRow == 0) break;
                }
                _lx[i] = minRow;
            }
            for (var j = 0; j < _n; j++)
            {
                var minColumn = _costMatrix[0, j] - _lx[0];
                for (var i = 0; i < _n; i++)
                {
                    if (_costMatrix[i, j] - _lx[i] < minColumn) minColumn = _costMatrix[i, j] - _lx[i];
                    if (minColumn == 0) break;
                }
                _ly[j] = minColumn;
            }
        }

        private static void InitialMatching()
        {
            for (var x = 0; x < _n; x++)
            {
                for (var y = 0; y < _n; y++)
                {
                    if (_costMatrix[x, y] != _lx[x] + _ly[y] || _matchY[y] != -1) continue;
                    _matchX[x] = y;
                    _matchY[y] = x;
                    _maxMatch++;
                    break;
                }
            }
        }

        private static void InitSt()
        {
            for (var i = 0; i < _n; i++)
            {
                _s[i] = false;
                _t[i] = false;
            }
        }



        private static void UpdateLabels()
        {
            var delta = _inf;
            for (var i = 0; i < _n; i++)
                if (!_t[i])
                    if (delta > _slack[i])
                        delta = _slack[i];
            for (var i = 0; i < _n; i++)
            {
                if (_s[i])
                    _lx[i] = _lx[i] + delta;
                if (_t[i])
                    _ly[i] = _ly[i] - delta;
                else _slack[i] = _slack[i] - delta;
            }
        }

        //x-current vertex, prevx-vertex from x before x in the alternating path,
        //so we are adding edges (prevx, matchX[x]), (matchX[x],x)

        private static void AddToTree(int x, int prevx)
        {
            _s[x] = true; //adding x to S
            _prev[x] = prevx;

            var lxx = _lx[x];

            //updateing slack
            for (var y = 0; y < _n; y++)
            {
                if (_costMatrix[x, y] - lxx - _ly[y] >= _slack[y]) continue;
                _slack[y] = _costMatrix[x, y] - lxx - _ly[y];
                _slackx[y] = x;
            }
        }
    }
}
