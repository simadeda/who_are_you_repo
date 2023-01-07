using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocita_aumentata_diminuita : MonoBehaviour
{
    private float velocita_aumentata;
    private float velocita_diminuita;
    private float velocita_player_normale;
    private float dur_effetto; //quanto dura l'effetto sul player
    private bool vel_aum_dim_gia_attiva_uti = false;
    private int max_uti;

    private GameObject UI_abilita;
    private Abilita_utilizzabili_cooldown cooldown_abl_classe;

    IEnumerator velocita_aum_attiva, velocita_dim_attiva;
    private void Start()
    {
        UI_abilita = GameObject.Find("UI_abilità");
        cooldown_abl_classe = UI_abilita.GetComponent<Abilita_utilizzabili_cooldown>();
        max_uti = cooldown_abl_classe.max_uti;
    }

    public void comportamento_in_azione(GameObject player) //forse bisogna farlo diventare override, tieni d'occhio Movimenti_player
    {
        Movimenti_player vel_player = player.GetComponent<Movimenti_player>();
        int count_uti = cooldown_abl_classe.count_utilizzabili;
        count_uti = max_uti - count_uti;

        if (vel_aum_dim_gia_attiva_uti)
        {
            StopCoroutine(velocita_aum_attiva);
            StopCoroutine(velocita_dim_attiva);
        }

        velocita_aum_attiva = velocita_aum(vel_player, count_uti);
        velocita_dim_attiva = velocita_dim(vel_player, count_uti);

        vel_aum_dim_gia_attiva_uti = true;
        StartCoroutine(velocita_aum_attiva);
    }

    private IEnumerator velocita_aum(Movimenti_player vel_player, int count_uti)
    {
        Debug.Log("velocità iniziata ");
        float vel_temp_aumentata = velocita_player_normale + velocita_aumentata;
        vel_player.Velocita_player = vel_temp_aumentata;
        yield return new WaitForSeconds(dur_effetto*count_uti);
        StartCoroutine(velocita_dim(vel_player, count_uti));
    }

    private IEnumerator velocita_dim(Movimenti_player vel_player, int count_uti)
    {
        //Debug.Log("velocità finita " + count_corroutine_fine);
        float vel_temp_diminuita = velocita_player_normale + velocita_diminuita;
        vel_player.Velocita_player = vel_temp_diminuita;
        yield return new WaitForSeconds((dur_effetto*count_uti) / 2);
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
