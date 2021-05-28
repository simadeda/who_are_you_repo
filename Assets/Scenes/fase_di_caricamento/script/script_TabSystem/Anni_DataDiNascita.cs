using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Anni_DataDiNascita : MonoBehaviour
{
    public GameObject txt_anni, txt_data_di_nascita;
    private TextMeshProUGUI textMesH;
    int Anni;
    string Data_di_nascita;
       
    int Giorno_mese_anno(int[] giorno_mese_anno, int cambio_valori, int j)
    {
        int Min = 1;  
            
        if (j == 2)
            Min = 1961;

        giorno_mese_anno[j] = Random.Range(Min, cambio_valori);
             
        return giorno_mese_anno[j];
    }

    public void Anni_rnd(int[] giorno_mese_anno)
    {
        Anni = 2021 - giorno_mese_anno[2];
        textMesH = txt_anni.GetComponent<TextMeshProUGUI>();
        textMesH.text = Anni.ToString();
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
}
