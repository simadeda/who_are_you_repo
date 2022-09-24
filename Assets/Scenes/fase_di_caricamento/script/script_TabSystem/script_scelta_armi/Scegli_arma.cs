using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scegli_arma : MonoBehaviour
{
    public GameObject txt_arma_scelta, txt_descrizione_arma, txt_armi_utilizzabili, LettoreXMLgb, selezione_c96, selezione_g17;
    LettoreXML LettoreXMLscript;
    private TextMeshProUGUI TextMesH_arma_scelta, TextMesH_descrizione_arma, TextMesH_armi_utilizzabili;

    private string[] nome_arma = new string[2], descrizione_arma = new string[2];
    string armi_utilizzabili, arma_selezionata = "G17";


    void Start()
    {
        TextMesH_arma_scelta = txt_arma_scelta.GetComponent<TextMeshProUGUI>();
        TextMesH_descrizione_arma = txt_descrizione_arma.GetComponent<TextMeshProUGUI>();
        TextMesH_armi_utilizzabili = txt_armi_utilizzabili.GetComponent<TextMeshProUGUI>();
        LettoreXMLscript= LettoreXMLgb.GetComponent<LettoreXML>();

        (nome_arma, descrizione_arma) = LettoreXMLscript.Lettura_armi(nome_arma, descrizione_arma);
        armi_utilizzabili = LettoreXML.Armi_utilizzabili;

        TextMesH_armi_utilizzabili.text = armi_utilizzabili;
        TextMesH_arma_scelta.text = nome_arma[0];
        TextMesH_descrizione_arma.text = descrizione_arma[0];
    }

    public void armi_utilizzabili_classe(string arma_premuta)
    {
        if(arma_selezionata != arma_premuta)
        {
            switch(arma_premuta)
            {
                case "G17":
                    TextMesH_arma_scelta.text = nome_arma[0];
                    TextMesH_descrizione_arma.text = descrizione_arma[0];
                    selezione_g17.SetActive(true);
                    selezione_c96.SetActive(false);
                    arma_selezionata = "G17";
                    break;

                case "C96":
                    TextMesH_arma_scelta.text = nome_arma[1];
                    TextMesH_descrizione_arma.text = descrizione_arma[1];
                    selezione_c96.SetActive(true);
                    selezione_g17.SetActive(false);
                    arma_selezionata = "C96";
                    break;
            }
        }
    }
   
}
