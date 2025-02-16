using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{


    private void Update()
    {
        MoveParalax();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ParalaxArea")
        {
            transform.position = new Vector2(transform.position.x + 8f, 0);
        }
    }



    private void MoveParalax()
    {
        transform.position += Vector3.left * LevelControler.singeltone.speed * Time.deltaTime;
    }

   
    
}
