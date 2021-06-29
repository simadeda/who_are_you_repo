using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerchio_caricamento : MonoBehaviour
{
    public RectTransform cerchio_caricamento;
    
    float velocità = 5f;
    public float velocita_rotazione;
    public float Angolo;
    float start_time;
    private void Start()
    {
        start_time = Time.time;
        StartCoroutine("Status_caricamento", cerchio_caricamento);
    }

       
    IEnumerator Status_caricamento(RectTransform cerchio_caricamento)
    {
        /*
       float posizione_iniziale_X = UnityEngine.Random.Range(-500f, 500f);
       float posizione_iniziale_Y = UnityEngine.Random.Range(-500f, 500f);
        */
        //transform.position = new Vector3(posizione_iniziale_X, posizione_iniziale_Y, 0);

        while (true)
         {
            if(Time.time - start_time >= velocita_rotazione)
            {
                //transform.position += new Vector3(velocità,velocità,0);
                            
                Vector3 direzione = cerchio_caricamento.localEulerAngles;

                direzione.z += Angolo;

                cerchio_caricamento.localEulerAngles = direzione;
                start_time = Time.time; 
                
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, 0, 1300),
                                              Mathf.Clamp(transform.position.y, 0, 600));

            }
           yield return null;
         }
         
    }



}
