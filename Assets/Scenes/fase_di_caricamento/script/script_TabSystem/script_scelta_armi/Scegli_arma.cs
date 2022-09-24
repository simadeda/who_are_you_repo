using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scegli_arma : MonoBehaviour
{
    public GameObject txt_arma_scelta, txt_descrizione_arma, txt_armi_utilizzabili,LettoreXMLgb;
    LettoreXML LettoreXMLscript;
    private TextMeshProUGUI TextMesH_arma_scelta, TextMesH_descrizione_arma, TextMesH_armi_utilizzabili;

    private string[] nome_arma = new string[2];
    private string[] descrizione_arma = new string[2];
    void Start()
    {
        TextMesH_arma_scelta = txt_arma_scelta.GetComponent<TextMeshProUGUI>();
        TextMesH_descrizione_arma = txt_descrizione_arma.GetComponent<TextMeshProUGUI>();
        TextMesH_armi_utilizzabili = txt_armi_utilizzabili.GetComponent<TextMeshProUGUI>();
        LettoreXMLscript= LettoreXMLgb.GetComponent<LettoreXML>();

        (nome_arma, descrizione_arma) = LettoreXMLscript.Lettura_armi(nome_arma, descrizione_arma);
        string armi_utilizzabili = LettoreXML.Armi_utilizzabili;
        armi_utilizzabili_classe(armi_utilizzabili,nome_arma,descrizione_arma);
        
    }

    void armi_utilizzabili_classe(string armi_utilizzabili, string[] nome_arma, string[] descrizione_arma)
    {
        TextMesH_armi_utilizzabili.text = armi_utilizzabili;
        TextMesH_arma_scelta.text = nome_arma[0];

    }
   
}
