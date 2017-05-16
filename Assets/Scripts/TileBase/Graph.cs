using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class Graph : MonoBehaviour
    {
        //싱글톤
        public static Graph instance;
        public static Graph GetInstance()
        {
            return instance;
        }
        void Awake()
        {
            instance = this;
        }

        public GameObject tilePref;
        public GameObject parantObj;
        public int x;
        public int y;
        public int z;

        public Node[,,] nodeGraph;

        void Start()
        {
            nodeGraph = new Node[x, y, z];
            CreateNode(x, y, z);
            EdgeConnect();
        }

        public void CreateNode(int x, int y, int z)
        {
            for (int h = 0; h < y; h++)
            {
                for (int r = 0; r < z; r++)
                {
                    for (int w = 0; w < x; w++)
                    {
                        //위치 잡기
                        Vector3 pos = new Vector3((-x / 2) + w, (-y / 2) + h, (-z / 2) + r);
                        //오브젝트 생성
                        GameObject tile = Instantiate(tilePref, pos, transform.rotation);
                        //오브젝트의 이름 바꾸기
                        tile.transform.name = r.ToString() + "_" + h.ToString() + "_" + w.ToString();
                        //오브젝트 부모 세팅;
                        tile.transform.parent = parantObj.transform;
                        //Node 세팅;
                        tile.GetComponent<Node>().x = w;
                        tile.GetComponent<Node>().y = h;
                        tile.GetComponent<Node>().z = r;
                        //graph에 추가
                        // Debug.Log("x = " + w + " " + "y = " + h + " " + "z = " + r);
                        nodeGraph[w, h, r] = tile.GetComponent<Node>();
                        nodeGraph[w, h, r].worldObject = tile;
                    }
                }
            }
        }
        public void EdgeConnect()
        {
            for (int h = 0; h < y; h++)
            {
                for (int r = 0; r < z; r++)
                {
                    for (int w = 0; w < x; w++)
                    {
                        Connect(w, h, r);
                    }
                }
            }
        }
        private void Connect(int a, int b, int c)
        {
            Edge edge= new Edge();
            for (int k = -1; k < 2; k++)
            {
                if (k + b >= 0 && k+b<y)
                {
                    //좌측
                    if ((a - 1) >= 0)
                    {
                        edge = new Edge(a - 1, b+k, c);
                        nodeGraph[a, b, c].edges.Add(edge);
                        if ((c + 1) < z)
                        {
                            edge = new Edge(a - 1, b+k, c + 1);
                            nodeGraph[a, b, c].edges.Add(edge);
                        }
                        if((c -1 ) >= 0)
                        {
                            edge = new Edge(a - 1, b + k, c - 1);
                            nodeGraph[a, b, c].edges.Add(edge);
                        }
                    }
                    //우측
                    if ((a + 1) < x)
                    {
                        edge = new Edge(a + 1, b + k, c);
                        nodeGraph[a, b, c].edges.Add(edge);
                        if ((c + 1) < z)
                        {
                            edge = new Edge(a + 1, b + k, c + 1);
                            nodeGraph[a, b, c].edges.Add(edge);
                        }
                        if ((c - 1) >= 0)
                        {
                            edge = new Edge(a + 1, b + k, c - 1);
                            nodeGraph[a, b, c].edges.Add(edge);
                        }
                    }
                    //위
                    if((c+1)<z)
                    {
                        edge = new Edge(a, b + k, c + 1);
                        nodeGraph[a, b, c].edges.Add(edge);
                    }
                    //아래
                    if ((c -1 ) >= 0)
                    {
                        edge = new Edge(a, b + k, c - 1);
                        nodeGraph[a, b, c].edges.Add(edge);
                    }
                    //y측 위
                    if(k!=0)
                    {
                        edge = new Edge(a, b + k, c);
                        nodeGraph[a, b, c].edges.Add(edge);
                    }
                }
            }

        }
    }
}