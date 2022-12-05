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

    private int danno_player; //il danno che riceve il player quando l'elusione è attiva
    private Stopwatch temp_durata = new Stopwatch(); 
    private float dur_effetto; //quanto dura l'effetto sul palyer
    bool coll_attiva; //dice se il player è stato colpito da qualcosa

    Elusione_caratteristica(int adanno, float ad_effetto) : base (new Informazioni_base_abilita(nome,descrizione), tempo_inizio)
    {
        danno_player = adanno;
        dur_effetto = ad_effetto;
    }
    public override void comportamento_in_azione(GameObject player)
    {
        CircleCollider2D c_player = this.gameObject.GetComponent<CircleCollider2D>(); //questo collider deve essere di tipo trigger, quindi il player dovrà avaere 2 collider
        StartCoroutine(elusione());
    }

    private IEnumerator elusione()
    {
        temp_durata.Start();

        while(temp_durata.Elapsed.TotalSeconds <= dur_effetto)
        {
            if(coll_attiva)
            {
                //chiamare funzione che imposta il danno per il player a 0
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
            //chiamare funzione che imposta il danno per il player a 0
        }
        else
        coll_attiva = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        coll_attiva = false;
    }
}   
