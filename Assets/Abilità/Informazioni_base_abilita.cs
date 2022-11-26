using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informazioni_base_abilita
{
    private string nome;
    private Sprite icona;

    public Informazioni_base_abilita(string anome, Sprite aicona)
    {
        nome = anome;
        icona = aicona;
    }
    public Informazioni_base_abilita(string anome)
    {
        nome = anome;
    }
    public string Nome_informazioni_abilita
    {
        get { return nome; }
    }

    public Sprite icona_informazioni_abilita
    {
        get { return icona; }
    }
}
