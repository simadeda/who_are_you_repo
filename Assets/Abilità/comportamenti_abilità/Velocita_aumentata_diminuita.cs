using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocita_aumentata_diminuita : MonoBehaviour
{
    private float velocita_aumentata;
    private float velocita_diminuita;
    private float velocita_player_normale;
    private float dur_effetto; //quanto dura l'effetto sul palyer
    private float dur_effeto_alterato;
    private GameObject UI_abilita;
    private Abilita_utilizzabili_cooldown abl_uti_cooldown;

    private void Start()
    {
        UI_abilita = GameObject.Find("UI_abilità");
        abl_uti_cooldown = UI_abilita.GetComponent<Abilita_utilizzabili_cooldown>();
    }
    public void comportamento_in_azione(GameObject player) //forse bisogna farlo diventare override, tieni d'occhio Movimenti_player
    {
        int count_uti = abl_uti_cooldown.max_uti - abl_uti_cooldown.count_utilizzabili;
        dur_effeto_alterato =  dur_effetto * count_uti;
        Debug.Log(dur_effeto_alterato);
        Movimenti_player vel_player = player.GetComponent<Movimenti_player>();
        StartCoroutine(velocita_aum(vel_player));
    }

    private IEnumerator velocita_aum(Movimenti_player vel_player)
    {
        Debug.Log("velocità iniziata");
        float vel_temp_aumentata = velocita_player_normale + velocita_aumentata;
        vel_player.Velocita_player = vel_temp_aumentata;
        yield return new WaitForSeconds(dur_effeto_alterato);
        StartCoroutine(velocita_dim(vel_player));
    }

    private IEnumerator velocita_dim(Movimenti_player vel_player)
    {
        Debug.Log("velocità finita");
        float vel_temp_diminuita = velocita_player_normale + velocita_diminuita;
        vel_player.Velocita_player = vel_temp_diminuita;
        yield return new WaitForSeconds((dur_effeto_alterato) / 2);
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
