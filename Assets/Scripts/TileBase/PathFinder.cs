using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class PathFinder : MonoBehaviour
    {
        public List<Node> foundPath;

        public List<Node> PathFinding( Node start, Node target)
        {
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();

            open.Add(start);

            while(open.Count > 0 )
            {
                Node current = open[0];
                for(int i = 0; i< open.Count; i++)
                {
                    //조건 검사
                    if (open[i].fcost< current.fcost 
                        || open[i].fcost == current.fcost
                        && open[i].hcost < current.hcost)
                    {
                        if(!current.Equals(open[i]))
                        {
                            current = open[i];
                        }

                    }
                    
                }
                open.Remove(current);
                closed.Add(current);
                //목표도달 검사
                if(current.Equals(target))
                {

                }
                //목표에 도달하지 못했기 때문에 이웃노드를 검색하여, 최저비용의 노드를 검사 노드에 추가
            }
            return foundPath;
         }

    }
}

