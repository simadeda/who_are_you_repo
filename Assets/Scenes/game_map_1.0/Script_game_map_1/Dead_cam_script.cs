using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_cam_script : MonoBehaviour
{
    public Camera cam;
    public bool controllo = true;
    
    private void OnTriggerExit2D(Collider2D player)
    {
        Debug.Log("player uscito");
        controllo = false;
        //movimento_cam.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("player dentro");
        controllo = true;
        //movimento_cam.FixedUpdate();
    }
}
