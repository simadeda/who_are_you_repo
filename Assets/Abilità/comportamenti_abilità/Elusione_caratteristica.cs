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
    private bool elusione_gia_attiva_uti = false;
    private bool vita_presa = false;
    private int max_uti; //riferimento agli utilizzabili massimi per un'abilità di tipo utilizzabile
    
    private Health_player vita_player;
    private Color colore_player;
    private SpriteRenderer render;

    private UnityEngine.GameObject UI_abilita;
    private Abilita_utilizzabili_cooldown cooldown_abl_classe;

    IEnumerator elusione_attiva;

    private void Start()
    {
        UI_abilita = UnityEngine.GameObject.Find("UI_abilità");
        cooldown_abl_classe = UI_abilita.GetComponent<Abilita_utilizzabili_cooldown>();
        render = GetComponent<SpriteRenderer>();
        colore_player = render.color;
        max_uti = cooldown_abl_classe.max_uti;
    }

    public void comportamento_in_azione(UnityEngine.GameObject player)
    {
        //CircleCollider2D c_player = this.gameObject.GetComponent<CircleCollider2D>(); //questo collider deve essere di tipo trigger, quindi il player dovrà avaere 2 collider
        if(!vita_presa)
        {
            vita_player = player.GetComponent<Health_player>();
            vita_presa = true;
        }
       
        int count_uti = cooldown_abl_classe.count_utilizzabili;
        count_uti = max_uti - count_uti;

        if (elusione_gia_attiva_uti)
            StopCoroutine(elusione_attiva);

        elusione_attiva = elusione(vita_player,count_uti);
                
        elusione_gia_attiva_uti = true;
        StartCoroutine(elusione_attiva);
    }

    private IEnumerator elusione(Health_player vita_player ,int count_uti)
    {
        render.color = new Color(231, 0, 255, 255);
        float temp_dur_effetto = dur_effetto * count_uti;
        for(tempo = 0; tempo < temp_dur_effetto; tempo++)
        {
            Debug.Log(tempo);
            if (coll_attiva)
            {
                vita_player.Prendi_danno(danno_player); //chiama funzione che imposta il danno per il player a 0
            }
            yield return new WaitForSeconds(1);
        }
        Debug.Log("elusione finita" + temp_dur_effetto);
        tempo = 0;
        render.color = colore_player;
        elusione_gia_attiva_uti = false;
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
