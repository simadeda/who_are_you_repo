using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Video;
using UnityEngine;
using TMPro;

public class pannello_script : MonoBehaviour
{
    public GameObject pannel,main_script,video_img_intermittenza,output_pannello;
    public RawImage img_mignatura;
    script_principale_menù_continenti script_principale;
    Output_pannello output_Pannello_script;
             
    public VideoPlayer video_mappe;
    public Texture[] continenti_mignatura;
    string continente,capitale,stato,n_stati;
   
    public void show_hidePannel()
    { 
        script_principale = main_script.GetComponent<script_principale_menù_continenti>();
        
        continente = script_principale.nome_continente;
        capitale = script_principale.capitale;
        stato = script_principale.stato_selezionato;
        n_stati = script_principale.n_stati.ToString();

        main_script.SetActive(false);
        pannel.gameObject.SetActive(true);

        output_Pannello_script =  output_pannello.GetComponent<Output_pannello>();
              
        output_Pannello_script.Visualizzazione_pannello(continente, stato, capitale, n_stati);
        immagine_in_mignatura(continente);
        

    }
    void immagine_in_mignatura(string continente)
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
    public void btn_no()
    {
        main_script.SetActive(true);
        pannel.gameObject.SetActive(false);
        video_img_intermittenza.gameObject.SetActive(false);
        video_mappe.Stop();
    }

    public void btn_si()
    {

    }

}
