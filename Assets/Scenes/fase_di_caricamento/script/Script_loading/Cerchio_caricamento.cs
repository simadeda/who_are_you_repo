using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cerchio_caricamento : MonoBehaviour
{
    public RectTransform cerchio_caricamento;
    Vector2 altezza_wordpoint; 
    Vector2 largehzza_wordpoint;
    float velocit�_x = 5f, velocit�_y = 5f,start_time;
    public float velocita_rotazione,Angolo;
   

    private void Start()
    {
        start_time = Time.time;
        if(SceneManager.sceneCount.Equals(3))
        { 
            transform.localPosition = new Vector2(UnityEngine.Random.Range(-250f, 250f), UnityEngine.Random.Range(-250f, 250));
            StartCoroutine("Status_caricamento_rimbalzo", cerchio_caricamento);
        }
       
        Debug.Log(SceneManager.sceneCount);
    }

    //first corroutine
    IEnumerator Status_caricamento_rimbalzo(RectTransform cerchio_caricamento)
    {
        while (true)
        {
            altezza_wordpoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            largehzza_wordpoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));           
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
                              
            }
           yield return null;
         }
         
    }


    //second corroutine
    public IEnumerator Icona_caricamento_normale(RectTransform cerchio_caricamento)
    {
        while (true)
        {
            if (Time.time - start_time >= velocita_rotazione)
            {
                transform.position -= new Vector3(velocit�_x, velocit�_y, 0);

                Vector3 direzione = cerchio_caricamento.localEulerAngles;

                direzione.z += Angolo;

                cerchio_caricamento.localEulerAngles = direzione;
                start_time = Time.time;
            }

        yield return new WaitForSeconds(3f); 
        }
    }


}
