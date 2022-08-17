using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interazioni : MonoBehaviour
{
    public bool attivo;
    public KeyCode btn_interazione;
    public Interazioni_playerUI interazioni_UI;
    public UnityEvent evento_interazione;
    
    void Update()
    {
        if(attivo)
        {
            if(Input.GetKeyDown(btn_interazione))
            {
                evento_interazione.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            attivo = true;
            interazioni_UI.attiva_interazione();
            //Debug.Log("player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attivo = false;
            interazioni_UI.disattiva_interazione();
            //Debug.Log("player non in range");
        }
    }
}
