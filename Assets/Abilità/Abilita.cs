using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abilita : ScriptableObject
{
    //nome  abilit� & icona in game dell' abilit�
    public string nome_abl;
    //tempo che impiega l'abilit� per essere riutilizzata
    public float cooldown;
    //dice se l'abilit� � possibile usarla su se stessi 
    public bool buff;
    //lo sprite che verr� visualizzato nell' icona
    public Sprite sprite_abl;
    //se c'� un' abilit� che ha una durata di esecuzione
    public int durata;
    //per quelle abilit� che possono essere usate in qualsiasi momento, ma in base a quanto tempo sono state utilizzate la variabile tempo_di_utilizzo = cooldown
    public float tempo_di_utilizzo;
    //qusta variabile serve per capire se l'abilit� pu� essere chiamata di nuovo anche se il suo GameObject � ancora in scena
    public bool abilita_ancora_in_gioco;
    //se l'abilit� per essere eseguita richiede un bersaglio
    public  bool richiede_bersaglio;
    //se l'abilit� ha degli utilizzi
    public bool utilizzabili;
    
    public abstract void inizializza(GameObject obj);
    public abstract void TriggerAbility(GameObject obj);

}

    