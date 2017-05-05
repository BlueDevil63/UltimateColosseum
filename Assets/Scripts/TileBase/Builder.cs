using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

    public GameObject tilePref;
    public GameObject parantObj;
    public int x;
    public int y;
    // Use this for initialization
    void Start() {

        Tiling(x, y);
    }

    public void Tiling(int x, int y)
    {
     
        for(int r = 0; r<y; r++)
        {
            
            for(int w = 0; w<x; w++)
            {
                Vector3 pos = new Vector3((-x/2) + w, 0, (-y/2) + r);
                GameObject tile = Instantiate(tilePref, pos, transform.rotation);
                string t_name = r + "by" + w;
                tile.name = t_name;
                tile.transform.parent = parantObj.transform;
            }
        }
    }
}
