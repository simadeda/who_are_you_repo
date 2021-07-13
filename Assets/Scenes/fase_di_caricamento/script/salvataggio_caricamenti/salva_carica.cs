using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salva_carica : MonoBehaviour
{
    public GameObject LettoreContinenteStatoXML,Salva_opzioni;
    LettoreXML continente_stato;

    void Start()
    {
        continente_stato = LettoreContinenteStatoXML.GetComponent<LettoreXML>();
    }
    public void Salva_dati(int Scelta_salvataggio)
    {
        switch (Scelta_salvataggio)
        {
            case 0:
                Gestione_salvataggi.Salvataggio(continente_stato,Scelta_salvataggio);
                break;
            
        }
       
    }
    public void Carica_dati()
    {
        DepositoData Carica = Gestione_salvataggi.Caricamento();
        LettoreXML.Nome_continente = Carica.continente_stato[0];
        LettoreXML.Stato_selezionato = Carica.continente_stato[1];
    }
}
