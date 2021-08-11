using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Xml;

public class Script_principale_menu_nazione : MonoBehaviour
{
    public GameObject btn_scegli,rnd_numb, lettoreXML, video_img;
    Random_number rnd_number;
    LettoreXML continente_stati_abilita;
    Cambio_immagini_script video_img_script;
    
    public int num_rnd,n_stati;
    public string nome_continente, capitale, stato_selezionato, nome_classe, nome_abilita;

    void Start()
    {
        rnd_number = rnd_numb.GetComponent<Random_number>();
        continente_stati_abilita = lettoreXML.GetComponent<LettoreXML>();
        video_img_script = video_img.GetComponent<Cambio_immagini_script>();
    }
    public void Gestione_Script_Principale()
    {           
        //prende il numero random la prima volta, e gli passa 5
        num_rnd = rnd_number.Rnd(5);
        //sceglie il continente tramite il numero random e ridà il continente  e il numero di stati possibili
        continente_stati_abilita.LetturaXML_continenti(num_rnd, out n_stati, out nome_continente); 
        //richiamo della funzione random per la selezione dello stato, e gli si passa il numero massimo di stati del continete scelto in precedenza
        num_rnd = rnd_number.Rnd(n_stati);
        //scelta tramite il numero random dello stato selezionato e della sua capitale, gli si passa anche il continente selezionato
        continente_stati_abilita.LetturaXML_stati(num_rnd, nome_continente, out stato_selezionato, out capitale);
        //scelta tramite il numero random della classe e della sua relativa abilità base
        continente_stati_abilita.Lettura_abilita_classe(num_rnd, stato_selezionato, out nome_classe, out nome_abilita);
        //si va allo script per cambiare lo sfondo predefinito dei continenti, con il video mp4 del continente selezionato per fare una sorta di effetto visivo per capire quale continete è stato scelto
        video_img_script.scambio_immagini(nome_continente);
    }   
    
}
