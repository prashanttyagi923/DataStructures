using System;
using DS;

namespace codejam2k18
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // int testCaseCount = Int32.Parse(Console.ReadLine());
            // string[] limits;
            // int upperLimit; int lowerLimit; int guessCount; string response;
            // int guessNumber;
            // for (int i = 0; i < testCaseCount; i++)
            // {
            //     limits = Console.ReadLine().ToString().Split(new char[] { ' ' });
            //     upperLimit = Int32.Parse(limits[1]);
            //     lowerLimit = Int32.Parse(limits[0]);
            //     guessCount = Int32.Parse(Console.ReadLine());
            //     for (int j = 0; j < guessCount; j++)
            //     {
            //         guessNumber = (int)Math.Floor((double)(upperLimit + lowerLimit) / 2);
            //         Console.WriteLine(guessNumber);
            //         response = Console.ReadLine();
            //         if (response == "CORRECT")
            //         {
            //             break;
            //         }
            //         else if (response == "TOO_BIG")
            //         {
            //             upperLimit = guessNumber - 1;
            //         }
            //         else if (response == "TOO_SMALL")
            //         {
            //             lowerLimit = guessNumber + 1;
            //         }
            //         else if (response == "WRONG_ANSWER")
            //         {
            //             break;
            //         }
            //     }
            // }


            Tree tree = new Tree();
            tree.Root = tree.Insert(tree.Root, 10);
            tree.Insert(tree.Root, 15);
            tree.Insert(tree.Root, 12);

            // tree.Insert(tree.Root, 7);
            
            // tree.Insert(tree.Root, 6);
            // tree.Insert(tree.Root, 50);
            // tree.Insert(tree.Root, 30);
            // tree.Root = new Node(10);
            // tree.Root.Left = new Node(5);
            // tree.Root.Right = new Node(50);
            // tree.Root.Left.Right = new Node(7);
            // tree.Root.Right.Left = new Node(30);

            var node = tree.Search(5, tree.Root);
            Console.WriteLine(tree.Root.Value );
            Console.WriteLine(node.Value + " and left is " + node.Left + " and the right is " + node.Right + " and height of node is " + node.Height);
            Console.ReadLine();
        }
    }
}
