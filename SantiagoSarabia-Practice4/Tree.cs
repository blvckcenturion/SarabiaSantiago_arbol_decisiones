using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantiagoSarabia_Practice4
{
    public class Tree
    {
        Node root;
        List<Node> nodeList = new List<Node>();
        public Tree() { root = null; }
        public Node getRoot() { return root; }
        public void insert(string data, int weight)
        {
            insertInto(getRoot(), data, weight);
        } 

        public void insertInto(Node rt, string data, int num)
        {
            if (rt == null) root = new Node(data,num);
            else if(num < rt.number)
            {
                if (rt.left != null) insertInto(rt.left, data, num);
                else rt.left = new Node(data, num);
            }
            else if(num > rt.number)
            {
                if (rt.right != null) insertInto(rt.right, data, num);
                else rt.right = new Node(data, num);
            }
        }

        public List<Node> showListInOrder()
        {
            Node rt = getRoot();
            nodeList.Clear();
            inOrder(rt);
            return nodeList;
        }

        public void inOrder(Node rt)
        {
            if (rt != null)
            {
                inOrder(rt.left);
                nodeList.Add(rt);
                inOrder(rt.right);
            }    
        }

        public void getQuestion(Node rt, Delegate del)
        {
            bool answer; 
            if( rt != null)
            {
                if(rt.left == null && rt.right == null)
                {
                    del(rt.number, rt.element, true);
                }
                else
                {
                    answer = del(rt.number, rt.element, false);
                    if (answer) getQuestion(rt.left, del);
                    else getQuestion(rt.right, del);

                }
            }
        }

        public void Quiz(Delegate del)
        {
            Node rt = getRoot();
            getQuestion(rt, del);
        }

    }
}
