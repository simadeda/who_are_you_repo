using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DepositoData 
{
    
    public string[] continente_stato = new string[2];
       
    public string nome_classe;

    public DepositoData(LettoreXML salvataggi)
    { 
        continente_stato[0] = LettoreXML.Nome_continente;
        continente_stato[1] = LettoreXML.Stato_selezionato;
        nome_classe = LettoreXML.Classe;
    } 
    
}


