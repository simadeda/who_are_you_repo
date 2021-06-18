using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SalvataggioData 
{
    public string[] continente_stato = new string[2];

    /*
    LettoreXML_continenti_stati_personaggio prova;
    public void lezzo()
    {
        continente_stato[0] = prova.Nome_continente;
    }*/
    public SalvataggioData(LettoreXML salvataggio_continente_stato)
    { 
        continente_stato[0] = LettoreXML.Nome_continente;
        continente_stato[1] = LettoreXML.Stato_selezionato;
    } 
    
    public SalvataggioData(Opzioni salvataggio_opzioni)
    {

    }

}


