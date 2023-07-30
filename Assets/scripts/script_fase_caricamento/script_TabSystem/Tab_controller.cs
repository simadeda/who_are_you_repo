using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tab_controller : MonoBehaviour
{
    public List<Tab_bottone> Tab_bottoni = new List<Tab_bottone>(); //lista di gameobj che hanno al loro interno lo script "Tab_bottone" (i bottoni) o almeno quesso è quello che so capito
    public List<UnityEngine.GameObject> Tab_pannello; //lista di gameobj per il pannello
           
    public void Tab_enter(Tab_bottone Bottone) //funzione per il click deju mouse
    {
        int indice = Bottone.transform.GetSiblingIndex(); //pezzo ancora da capi bene
        for(int i=0; i<Tab_pannello.Count; i++) //for pe seleziona il pannello giusto in base al bottone cliccato
        {
            if(i == indice)
            {
                Tab_pannello[i].SetActive(true);
            }
            else
                Tab_pannello[i].SetActive(false);
        }
    }

    public void Tab_exit(Tab_bottone Bottone)  
    {

    }

    public void Tab_non_selezionata(Tab_bottone Bottone)
    {

    }
}
