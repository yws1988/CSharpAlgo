using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgo.Graph.Tree
{
    public class AVLTree
    {

        public Node Root;

        // A utility function to get 
        // the height of the tree  
        int height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }

        // A utility function to get 
        // maximum of two integers  
        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // A utility function to right  
        // rotate subtree rooted with y  
        // See the diagram given above.  
        Node RightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation  
            x.right = y;
            y.left = T2;

            // Update heights  
            y.height = max(height(y.left), height(y.right)) + 1;
            x.height = max(height(x.left), height(x.right)) + 1;

            // Return new root  
            return x;
        }

        // A utility function to left 
        // rotate subtree rooted with x  
        // See the diagram given above.  
        Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation  
            y.left = x;
            x.right = T2;

            // Update heights  
            x.height = max(height(x.left),
                        height(x.right)) + 1;
            y.height = max(height(y.left),
                        height(y.right)) + 1;

            // Return new root  
            return y;
        }

        // Get Balance factor of node N  
        int GetBalance(Node N)
        {
            if (N == null)
                return 0;

            return height(N.left) - height(N.right);
        }

        public Node Insert(Node node, int key)
        {

            /* 1. Perform the normal BST insertion */
            if (node == null)
                return (new Node(key));

            if (key < node.key)
                node.left = Insert(node.left, key);
            else if (key > node.key)
                node.right = Insert(node.right, key);
            else // Duplicate keys not allowed  
                return node;

            /* 2. Update height of this ancestor node */
            node.height = 1 + max(height(node.left),
                                height(node.right));

            /* 3. Get the balance factor of this ancestor  
                node to check whether this node became  
                unbalanced */
            int balance = GetBalance(node);

            // If this node becomes unbalanced, then there  
            // are 4 cases Left Left Case  
            if (balance > 1 && key < node.left.key)
                return RightRotate(node);

            // Right Right Case  
            if (balance < -1 && key > node.right.key)
                return LeftRotate(node);

            // Left Right Case  
            if (balance > 1 && key > node.left.key)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            // Right Left Case  
            if (balance < -1 && key < node.right.key)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }

        public void Print(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                Print(node.left);
                Print(node.right);
            }
        }

        public class Node
        {
            public int key, height;
            public Node left, right;

            public Node(int d)
            {
                key = d;
                height = 1;
            }
        }
    }
}
