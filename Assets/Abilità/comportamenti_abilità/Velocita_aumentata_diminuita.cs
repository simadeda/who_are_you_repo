using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocita_aumentata_diminuita : Comportamento_abilita
{
    private const string nome = "velocità aumentata o diminuita";
    private const string descrizione = "caratteristica che aumenta o diminuisce la velocità del player";
    private const Caratt_tempo_abilita tempo_iniziale = Caratt_tempo_abilita.inizio;

    private float velocita_aumentata;
    private bool velocita_diminuita;

    Velocita_aumentata_diminuita(float vel_aumen, bool vel_dimi) : base(new Informazioni_base_abilita(nome,descrizione), tempo_iniziale)
    {
        velocita_diminuita = vel_dimi;
        velocita_aumentata = vel_aumen;
    }

    public void comportamento_in_azione(Movimenti_player vel_player) //forse bisogna farlo diventare override, tieni d'occhio Movimenti_player
    {
        if (velocita_diminuita == false)
        {
            velocita_aumentata = 5;
            vel_player.Velocita_player += velocita_aumentata;
        }
        else
        {
            velocita_aumentata = -5;
            vel_player.Velocita_player += velocita_aumentata;
        }     
            
    }

    public float Max_vel_aumentata
    {
        get { return velocita_aumentata; }
    }
}
