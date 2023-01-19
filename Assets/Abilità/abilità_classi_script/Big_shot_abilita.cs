using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "abilita/BigShot_abilita")]
public class Big_shot_abilita : Abilita
{
    public int danno;
    public int caricatore;
    public float velocità_proiettile;
    public float gittata;
    public Animator animator; //non so se bisogna toglierlo
    public float cooldawn_attacco;
    public float fire_rate;

    //riferimento allo script che ti permette di trapassare i muri
    public override void inizializza(GameObject obj)
    {
        

    }

    //ATTIVA L'ABILITA'
    public override void TriggerAbility(GameObject obj)
    {
        

    }

}
