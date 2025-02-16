using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{


    void LateUpdate()
    {
        transform.position = new Vector3(Player.player.transform.position.x+1.5f, 0, -10);
    }
}
