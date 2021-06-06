using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class Caratteristiche_personaggio : MonoBehaviour
{
    public GameObject txt_anni,txt_data_di_nascita,txt_occhi,txt_altezza,lettoreXML,Generatore_num_rand;
    lettoreXML_continenti_stati Lettura_personaggi;
    random_number Random_number;
    Script_principale_menù_nazione Menù_nazione;
    private TextMeshProUGUI textMesH;
    int Anni;
    string Data_di_nascita;
    string[] Occhi = new string[4] {"Azzurri","Verdi","Neri","Marroni"};

    void Start()
    {
        Menù_nazione.GetComponent<Script_principale_menù_nazione>();
        Lettura_personaggi = lettoreXML.GetComponent<lettoreXML_continenti_stati>();
        Random_number = Generatore_num_rand.GetComponent<random_number>();
        int random_num = Random_number.Rnd(12); 
        string Continente = Menù_nazione.nome_continente;
        string Stato = Menù_nazione.stato_selezionato;
        Lettura_personaggi.lettura_personaggi(random_num,Continente,Stato);
        
       
       
        Data_di_nascita_rnd();
        Colore_occhi(Occhi);
        Altezza_personaggio();

    }  
    public void Anni_rnd(int[] giorno_mese_anno)
    {
        Anni = 2021 - giorno_mese_anno[2];
        textMesH = txt_anni.GetComponent<TextMeshProUGUI>();
        textMesH.text = Anni.ToString();
    }

    int Giorno_mese_anno(int[] giorno_mese_anno, int cambio_valori, int j)
    {
        int Min = 1;  
            
        if (j == 2)
            Min = 1961;

        giorno_mese_anno[j] = UnityEngine.Random.Range(Min, cambio_valori);
             
        return giorno_mese_anno[j];
    }
      
    public void Data_di_nascita_rnd()
    {
        int[] giorno_mese_anno = new int[3];
        int cambio_valori = 0, j =0;

        for(int i =0; i < 3; i++)
        {
            switch(i)
            {
                case 0:
                    cambio_valori = 31;
                    giorno_mese_anno[0] = Giorno_mese_anno(giorno_mese_anno,cambio_valori,j);
                    j++;
                    break;
                case 1:
                    cambio_valori = 12;
                    giorno_mese_anno[1] = Giorno_mese_anno(giorno_mese_anno, cambio_valori,j);
                    j++;
                    break;
                case 2:
                    cambio_valori = 2003;
                    giorno_mese_anno[2] = Giorno_mese_anno(giorno_mese_anno, cambio_valori,j);
                    break;
            }

        }
       
        Anni_rnd(giorno_mese_anno);

        Data_di_nascita = giorno_mese_anno[0].ToString() + "/" + giorno_mese_anno[1].ToString() + "/" + giorno_mese_anno[2].ToString();

        textMesH = txt_data_di_nascita.GetComponent<TextMeshProUGUI>();
        textMesH.text = Data_di_nascita;
    }

    public void Colore_occhi(string[] Occhi)
    {
        int Scelta = 0;
        Scelta = UnityEngine.Random.Range(0, Occhi.Length);
        textMesH = txt_occhi.GetComponent<TextMeshProUGUI>();
        textMesH.text = Occhi[Scelta].ToString();
    }

    public void Altezza_personaggio()
    {
        float percentuale_altezza = 0.00f,altezza;
        percentuale_altezza = UnityEngine.Random.Range(0.00f,100.00f);
        if(percentuale_altezza >= 0.01 && percentuale_altezza <= 0.05)
        {
            altezza = 1.00f; //rarità dello 0,05 %
        }
        else
            {
                altezza = UnityEngine.Random.Range(1.60f, 2.00f); //altezza normale
            }

        textMesH = txt_altezza.GetComponent<TextMeshProUGUI>();
        textMesH.text = altezza.ToString("F2");
    }

}
