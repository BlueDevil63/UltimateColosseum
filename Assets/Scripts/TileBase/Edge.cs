using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Grid
{
    public class Edge : MonoBehaviour
    {
        int x;
        int y;
        int z;

        public Edge()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Edge(int a, int b, int c)
        {
            x = a;
            y = b;
            z = c;
        }
    }
}
