using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerchio_caricamento : MonoBehaviour
{
    public RectTransform cerchio_caricamento;
    
    float velocit�_x = 5f, velocit�_y = 5f,start_time;
    public float velocita_rotazione,Angolo;
   

    private void Start()
    {
        start_time = Time.time;
        StartCoroutine("Status_caricamento", cerchio_caricamento);
    }

   
    IEnumerator Status_caricamento(RectTransform cerchio_caricamento)
    {
        while (true)
        {
            
            Vector2 altezza_wordpoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            Vector2 largehzza_wordpoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

            if (Time.time - start_time >= velocita_rotazione)
            {              
                transform.position -= new Vector3(velocit�_x,velocit�_y,0);
               
                if (transform.position.x >= altezza_wordpoint.x - 10 && transform.position.x <= altezza_wordpoint.x || 
                    transform.position.x <= largehzza_wordpoint.x + 10 && transform.position.x >= largehzza_wordpoint.x)
                {
                    velocit�_x = velocit�_x * -1;
                }

                if (transform.position.y >= altezza_wordpoint.y - 10 && transform.position.y <= altezza_wordpoint.y || 
                    transform.position.y <= largehzza_wordpoint.y + 10 && transform.position.y >= largehzza_wordpoint.y)
                {
                    velocit�_y = velocit�_y * -1;
                }
                              
               
                Vector3 direzione = cerchio_caricamento.localEulerAngles;

                direzione.z += Angolo;

                cerchio_caricamento.localEulerAngles = direzione;
                start_time = Time.time; 
                Debug.Log(transform.position);
                                
            }
           yield return null;
         }
         
    }



}
