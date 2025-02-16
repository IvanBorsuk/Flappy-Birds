using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pool
{
    public static List<GameObject> poolPipes = new List<GameObject>();
    public static List<GameObject> poolCoins = new List<GameObject>();

    public static void GetObjects(GameObject obj, Vector2 pos)
    {
        if(obj.tag == "Pipe")
        {
            if(poolPipes.Count > 0)
            {
                foreach(var n in poolPipes)
                {
                    if(!n)
                    {
                        n.transform.position = pos;
                        n.SetActive(true);
                        return;
                    }

                }

                InstansObj(obj, pos);
            }
            else
            {
                InstansObj(obj, pos);
            }
        }
        else if(obj.tag == "Coin")
        {
            if (poolCoins.Count > 0)
            {
                foreach (var n in poolCoins)
                {
                    if (!n)
                    {
                        n.transform.position = pos;
                        n.SetActive(true);
                        return;
                    }

                }

                InstansObj(obj, pos);
            }
            else
            {
                InstansObj(obj, pos);
            }
        }
    }

    private static void InstansObj(GameObject obj, Vector2 pos)
    {
        Object.Instantiate(obj, pos, Quaternion.identity);
        poolPipes.Add(obj);
    }
    
}
