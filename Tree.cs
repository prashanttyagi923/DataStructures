using System;

namespace DS
{
    public class Tree
    {
        public Tree()
        {
            this.Root = null;
        }
        public Node Root { get; set; }


        public Node Search(int value, Node node)
        {
            if (node == null)
            {
                throw new Exception("No match found");
            }
            if (node.Value == value)
            {
                return node;
            }
            else if (node.Value < value)
            {
                return Search(value, node.Right);
            }
            else
            {
                return Search(value, node.Left);
            }
            //return null;
        }

        public Node Insert(Node node, int key, int diff = 0)
        {
            Console.WriteLine("I recieved node " + node);
            if (node == null)
            {
                Console.WriteLine("I came here");
                return node = new Node(key)
                {
                    Height = 1
                };
                //.NewNode(key);
            }
            else if (key > node.Value)
            {
                if (node.Right == null)
                {
                    node.Right = node.NewNode(key);
                    node.Right.Height = node.Height + 1;
                    Console.WriteLine("Node " + node.Value + " height " + node.Height);
                    //Console.WriteLine("Left Node " + node.Left.Value+ " height " + node.Left.Height);
                    Console.WriteLine("Node " + node.Right.Value + " height " + node.Right.Height);
                    if (diff > 0)
                    {
                        Console.WriteLine("Tree is in left");
                        Console.WriteLine("Tree got unbalanced after node " + node.Right.Value + " insertion");
                        node = LeftRotate(node);
                        if (node.Parent.Parent == null)
                        {
                            this.Root = RightRotate(node.Parent);
                            this.Root.Parent = null;
                        }
                        else
                        {
                            RightRotate(node.Parent);
                        }
                    }
                    else if(diff < 0)
                    {
                        //Right Right case. Left Rotate
                        //node = LeftRotate(node);
                        if (node.Parent.Parent == null)
                        {
                            this.Root = LeftRotate(node.Parent);
                            this.Root.Parent = null;
                        }
                        else{
                            LeftRotate(node.Parent);
                        }
                        Console.WriteLine("Tree is in right");
                    }
                    return node.Right;
                }
                else
                {
                    return Insert(node.Right, key, (node.Left?.Height ?? 0) - (node.Right?.Height ?? 0));
                }
            }
            else if (key < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = node.NewNode(key);
                    node.Left.Height = node.Height + 1;
                    Console.WriteLine("Node " + node.Value + " height " + node.Height);
                    Console.WriteLine("Left Node " + node.Left.Value + " height " + node.Left.Height);
                    if (diff > 0)
                    {
                        Console.WriteLine("Tree is in left");
                        // Perform right rotate
                        Console.WriteLine("Tree got unbalanced after node " + node.Left.Value + " insertion");
                        if (node.Parent.Parent == null)
                        {
                            this.Root = RightRotate(node.Parent);
                        }
                        else
                        {
                            RightRotate(node.Parent);
                        }
                    } 
                    else if(diff < 0)
                    {
                        
                        Console.WriteLine("Tree is in right");

                        //node = 
                        RightRotate(node);
                        if (node.Parent == null)
                        {
                            this.Root = LeftRotate(node.Parent);
                            this.Root.Parent = null;
                        }
                        else
                        {
                            LeftRotate(node.Parent);
                        }
                    }
                    //Console.WriteLine("Node " + node.Right.Value+ " height " + node.Right.Height);
                    return node.Left;
                }
                else
                {
                    return Insert(node.Left, key, (node.Left?.Height ?? 0) - (node.Right?.Height ?? 0));
                }
            }
            else
            {
                Console.WriteLine("key is " + key);
                Console.WriteLine(" node is " + node);
                throw new Exception("Already a node exist with this key");
            }
        }
        public Node RightRotate(Node node)
        {
            Console.WriteLine("Came to right rotate");
            node.Left.Right = node;
            Node temp = node.Left;
            
            node.Left.Parent = null;
            node.Left = null;
            if (node.Parent != null)
            {

                node.Parent.Left = temp.Left;
            }
            node.Parent = temp;
            //Console.WriteLine("I will return after rotate " + node.Parent.Value);
            return node.Parent;
        }
         public Node LeftRotate(Node node)
        {
            Console.WriteLine("Came to left rotate");
           if(node.Parent != null){
            node.Parent.Left = node.Right;
           }
            //node.Left = node.Right;
            //node.Left.Right = node;
            //Node temp = node.Right;
            node.Right.Left = node;
            Node parent = node.Parent;
            if(parent != null && parent.Left != null){
            parent.Left.Parent = parent;
            }
            node.Parent = node.Right;
            node.Left = null;
            node.Right = null;

            // if (node.Parent != null)
            // {

            //     node.Parent.Left = temp.Left;
            // }
            //node.Parent = temp;
            //Console.WriteLine("I will return after rotate " + node.Parent.Value);
            return node.Parent;
        }
    
    }

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }
        public Node NewNode(int value)
        {
            return new Node(value)
            {
                Left = null,
                Right = null,
                Height = 1,
                Parent = this
            };
        }
        public Node Parent { get; set; }

        public int Value { get; set; }
        //public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height { get; set; }

    }

}