using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Caratteristiche_personaggio : MonoBehaviour
{
    public GameObject txt_anni,txt_data_di_nascita,txt_occhi,txt_altezza,lettoreXML,Generatore_num_rand,txt_nome,txt_capelli;
    private TextMeshProUGUI TextMesH_anni,TextMesH_data,TextMesH_occhi,TextMesH_altezza,TextMesH_nome,TextMesH_capelli;
    Random_number Random_number;
    LettoreXML Lettura_personaggi; 
    int Anni;
    string Data_di_nascita,Nome_personaggio;
    string Continente,Stato;
    string[] Occhi = new string[4] {"Azzurri","Verdi","Neri","Marroni"};
    string[] Colore_capelli = new string[6] {"Biondi","Castani","Neri","Marroni","Bianchi","Rossi"};

    void Start()
    {
        TextMesH_anni = txt_anni.GetComponent<TextMeshProUGUI>();
        TextMesH_data = txt_data_di_nascita.GetComponent<TextMeshProUGUI>();
        TextMesH_occhi = txt_occhi.GetComponent<TextMeshProUGUI>();
        TextMesH_altezza = txt_altezza.GetComponent<TextMeshProUGUI>();
        TextMesH_nome = txt_nome.GetComponent<TextMeshProUGUI>();
        TextMesH_capelli = txt_capelli.GetComponent<TextMeshProUGUI>();
        Lettura_personaggi = lettoreXML.GetComponent<LettoreXML>();
        Random_number = Generatore_num_rand.GetComponent<Random_number>();

        int random_num = Random_number.Rnd(12);
        Continente = LettoreXML.Nome_continente;
        Stato = LettoreXML.Stato_selezionato;
        
        Nome_personaggio = Lettura_personaggi.Lettura_personaggi(random_num,Continente,Stato);

        Data_di_nascita_rnd();
        Colore_occhi(Occhi);
        Capelli(Colore_capelli);
        Altezza_personaggio();
        Nome_cognome_personaggio();
    }  
    public void Anni_rnd(int[] giorno_mese_anno)
    {
        Anni = 2021 - giorno_mese_anno[2];
        TextMesH_anni.text = Anni.ToString();
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

        TextMesH_data.text = Data_di_nascita;
    }

    public void Colore_occhi(string[] Occhi)
    {
        int Scelta;
        Scelta = UnityEngine.Random.Range(0, Occhi.Length);

        TextMesH_occhi.text = Occhi[Scelta].ToString();
    }

    public void Capelli(string[] colore_capelli)
    {
        int scelta;
        if(Anni > 55)
        {
            TextMesH_capelli.text = colore_capelli[4].ToString();
        }
        scelta = UnityEngine.Random.Range(0, 5);
        TextMesH_capelli.text = colore_capelli[scelta].ToString();
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

        TextMesH_altezza.text = altezza.ToString("F2");
    }

    public void Nome_cognome_personaggio()
    {
        TextMesH_nome.text = Nome_personaggio.ToString();
    }
}
