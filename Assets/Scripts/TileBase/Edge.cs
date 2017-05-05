using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFind
{
    public class Edge
    {
        public Node from;
        public Node to;

        public Edge()
        {
            from = new Node();
            to = new Node();
        }

        public Edge (Node node_from, Node node_to)
        {
            from = node_from;
            to = node_to;
        }
    }
}
