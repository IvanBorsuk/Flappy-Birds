using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
  


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ParalaxArea")
        {
            transform.position = new Vector2(transform.position.x + 11.7f + 1.1f, Random.RandomRange(LevelControler.singeltone.minValue, LevelControler.singeltone.maxValue));

        }
    }


}
