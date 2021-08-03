using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_camera : MonoBehaviour
{
    Vector2 angolo_destro, angolo_sinistro;
    public GameObject dead_cam;
    Dead_cam_script dead_cam_script;

    [SerializeField]
    Vector2 playerOffset;

    [SerializeField]
    Transform player;

    [SerializeField]
    float velocita_cam;

    private void Start()
    {
        dead_cam_script = dead_cam.GetComponent<Dead_cam_script>();
    }
    public void FixedUpdate()
    {
        bool controllo = dead_cam_script.controllo;
        Prova(controllo);
    }
    public void Prova(bool controllo)
    {
       Vector3 start_Cam = transform.position;
       Vector3 end_cam = player.transform.position;
            

       end_cam.z = -10;
       //movimento camera tramite il lerp
       //fare il codice dove, continua a registrare la posizione del player e la mette in una variabile, dopo di che... quando il player lascia la deadzone
       //aggiornare il valore dello start cam con la variabile della ultima posizone del player
       if (controllo == false)
       transform.position = Vector3.Lerp(start_Cam, end_cam, velocita_cam * Time.deltaTime);
              
       angolo_destro = Camera.main.ViewportToWorldPoint(new Vector3(0.8f, 0.7f, 0));
       Debug.Log(angolo_destro);

       angolo_sinistro = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.3f, 0));
       Debug.Log(angolo_sinistro);  
    }

}
