using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Velocita_aumentata_diminuita : MonoBehaviour 
{
    private float velocita_aumentata;
    private float velocita_diminuita;
    private bool dur_effetto_termianta = false;
    private float velocita_player_normale;
    private float dur_effetto; //quanto dura l'effetto sul palyer
    private Stopwatch temp_durata = new Stopwatch(); //conta i secondi

    public void comportamento_in_azione(GameObject player) //forse bisogna farlo diventare override, tieni d'occhio Movimenti_player
    {
        Movimenti_player vel_player = player.GetComponent<Movimenti_player>();
        UnityEngine.Debug.Log("Velocita_aumentata_diminuita " + player.activeInHierarchy);
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
                float vel_temp_diminuita = vel_attuale + velocita_diminuita;
                vel_player.Velocita_player = vel_temp_diminuita;
                dur_effetto_termianta = false;
            }
        }
        yield return null;
    }

    public float Max_vel_aumentata
    {
        set { velocita_aumentata = value; } 
    }
    public float Max_vel_diminuita
    {
        set { velocita_diminuita = value; }
    }
    public float Velocita_player_normale
    {
        set { velocita_player_normale = value; }
    }
    public float Durata_effetto
    {
        set { dur_effetto = value; }
    }
}
