using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salva_carica : MonoBehaviour
{
    public GameObject LettoreContinenteStatoXML;
    LettoreXML continente_stato;

    private void Start()
    {
        continente_stato = LettoreContinenteStatoXML.GetComponent<LettoreXML>();
    }
    public void Salva_dati()
    {
        Gestione_salvataggi.Salvataggio(continente_stato);
    }

    public void Carica_dati()
    {
        Cont_stato_prsn_data Carica = Gestione_salvataggi.Caricamento();
        LettoreXML.Nome_continente = Carica.continente_stato[0];
        LettoreXML.Stato_selezionato = Carica.continente_stato[1];
    }
}
