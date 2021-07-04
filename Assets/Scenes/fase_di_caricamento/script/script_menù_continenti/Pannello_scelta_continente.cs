using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Video;
using UnityEngine;
using TMPro;

public class Pannello_scelta_continente : MonoBehaviour
{
    public GameObject pannel,bottone_scegli,img_intermittenza,output_pannello;
    public RawImage img_mignatura;
    Script_principale_menu_nazione script_principale;
    Output_pannello output_Pannello_script;
             
    public VideoPlayer video_mappe;
    public Texture[] continenti_mignatura;
    string continente,capitale,stato,n_stati;
   
    public void Show_hidePannel()
    { 
        script_principale = bottone_scegli.GetComponent<Script_principale_menu_nazione>();
        
        continente = script_principale.nome_continente;
        capitale = script_principale.capitale;
        stato = script_principale.stato_selezionato;
        n_stati = script_principale.n_stati.ToString();

        bottone_scegli.SetActive(false);
        pannel.gameObject.SetActive(true);

        output_Pannello_script =  output_pannello.GetComponent<Output_pannello>();
              
        output_Pannello_script.Visualizzazione_pannello(continente, stato, capitale, n_stati);
        Immagine_in_mignatura(continente);
        

    }
    void Immagine_in_mignatura(string continente)
    {
        switch (continente)
        {
           case "Asia":
               {
                   img_mignatura.texture = continenti_mignatura[0];
               }
               break;
           case "America":
               {
                   img_mignatura.texture = continenti_mignatura[1];
               }
               break;
           case "Europa":
               { 
                   img_mignatura.texture = continenti_mignatura[2];
               }
               break;
           case "Africa":
               {
                   img_mignatura.texture = continenti_mignatura[3];
               }
               break;
           case "Oceania":
               { 
                   img_mignatura.texture = continenti_mignatura[4];
               }
               break;
        }
    }
    public void Btn_no()
    {
        bottone_scegli.SetActive(true);
        pannel.gameObject.SetActive(false);
        img_intermittenza.gameObject.SetActive(false);
        video_mappe.Stop();
    }

}
