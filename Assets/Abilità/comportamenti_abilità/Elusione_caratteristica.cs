using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[RequireComponent(typeof(CircleCollider2D))]
public class Elusione_caratteristica : MonoBehaviour
{
    private int danno_player; //il danno che riceve il player quando l'elusione è attiva
    private Stopwatch temp_durata = new Stopwatch(); //conta i secondi
    private float dur_effetto; //quanto dura l'effetto sul palyer
    bool coll_attiva = false; //dice se il player è stato colpito da qualcosa

    private Health_player vita_player;
    private SpriteRenderer colore_player;

    public void comportamento_in_azione(GameObject player)
    {
        //CircleCollider2D c_player = this.gameObject.GetComponent<CircleCollider2D>(); //questo collider deve essere di tipo trigger, quindi il player dovrà avaere 2 collider
        UnityEngine.Debug.Log("Elusione_caratteristica_diminuita " + player.activeInHierarchy);
        vita_player = player.GetComponent<Health_player>();
        colore_player = player.GetComponent<SpriteRenderer>();
        StartCoroutine(elusione(vita_player,colore_player));
    }

    private IEnumerator elusione(Health_player vita_player, SpriteRenderer colore_player)
    {
        temp_durata.Start();
        
        while (temp_durata.Elapsed.TotalSeconds <= dur_effetto)
        {
            colore_player.color = new Color(231,0,255,255);
            if (coll_attiva)
            {
                vita_player.Prendi_danno(danno_player); //chiama funzione che imposta il danno per il player a 0
            }
        }
        colore_player.color = new Color(255, 255, 255, 255);
        temp_durata.Stop();
        temp_durata.Reset();

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
