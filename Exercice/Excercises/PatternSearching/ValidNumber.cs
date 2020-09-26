/// <summary>
/// Is the string be able to converted into a scentifique number
/// for example "2e1.2" is a scentifique number
/// </summary>
/// <param name="s"></param>
/// <returns></returns>

namespace CSharpAlgo.Excercise.Excercises.PatternSearching
{
    public class ValidNumber
    {
        public static bool IsNumber(string s)
        {
            s = s.Trim();
            var eI = s.Split('e');
            if (s.IndexOf(' ') != -1) return false;
            if (eI.Length > 2) return false;
            if (eI.Length == 1)
            {
                return double.TryParse(s, out double r);
            }
            if (eI.Length == 2)
            {
                return double.TryParse(eI[0], out double r1) && double.TryParse(eI[1], out double r2) && eI[1].IndexOf('.')==-1;
            }

            return false;
        }
    }
}
