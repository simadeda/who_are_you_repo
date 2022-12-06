using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schivata_abilita : Abilita
{
    private const string aNome = "Schivata";
    private const string aDescrizione = "dal file XML";
    private const int aCooldown = 10;
    private const bool aBuff = true;
    private const bool aAbilita_ancora_in_gioco = false;
    private const bool Autilizzabili = true;

    int danno_elusione = 0;
    float durata_effetto = 10f;

    float velocita_aumentata = 5f;
    float velocuta_diminuita = 7f;
    float velocita_attuale;
    Movimenti_player velocità_player = new Movimenti_player();
       

    Schivata_abilita() :base(new Informazioni_base_abilita(aNome,aDescrizione) ,aCooldown,aAbilita_ancora_in_gioco,Autilizzabili,aBuff) 
    {
        this.Caratteristiche_abilita.Add(new Elusione_caratteristica(danno_elusione, durata_effetto));
        velocita_attuale = velocità_player.Velocita_player;
        this.Caratteristiche_abilita.Add(new Velocita_aumentata_diminuita(velocita_aumentata, velocuta_diminuita, velocita_attuale));
    }
}
