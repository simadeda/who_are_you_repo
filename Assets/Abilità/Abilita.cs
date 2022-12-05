using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilita 
{
    //nome  abilit� & icona in game dell' abilit�
    private Informazioni_base_abilita info_basi;
    
    //tempo che impiega l'abilit� per essere riutilizzata
    private int cooldown;
    //lista di caratteristiche della abilita E.S danno da sanguinamento, stortisce, danni da fuoco, riflette il danno, provoca paura al nemico ecc ecc
    private List<Comportamento_abilita> caratteristiche;
    //dice se l'abilit� � possibile usarla su se stessi 
    private bool buff;
    //se c'� un' abilit� che ha una durata di esecuzione
    private int durata;
    //per quelle abilit� che possono essere usate in qualsiasi momento, ma in base a quanto tempo sono state utilizzate la variabile tempo_di_utilizzo = cooldown
    private float tempo_di_utilizzo;
    //qusta variabile serve per capire se l'abilit� pu� essere chiamata di nuovo anche se il suo GameObject � ancora in scena
    private bool abilita_ancora_in_gioco;
    //se l'abilit� per essere eseguita richiede un bersaglio
    private bool richiede_bersaglio;
    //se l'abilit� ha degli utilizzi
    private bool utilizzabili;
    
    //tipi di abilit�
    public enum tipi_abilita
    {
        melee, famigli, lungo_raggio
    }

    //costruttore per le abilit� BUFF
    public Abilita(Informazioni_base_abilita ainfo_base ,int acooldown, List<Comportamento_abilita> acaratteristiche, int adurata, bool abuff)
    {
        info_basi = ainfo_base;
        acooldown = 0;
        cooldown = acooldown;
        caratteristiche = acaratteristiche;
        adurata = 45;
        durata = adurata;
        abuff = true;
        buff = abuff;
    }

    //costruttore per le abilit� RIUTILIZZABILI
    public Abilita(Informazioni_base_abilita ainfo_base, int acooldown, List<Comportamento_abilita> acaratteristiche, bool aablita_ancora_in_gioco)
    {
        info_basi = ainfo_base;
        acooldown = 0;
        cooldown = acooldown;
        caratteristiche = new List<Comportamento_abilita>();
        caratteristiche = acaratteristiche;
        aablita_ancora_in_gioco = false;
        abilita_ancora_in_gioco = aablita_ancora_in_gioco;
    }

    //costruttore per le abilit� TEMPO DI UTILIZZO
    public Abilita(Informazioni_base_abilita ainfo_base, int acooldown, List<Comportamento_abilita> acaratteristiche, bool abuff, bool arichiede_un_bersaglio, float atempo_di_utilizzo)
    {
        info_basi = ainfo_base;
        caratteristiche = new List<Comportamento_abilita>();
        caratteristiche = acaratteristiche;
        acooldown = 0;
        cooldown = acooldown;
        atempo_di_utilizzo = acooldown;
        arichiede_un_bersaglio = true;
        richiede_bersaglio = arichiede_un_bersaglio;
    }
    //costruttore per le abili� che RICHIEDONO UN BERSAGLIO
    public Abilita(Informazioni_base_abilita ainfo_base, int acooldown, List<Comportamento_abilita> acaratteristiche, bool abuff, bool arichiede_un_bersaglio)
    {
        info_basi = ainfo_base;
        caratteristiche = new List<Comportamento_abilita>();
        caratteristiche = acaratteristiche;
        acooldown = 0;
        cooldown = acooldown;
        arichiede_un_bersaglio = true;
        richiede_bersaglio = arichiede_un_bersaglio;
        abuff = true;
        buff = abuff;
    }
    //costruttore per le abilit� TEMPO DI UTILIZZO
    public Abilita(Informazioni_base_abilita ainfo_base, int acooldown, List<Comportamento_abilita> acaratteristiche, int atempo_di_utilizzo)
    {
        info_basi = ainfo_base; 
        caratteristiche = new List<Comportamento_abilita>();
        caratteristiche = acaratteristiche;
        acooldown = 0;
        cooldown = acooldown;
        atempo_di_utilizzo = 0;
        tempo_di_utilizzo = atempo_di_utilizzo;
    }

    //costruttore per le abilit� UTILIZZABILI
    public Abilita(Informazioni_base_abilita ainfo_base, int acooldown, List<Comportamento_abilita> acaratteristiche, bool aablita_ancora_in_gioco, bool autilizzabili, bool abuff)
    {
        info_basi = ainfo_base;
        caratteristiche = new List<Comportamento_abilita>();
        caratteristiche = acaratteristiche;
        acooldown = 10;
        cooldown = acooldown;
        aablita_ancora_in_gioco = false;
        abilita_ancora_in_gioco = aablita_ancora_in_gioco;
        abuff = true;
        buff = abuff;
    }

    public Informazioni_base_abilita Info_base_abilita
    {
        get { return info_basi; }
    }

    public int Cooldown_abilita
    {
        get { return cooldown; }
    }

    public int Durata_abilita
    {
        get { return durata; }
    }

    public float Tempo_di_utilizzo_abilita
    {
        get { return tempo_di_utilizzo; }
    }

    public List<Comportamento_abilita> Caratteristiche_abilita
    {
        get { return caratteristiche; }
    }

    public void usa_abilita_classe_stato()
    {

    }
 

}

    