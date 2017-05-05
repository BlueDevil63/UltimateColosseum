using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFind
{
    public class Node
    {

        public int index;
        public Edge[] edge;

        public Node()
        {
            int index = -1;
            edge = new Edge[4];
        }

        public Node(int number)
        {
            index = number;
            edge = new Edge[4];
        }


    }
}
