using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tab_controller : MonoBehaviour
{
    public List<Tab_bottone> Tab_bottoni = new List<Tab_bottone>();
    public List<GameObject> Tab_pannello;
           
    public void Tab_enter(Tab_bottone Bottone)
    {
        int indice = Bottone.transform.GetSiblingIndex();
        for(int i=0; i<Tab_pannello.Count; i++)
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
