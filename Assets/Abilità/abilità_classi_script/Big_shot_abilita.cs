using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(menuName = "abilita/BigShot_abilita")]
public class Big_shot_abilita : Abilita
{
    public int danno;
    public int caricatore;
    public float velocità_proiettile;
    public float gittata;
    public float cooldawn_attacco;
    public float fire_rate;
    private Mimetismo_caratteristica mimetismo;
          
    //riferimento allo script che ti permette di trapassare i muri

    public override void inizializza(GameObject obj)
    {
        //mimetismo serve perchè è un buff per il player
        if (obj.GetComponent<Mimetismo_caratteristica>() == null)
        {
            obj.AddComponent<Mimetismo_caratteristica>();
        }
        mimetismo = obj.GetComponent<Mimetismo_caratteristica>();
        mimetismo.Durata_mimetismo = durata;

    }

    //ATTIVA L'ABILITA'
    public override void TriggerAbility(GameObject obj) //override per l'abilità BIGSHOT
    {
        mimetismo.comportamento_in_azione();
        barret_calibro_50();
        //chiama qualche metodo di mimetismo e aumenta il FOV

    }

    public void barret_calibro_50()
    {
        Debug.Log("barret attivo");
    }


}
