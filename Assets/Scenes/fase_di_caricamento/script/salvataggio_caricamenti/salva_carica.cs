using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salva_carica : MonoBehaviour
{
    public GameObject LettoreContinenteStatoXML,Salva_opzioni;
    LettoreXML continente_stato;
    Opzioni opzioni;

    private void Start()
    {
        continente_stato = LettoreContinenteStatoXML.GetComponent<LettoreXML>();
        opzioni = Salva_opzioni.GetComponent<Opzioni>();
    }
    public void Salva_dati(int Scelta_salvataggio)
    {
        switch (Scelta_salvataggio)
        {
            case 0:
                Gestione_salvataggi.Salvataggio(continente_stato,opzioni,Scelta_salvataggio);
                break;
            case 1:
                Gestione_salvataggi.Salvataggio(continente_stato,opzioni,Scelta_salvataggio);
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
