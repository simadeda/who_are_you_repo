using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Velocita_aumentata_diminuita : Comportamento_abilita
{
    private const string nome = "velocità aumentata o diminuita";
    private const string descrizione = "caratteristica che aumenta o diminuisce la velocità del player";
    private const Caratt_tempo_abilita tempo_iniziale = Caratt_tempo_abilita.inizio;

    private float velocita_aumentata;
    private float velocita_diminuita;
    private bool dur_effetto_termianta = false;
    private float velocita_player_normale;
    private float dur_effetto; //quanto dura l'effetto sul palyer
    private Stopwatch temp_durata = new Stopwatch(); //conta i secondi

    public Velocita_aumentata_diminuita(float vel_aumen, float vel_dimi, float vel_p_n) : base(new Informazioni_base_abilita(nome,descrizione), tempo_iniziale)
    {
        velocita_aumentata = vel_aumen;
        velocita_diminuita = vel_dimi;
        velocita_player_normale = vel_p_n;
    }

    public void comportamento_in_azione(Movimenti_player vel_player) //forse bisogna farlo diventare override, tieni d'occhio Movimenti_player
    {
        StartCoroutine(velocita_aum(vel_player));
        StartCoroutine(velocita_dim(vel_player));
        vel_player.Velocita_player = velocita_player_normale;
    }

    public IEnumerator velocita_aum(Movimenti_player vel_player)
    {
        float vel_attuale = vel_player.Velocita_player;

        while (temp_durata.Elapsed.TotalSeconds > dur_effetto)
        {
            if (dur_effetto_termianta == false)
            {
                float vel_temp_aumentata = vel_attuale + velocita_aumentata;
                vel_player.Velocita_player = vel_temp_aumentata;
                dur_effetto_termianta = true;
            }
        }
        yield return null;
    }

    public IEnumerator velocita_dim(Movimenti_player vel_player)
    {
        float vel_attuale = vel_player.Velocita_player;

        while (temp_durata.Elapsed.TotalSeconds > dur_effetto)
        {
            if (dur_effetto_termianta == true)
            {
                float vel_temp_diminuita = vel_attuale + velocita_aumentata;
                vel_player.Velocita_player = vel_temp_diminuita;
                dur_effetto_termianta = false;
            }
        }
        yield return null;
    }

    public float Max_vel_aumentata
    {
        get { return velocita_aumentata; }
    }
    public float Velocita_player_normale
    {
        get { return velocita_player_normale; }
    }
}
