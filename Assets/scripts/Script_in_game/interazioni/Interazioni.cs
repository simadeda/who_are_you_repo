using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interazioni : MonoBehaviour
{
    public bool attivo;
    string edificio_rilevato;

    [SerializeField]
    private KeyCode btn_interazione;

    public Interazioni_playerUI interazioni_UI;
    public UnityEvent<string> evento_interazione;
    
    void Update()
    {
        if(attivo)
        {
            if(Input.GetKeyDown(btn_interazione))
            {
                evento_interazione.Invoke(edificio_rilevato);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            attivo = true;
            interazioni_UI.attiva_interazione();
            edificio_rilevato = transform.parent.name;
           
            Debug.Log(edificio_rilevato);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attivo = false;
            interazioni_UI.disattiva_interazione();
        }
    }
}
