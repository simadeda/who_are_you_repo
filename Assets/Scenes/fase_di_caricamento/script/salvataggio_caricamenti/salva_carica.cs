using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salva_carica : MonoBehaviour
{
    LettoreXML_continenti_stati_personaggio continente_stato = new LettoreXML_continenti_stati_personaggio();

    public void Salva_dati()
    {
        Gestione_salvataggi.Salvataggio(continente_stato);
    }

    public void Carica_dati()
    {
        Cont_stato_prsn_data Carica = Gestione_salvataggi.Caricamento();
        continente_stato.Nome_continente = Carica.continente_stato[1];
        continente_stato.Nome_continente = Carica.continente_stato[1];
    }
}
