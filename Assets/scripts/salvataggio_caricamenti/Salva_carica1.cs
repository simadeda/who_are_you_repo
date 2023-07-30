using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salva_carica1 : MonoBehaviour
{
    public UnityEngine.GameObject LettoreContinenteStatoXML;
    LettoreXML salvataggi_fileXML;

    void Start()
    {
        salvataggi_fileXML = LettoreContinenteStatoXML.GetComponent<LettoreXML>();
    }
    public void Salva_dati(int Scelta_salvataggio)
    {
        switch (Scelta_salvataggio)
        {
            case 0:
                Gestione_salvataggi.Salvataggio(salvataggi_fileXML, Scelta_salvataggio);
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

