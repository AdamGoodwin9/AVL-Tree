using System;

namespace AVLBST
{
    class Program
    {

        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();

            for (int i = 9; i >= 1; i--)
            {
                tree.Insert(i);
            }
            
            tree.Delete(8);
            tree.Delete(7);

            tree.Insert(10);
            tree.Insert(11);

            

            Console.ReadKey();
        }
    }
}