using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems; //"libreria" per gli event system
using UnityEngine;

[RequireComponent(typeof(Image))]
public class Tab_bottone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler 
{
    public Tab_controller Tab_controller; //riferimento allo script Tab_controller
    public List<Tab_bottone> tab_bottoni;
    public Sprite btn_inattivo;
    public Image img_icona_sfondo;

    void Start()
    {
        img_icona_sfondo = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData) //quando clicchi entra entro a sta funzione
    {
        Tab_controller.Tab_enter(this); //per ora va solo questo
    }

    public void OnPointerEnter(PointerEventData eventData)  //quando passi sopre co ju mouse entra ecco
    {
        Tab_controller.Tab_non_selezionata(this);
    }

    public void OnPointerExit(PointerEventData eventData) //quando passando sopre co ju mouse e poi escire dal bottone senza cliccarlo entra ecco
    {
        Tab_controller.Tab_exit(this);
    }

    public void img_icona_reset()
    {
        foreach(Tab_bottone bottone in tab_bottoni)
        {
            bottone.img_icona_sfondo.sprite = btn_inattivo;
        }
    }

    
}
