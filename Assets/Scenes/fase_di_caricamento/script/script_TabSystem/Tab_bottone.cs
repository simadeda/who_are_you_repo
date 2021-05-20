using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;


public class Tab_bottone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   public Tab_controller Tab_controller;

    //public Image BackgroundIMG;

    public void OnPointerClick(PointerEventData eventData)
    {
        Tab_controller.Tab_enter(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tab_controller.Tab_non_selezionata(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tab_controller.Tab_exit(this);
    }

    
}
