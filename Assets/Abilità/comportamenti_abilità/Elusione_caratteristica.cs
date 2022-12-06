using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[RequireComponent(typeof(CircleCollider2D))]
public class Elusione_caratteristica : Comportamento_abilita
{
    private const string nome = "elusione";
    private const string descrizione = "caratteristica che ti permette di evitare qualsiasi colpo per un lasso di tempo";
    private const Caratt_tempo_abilita tempo_inizio = Caratt_tempo_abilita.inizio;

    private int danno_player; //il danno che riceve il player quando l'elusione � attiva
    private Stopwatch temp_durata = new Stopwatch(); //conta i secondi
    private float dur_effetto; //quanto dura l'effetto sul palyer
    bool coll_attiva; //dice se il player � stato colpito da qualcosa

    Health_player vita_player;

    public Elusione_caratteristica(int adanno, float ad_effetto) : base (new Informazioni_base_abilita(nome,descrizione), tempo_inizio) //questo costruttore viene chiamato dalle abilit� che richiedo qusta caratteristica
    {
        danno_player = adanno; 
        dur_effetto = ad_effetto;
    }
    public override void comportamento_in_azione(GameObject player)//attenzione all' override
    {
        CircleCollider2D c_player = this.gameObject.GetComponent<CircleCollider2D>(); //questo collider deve essere di tipo trigger, quindi il player dovr� avaere 2 collider
        vita_player = player.GetComponent<Health_player>();
        StartCoroutine(elusione(vita_player));
    }

    private IEnumerator elusione(Health_player vita_player)
    {
        temp_durata.Start();
        
        while (temp_durata.Elapsed.TotalSeconds <= dur_effetto)
        {
            if(coll_attiva)
            {
                vita_player.Prendi_danno(danno_player); //chiama funzione che imposta il danno per il player a 0
            }
        }
        temp_durata.Stop();
        temp_durata.Reset();

        yield return null;
    }

    public int Danno_elusione
    {
        get { return danno_player; }
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
