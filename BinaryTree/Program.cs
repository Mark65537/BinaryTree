using System;
using Tree;

namespace BinaryTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(10);
            //заполнение дерева
             tree.add(9);
             tree.add(11);
             tree.add(12);
             tree.add(13);
             tree.add(14);
             tree.add(5);
             tree.add(6);
             tree.add(7);
             tree.add(4);
            //конец заполнения дерева
            Console.WriteLine("WalkInDepth: "+tree.WalkInDepth());
            Console.WriteLine("WalkInBreadth: " + tree.WalkInBreadth());
            Console.WriteLine("нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }
    }
}
