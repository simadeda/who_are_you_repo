using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocita_aumentata_diminuita : MonoBehaviour
{
    private float velocita_aumentata;
    private float velocita_diminuita;
    private float velocita_player_normale;
    private float dur_effetto; //quanto dura l'effetto sul palyer
    private float count_corroutine_inizio = 0;
    private float count_corroutine_fine = 0;

    public void comportamento_in_azione(GameObject player) //forse bisogna farlo diventare override, tieni d'occhio Movimenti_player
    {
        Movimenti_player vel_player = player.GetComponent<Movimenti_player>();
        count_corroutine_inizio++;
        StartCoroutine(velocita_aum(vel_player));
    }

    private IEnumerator velocita_aum(Movimenti_player vel_player)
    {
        Debug.Log("velocità iniziata " + count_corroutine_inizio);
        float vel_temp_aumentata = velocita_player_normale + velocita_aumentata;
        vel_player.Velocita_player = vel_temp_aumentata;
        yield return new WaitForSeconds(dur_effetto);
        count_corroutine_fine++;
        StartCoroutine(velocita_dim(vel_player));
    }

    private IEnumerator velocita_dim(Movimenti_player vel_player)
    {
        Debug.Log("velocità finita " + count_corroutine_fine);
        float vel_temp_diminuita = velocita_player_normale + velocita_diminuita;
        vel_player.Velocita_player = vel_temp_diminuita;
        yield return new WaitForSeconds((dur_effetto) / 2);
        vel_player.Velocita_player = velocita_player_normale;
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
