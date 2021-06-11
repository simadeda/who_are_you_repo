using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cont_stato_prsn_data 
{
    public string[] continente_stato = new string[2];

    /*
    LettoreXML_continenti_stati_personaggio prova;
    public void lezzo()
    {
        continente_stato[0] = prova.Nome_continente;
    }*/
    public Cont_stato_prsn_data(LettoreXML_continenti_stati_personaggio salvataggio)
    {
        continente_stato[0] = salvataggio.Nome_continente;
        continente_stato[1] = salvataggio.Stato_selezionato;
    }

}
