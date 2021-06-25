using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DepositoData 
{
    public string[] continente_stato = new string[2];
    public Resolution Salva_risoluzione_corrente;

    /*
    LettoreXML_continenti_stati_personaggio prova;
    public void lezzo()
    {
        continente_stato[0] = prova.Nome_continente;
    }*/
    public DepositoData(LettoreXML salvataggio_continente_stato)
    { 
        continente_stato[0] = LettoreXML.Nome_continente;
        continente_stato[1] = LettoreXML.Stato_selezionato;
    } 
    
  

}


