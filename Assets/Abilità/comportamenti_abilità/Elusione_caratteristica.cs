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

    private GameObject UI_abilita;
    private Abilita_utilizzabili_cooldown cooldown_abl_classe;

    private void Start()
    {
        UI_abilita = GameObject.Find("UI_abilità");
        cooldown_abl_classe = UI_abilita.GetComponent<Abilita_utilizzabili_cooldown>();
    }

    public void comportamento_in_azione(GameObject player)
    {
        //CircleCollider2D c_player = this.gameObject.GetComponent<CircleCollider2D>(); //questo collider deve essere di tipo trigger, quindi il player dovrà avaere 2 collider
        vita_player = player.GetComponent<Health_player>();
        int count_uti = cooldown_abl_classe.count_utilizzabili;
        render = GetComponent<SpriteRenderer>();
        colore_player = render.color;
        if (count_uti == 0) //serve per le abilità che non sono utilizzabili
            count_uti = 1;
        StartCoroutine(elusione(vita_player, count_uti));
    }

    private IEnumerator elusione(Health_player vita_player, int count_uti)
    {
        render.color = new Color(231, 0, 255, 255);
        //Debug.Log("elusione iniziata");
        for(tempo = 0; tempo < dur_effetto*count_uti; tempo++)
        {
            if (coll_attiva)
            {
                vita_player.Prendi_danno(danno_player); //chiama funzione che imposta il danno per il player a 0
            }
            yield return new WaitForSeconds(1);
        }
        //Debug.Log("elusione finita");
        tempo = 0;
        render.color = colore_player;
        yield return null;
    }

    public float Durata_effetto
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
