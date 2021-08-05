using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_camera : MonoBehaviour
{
    Vector2 angolo_destro, angolo_sinistro;
       
    [SerializeField]
    Vector2 playerOffset;

    [SerializeField]
    Transform player;

    [SerializeField]
    float velocita_cam;

   
    public void FixedUpdate()
    {
       Vector3 start_Cam = transform.position;
       Vector3 end_cam = player.transform.position;

       end_cam.x += playerOffset.x;
       end_cam.y += playerOffset.y;
       end_cam.z = -10;
       //movimento camera tramite il lerp       
       transform.position = Vector3.Lerp(start_Cam, end_cam, velocita_cam * Time.deltaTime);
              
       angolo_destro = Camera.main.ViewportToWorldPoint(new Vector3(0.8f, 0.7f, 0));
       Debug.Log(angolo_destro);

       angolo_sinistro = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.3f, 0));
       Debug.Log(angolo_sinistro);  
    
    }
     

}
