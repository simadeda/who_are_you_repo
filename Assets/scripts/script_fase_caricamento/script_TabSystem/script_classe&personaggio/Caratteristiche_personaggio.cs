using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Caratteristiche_personaggio : MonoBehaviour
{
    public UnityEngine.GameObject txt_anni,txt_data_di_nascita,txt_occhi,txt_altezza,lettoreXML,Generatore_num_rand,txt_nome,txt_capelli,txt_cognome;
    private TextMeshProUGUI TextMesH_anni,TextMesH_data,TextMesH_occhi,TextMesH_altezza,TextMesH_nome,TextMesH_capelli,TextMesH_cognome;
    private LettoreXML Lettura_personaggi; 
    private int Anni;
    private string Data_di_nascita, Nome_personaggio, Cognome_personaggio;
    private string Continente,Stato;
    private string[] Occhi = new string[4] {"azzurri","verdi","neri","marroni"};
    private string[] Colore_capelli = new string[6] {"biondi","castani","neri","marroni","bianchi","rossi"};
    private string occhi_scelti;
    private string capelli_scelti;

    void Awake()
    {
        TextMesH_anni = txt_anni.GetComponent<TextMeshProUGUI>();
        TextMesH_data = txt_data_di_nascita.GetComponent<TextMeshProUGUI>();
        TextMesH_occhi = txt_occhi.GetComponent<TextMeshProUGUI>();
        TextMesH_altezza = txt_altezza.GetComponent<TextMeshProUGUI>();
        TextMesH_nome = txt_nome.GetComponent<TextMeshProUGUI>();
        TextMesH_cognome = txt_cognome.GetComponent<TextMeshProUGUI>();
        TextMesH_capelli = txt_capelli.GetComponent<TextMeshProUGUI>();
        Lettura_personaggi = lettoreXML.GetComponent<LettoreXML>();
        
        int random_num = Random_number1.Rnd(12);
        Continente = LettoreXML.Nome_continente;
        Stato = LettoreXML.Stato_selezionato;
        (Nome_personaggio, Cognome_personaggio) = Lettura_personaggi.Lettura_personaggi(random_num,Continente,Stato);

        Data_di_nascita_rnd();
        Colore_occhi(Occhi);
        Capelli(Colore_capelli);
        Altezza_personaggio();
        Nome_cognome_personaggio();
    }
    public string Get_occhi
    {
        get { return occhi_scelti; }
    }

    public string Get_capelli
    {
        get { return capelli_scelti; }
    }

    public void Anni_rnd(int[] giorno_mese_anno)
    {
        Anni = 2022 - giorno_mese_anno[2];
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

        occhi_scelti = Occhi[Scelta];
        TextMesH_occhi.text = occhi_scelti;
    }

    public void Capelli(string[] colore_capelli)
    {
        int scelta;
        if(Anni > 55)
        {
            TextMesH_capelli.text = colore_capelli[4].ToString();
        }
        scelta = UnityEngine.Random.Range(0, 5);
        capelli_scelti = colore_capelli[scelta];
        TextMesH_capelli.text = capelli_scelti;
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
        TextMesH_cognome.text = Cognome_personaggio.ToString();
    }
}
