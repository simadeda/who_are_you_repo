using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informazioni_base_abilita
{
    private string nome;
    private string descrizione;
 
    public Informazioni_base_abilita(string anome,string adescrizione) //costruttore per le abilità
    {
        nome = anome;
        descrizione = adescrizione;
    }

    public string Nome_informazioni_abilita
    {
        get { return nome; }
    }

    public string Descrizione_informazioni_abilita
    {
        get { return descrizione; }
    }
}
