using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantiagoSarabia_Practice4
{
    public class Node
    {
        public string element;
        public int number;
        public Node left;
        public Node right;

        public Node(string _element, int _number)
        {
            element = _element;
            number = _number;
            left = null;
            right = null;
        }

    }
}
