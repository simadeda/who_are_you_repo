using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Elusione_caratteristica : MonoBehaviour
{
    private int danno_player; //il danno che riceve il player quando l'elusione è attiva
    private float dur_effetto; //quanto dura l'effetto sul palyer
    bool coll_attiva = false; //dice se il player è stato colpito da qualcosa
    private float tempo = 0f; //conta quanti secondi sono passati

    private Health_player vita_player;
    private Color colore_player;
    private SpriteRenderer render;


    public void comportamento_in_azione(GameObject player)
    {
        //CircleCollider2D c_player = this.gameObject.GetComponent<CircleCollider2D>(); //questo collider deve essere di tipo trigger, quindi il player dovrà avaere 2 collider
        vita_player = player.GetComponent<Health_player>();
        render = GetComponent<SpriteRenderer>();
        colore_player = render.color;
        StartCoroutine(elusione(vita_player));
    }

    private IEnumerator elusione(Health_player vita_player)
    {
        render.color = new Color(231, 0, 255, 255);
        Debug.Log("elusione iniziata");
        for(tempo = 0; tempo < dur_effetto; tempo++)
        {
            if (coll_attiva)
            {
                vita_player.Prendi_danno(danno_player); //chiama funzione che imposta il danno per il player a 0
            }
            yield return new WaitForSeconds(1);
        }
        Debug.Log("elusione finita");
        tempo = 0;
        render.color = colore_player;
        yield return null;
    }

    public float Dur_effetto
    {
       set { dur_effetto = value; }
    }
    public int Danno_elusione
    {
        set { danno_player = value; }
    }
     
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(coll_attiva)
        {
            vita_player.Prendi_danno(danno_player);//chiama funzione che imposta il danno per il player a 0
        }
        else
        coll_attiva = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        coll_attiva = false;
    }
}   
