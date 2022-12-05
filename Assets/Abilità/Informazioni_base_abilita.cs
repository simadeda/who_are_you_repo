using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informazioni_base_abilita
{
    private string nome;
    private string descrizione;
    private Sprite icona;

    public Informazioni_base_abilita(string anome,string descrizione, Sprite aicona) //costruttore per le abilità
    {
        nome = anome;
        icona = aicona;
    }
    public Informazioni_base_abilita(string anome, string adescrizione) // costruttore per le caratteristiche delle abilità
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

    public Sprite icona_informazioni_abilita
    {
        get { return icona; }
    }
}
