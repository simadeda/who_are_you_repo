using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Scegli_arma : MonoBehaviour
{
    public UnityEngine.GameObject txt_arma_scelta, txt_descrizione_arma, txt_armi_utilizzabili, LettoreXMLgb, selezione_arma1, selezione_arma2, arma_1, arma_2;
    public Sprite[] armi = new Sprite[4];
    bool classe_attabrighe = false;
    Image arma_img1, arma_img2;
    LettoreXML LettoreXMLscript;
    private TextMeshProUGUI TextMesH_arma_scelta, TextMesH_descrizione_arma, TextMesH_armi_utilizzabili;

    private string[] nome_arma = new string[2], descrizione_arma = new string[2];
    string armi_utilizzabili, arma_selezionata;

    void Start()
    {
        TextMesH_arma_scelta = txt_arma_scelta.GetComponent<TextMeshProUGUI>();
        TextMesH_descrizione_arma = txt_descrizione_arma.GetComponent<TextMeshProUGUI>();
        TextMesH_armi_utilizzabili = txt_armi_utilizzabili.GetComponent<TextMeshProUGUI>();
        arma_img1 = arma_1.GetComponent<Image>();
        arma_img2 = arma_2.GetComponent<Image>();
        LettoreXMLscript = LettoreXMLgb.GetComponent<LettoreXML>();

        (nome_arma, descrizione_arma) = LettoreXMLscript.Lettura_armi(nome_arma, descrizione_arma);
        armi_utilizzabili = LettoreXML.Armi_utilizzabili;

        if(nome_arma[0] == "Pala da muratore")
        {
            arma_img1.sprite = armi[2];
            arma_img2.sprite = armi[3];
            classe_attabrighe = true;
        }
        else
        {
            arma_img1.sprite = armi[0];
            arma_img2.sprite = armi[1];
            classe_attabrighe = false;
        }
        TextMesH_armi_utilizzabili.text = armi_utilizzabili;
        TextMesH_arma_scelta.text = nome_arma[0];
        TextMesH_descrizione_arma.text = descrizione_arma[0];
               
    }

    public void armi_utilizzabili_classe(string arma_premuta)
    {
        int index = arma_premuta.IndexOf("*");
        if (classe_attabrighe == true)
        {
            arma_premuta = arma_premuta.Substring(index + 1);
        }
        else
            arma_premuta = arma_premuta.Substring(0, index);
        
        if(arma_selezionata != arma_premuta)
        {
            switch(arma_premuta)
            {
                case "G17":
                    TextMesH_arma_scelta.text = nome_arma[0];
                    TextMesH_descrizione_arma.text = descrizione_arma[0];
                    selezione_arma1.SetActive(true);
                    selezione_arma2.SetActive(false);
                    arma_selezionata = "G17";
                    break;

                case "C96":
                    TextMesH_arma_scelta.text = nome_arma[1];
                    TextMesH_descrizione_arma.text = descrizione_arma[1];
                    selezione_arma2.SetActive(true);
                    selezione_arma1.SetActive(false);
                    arma_selezionata = "C96";
                    break;

                case "pala":
                    TextMesH_arma_scelta.text = nome_arma[0];
                    TextMesH_descrizione_arma.text = descrizione_arma[0];
                    selezione_arma1.SetActive(true);
                    selezione_arma2.SetActive(false);
                    arma_selezionata = "pala";
                    break;

                case "guantoni":
                    TextMesH_arma_scelta.text = nome_arma[1];
                    TextMesH_descrizione_arma.text = descrizione_arma[1];
                    selezione_arma2.SetActive(true);
                    selezione_arma1.SetActive(false);
                    arma_selezionata = "guantoni";
                    break;
            }
        }
    }
   
}
