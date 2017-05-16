using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
  
    public class Node :MonoBehaviour
    {
        public enum NodeType
        {
            Ground,
            Air,
            Water,
        }
        //position
        //public int index;
        public int x;
        public int y;
        public int z;
             
        public NodeType type;
        public List<Edge> edges;
        public int cost;

        public int gcost;   //축적비용
        public int hcost;   //추정비용
        public int fcost    //총합 비용;
        {
            get
            {
                //F = G + H;
                return gcost + hcost;
            }
        }

        public GameObject worldObject;

        //public Node()
        //{
        //   // index = -1;
        //    type = NodeType.Ground;
        //    x = 0;
        //    y = 0;
        //    z = 0;
        //    // edge = new Edge[4];
        //    edges = new List<int>();
        //    gcost = 0;
        //    hcost = 0;
        //}

        //public Node(int number, NodeType t, int a, int b,int c)
        //{
        //    type = t;
        //    //index = number;
        //    x = a;
        //    y = b;
        //    z = c;
        //    //edge = new Edge[4];
        //    edges = new List<int>();
        //    gcost = 0;
        //    hcost = 0;
        //}
    }
}
