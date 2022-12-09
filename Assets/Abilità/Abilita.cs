using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abilita : ScriptableObject
{
    //nome  abilità & icona in game dell' abilità
    public string nome_abl;
    //tempo che impiega l'abilità per essere riutilizzata
    public float cooldown;
    //dice se l'abilità è possibile usarla su se stessi 
    public bool buff;
    //lo sprite che verrà visualizzato nell' icona
    public Sprite sprite_abl;
    //se c'è un' abilità che ha una durata di esecuzione
    public int durata;
    //per quelle abilità che possono essere usate in qualsiasi momento, ma in base a quanto tempo sono state utilizzate la variabile tempo_di_utilizzo = cooldown
    public float tempo_di_utilizzo;
    //qusta variabile serve per capire se l'abilità può essere chiamata di nuovo anche se il suo GameObject è ancora in scena
    public bool abilita_ancora_in_gioco;
    //se l'abilità per essere eseguita richiede un bersaglio
    public  bool richiede_bersaglio;
    //se l'abilità ha degli utilizzi
    public bool utilizzabili;
    
    public abstract void inizializza(GameObject obj);
    public abstract void TriggerAbility(GameObject obj);

}

    