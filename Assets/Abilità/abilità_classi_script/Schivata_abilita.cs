using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "abilita/Schivata_abilita")]
public class Schivata_abilita : Abilita
{
    private Velocita_aumentata_diminuita vel_aum_dim;
    private Elusione_caratteristica elusione;

    public float velocita_aumentata;
    public float velocita_diminuita;
    private float velocita_attuale;
    public int danno_elusione;

    public override void inizializza(GameObject obj)
    {
        if (obj.GetComponent<Velocita_aumentata_diminuita>() == null && obj.GetComponent<Elusione_caratteristica>() == null) //CONTROLLA SE LE DUE CARATTERISTICHE PER VELOCISTA SONO STATE AGGIUNTE AL PLAYER
        {
            //AGGIUNTA COMPONENTI
            obj.AddComponent<Velocita_aumentata_diminuita>();
            obj.AddComponent<Elusione_caratteristica>();
        }
        Movimenti_player velocità_player = obj.GetComponent<Movimenti_player>(); //PRESA COMPONETE PER IL MOVIMENTO DEL PLAYER 
        vel_aum_dim = obj.GetComponent<Velocita_aumentata_diminuita>(); //VEL_AUM_DIM PRENDE I COMPONENTI DI VELOCITA_DIMINUITA_AUMENTATA DAL PLAYER
        elusione = obj.GetComponent<Elusione_caratteristica>(); //ELUSIONE PRENDE I COMPONENTI DI ELUSIONE_CARATTERISTICA DAL PLAYER
       
        vel_aum_dim.Max_vel_aumentata = velocita_aumentata; //SET PER LA FUNZIONE Max_vel_aumentata 
        vel_aum_dim.Max_vel_diminuita = velocita_diminuita; //SET PER LA FUNZIONE Max_vel_diminuita 
        velocita_attuale = velocità_player.Velocita_player; //VIENE PRESA LA VELOCITA' BASE DEL PLAYER (15F)

        vel_aum_dim.Velocita_player_normale = velocita_attuale; //SET PER LA FUNZIONE Velocita_player_normale 

        elusione.Durata_effetto = durata; //SET PER LA FUNZIONE Dur_effetto 
        vel_aum_dim.Durata_effetto = durata; //SET PER LA FUNZIONE Durata_effetto

        elusione.Danno_elusione = danno_elusione; //SET PER LA FUNZIONE Danno_elusione 
    }

    //ATTIVA L'ABILITA'
    public override void TriggerAbility(GameObject obj)//override per l'abilità SCHIVATA
    {
        elusione.comportamento_in_azione(obj); //chiama la caratteristica dell' abilità "elusione" che ti permette di schivare i colpi
        vel_aum_dim.comportamento_in_azione(obj); //chiama la caratteristica dell' abilità "elusione" che ti permette un boost temporaneo della velcità
    }

}
