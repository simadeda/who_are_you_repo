using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Xml;

public class Script_principale_menu_nazione : MonoBehaviour
{
    public GameObject btn_scegli;
    GameObject rnd_numb, continente_stati, video_img;          //vengono creati 3 gameobject
    random_number rnd_numb_script;
    LettoreXML continente_stati_script;
    Cambio_immagini_script video_img_script;
    
    public int num_rnd,n_stati;
    public string nome_continente, capitale, stato_selezionato;
    public void Gestione_Script_Principale()
    {
        
        rnd_numb = GameObject.FindGameObjectWithTag("random_num");         //rnd_numb è diverso da num_rnd 
        rnd_numb_script = rnd_numb.GetComponent<random_number>();
        continente_stati = GameObject.FindGameObjectWithTag("let_XML");
        continente_stati_script = continente_stati.GetComponent<LettoreXML>();
        video_img = GameObject.Find("video_mappe_intermittenza");
        video_img_script = video_img.GetComponent<Cambio_immagini_script>();
        
        //prende il numero random la prima volta, e gli passa 5
        num_rnd = rnd_numb_script.Rnd(5);
        //sceglie il continente tramite il numero random e ridà il continente  e il numero di stati possibili
        continente_stati_script.letturaXML_continenti(num_rnd, out n_stati, out nome_continente); 
        //richiamo della funzione random per la selezione dello stato, e gli si passa il numero massimo di stati del continete scelto in precedenza
        num_rnd = rnd_numb_script.Rnd(n_stati);
        //scelta tramite il numero random dello stato selezionato e della sua capitale, gli si passa anche il continente selezionato
        continente_stati_script.letturaXML_stati(num_rnd, nome_continente, out stato_selezionato, out capitale);
        //si va allo script per cambiare lo sfondo predefinito dei continenti, con il video mp4 del continente selezionato per fare una sorta di effetto visivo per capire quale continete è stato scelto
        video_img_script.scambio_immagini(nome_continente);
    }   
    
}
