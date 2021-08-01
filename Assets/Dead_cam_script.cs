using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_cam_script : MonoBehaviour
{
    Movimento_camera movimento_cam;
    public Camera cam;

    bool controllo = true;
    void Start()
    {
        movimento_cam = cam.GetComponent<Movimento_camera>();
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        Debug.Log("player uscito");
        movimento_cam.FixedUpdate(controllo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("player dentro");
        movimento_cam.FixedUpdate(controllo);
    }
}
