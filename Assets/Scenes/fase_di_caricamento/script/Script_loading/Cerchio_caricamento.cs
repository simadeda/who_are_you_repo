using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cerchio_caricamento : MonoBehaviour
{
    public RectTransform cerchio_caricamento;
    Vector2 altezza_wordpoint; 
    Vector2 largehzza_wordpoint;
    float velocità_x = 5f, velocità_y = 5f,start_time,fine_time = 5f;
    public float velocita_rotazione,Angolo;
    float tempo = 0f;

    private void Start()
    {
        start_time = Time.time;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        { 
            transform.localPosition = new Vector2(UnityEngine.Random.Range(-250f, 250f), UnityEngine.Random.Range(-250f, 250));
            StartCoroutine("Status_caricamento_rimbalzo", cerchio_caricamento);
        }
       
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    //first corroutine
    IEnumerator Status_caricamento_rimbalzo(RectTransform cerchio_caricamento)
    {
        start_time = Time.time;
        while (true)
        {
            altezza_wordpoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            largehzza_wordpoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));           
            if (Time.time - start_time >= velocita_rotazione)
            {              
                transform.position -= new Vector3(velocità_x,velocità_y,0);
               
                if (transform.position.x >= altezza_wordpoint.x - 12 && transform.position.x <= altezza_wordpoint.x || 
                    transform.position.x <= largehzza_wordpoint.x + 12 && transform.position.x >= largehzza_wordpoint.x)
                {
                    velocità_x = velocità_x * -1;
                }

                if (transform.position.y >= altezza_wordpoint.y - 12 && transform.position.y <= altezza_wordpoint.y || 
                    transform.position.y <= largehzza_wordpoint.y + 12 && transform.position.y >= largehzza_wordpoint.y)
                {
                    velocità_y = velocità_y * -1;
                }
                             
                start_time = Time.time; 
                              
            }
           yield return null;
         }
         
    }


    //second corroutine
    public IEnumerator Icona_caricamento_normale(RectTransform cerchio_caricamento)
    {
        tempo = 0;
        while (tempo <= fine_time)
        {
            tempo += Time.deltaTime;
           yield return null;
        }
        this.gameObject.SetActive(false);
    }
       

}
