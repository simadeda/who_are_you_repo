using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scegli_arma : MonoBehaviour
{
    public GameObject txt_arma_scelta, txt_descrizione_arma, txt_armi_utilizzabili;
    private TextMeshProUGUI TextMesH_arma_scelta, TextMesH_descrizione_arma, TextMesH_armi_utilizzabili;
    void Start()
    {
        TextMesH_arma_scelta = txt_arma_scelta.GetComponent<TextMeshProUGUI>();
        TextMesH_descrizione_arma = txt_descrizione_arma.GetComponent<TextMeshProUGUI>();
        TextMesH_armi_utilizzabili = txt_armi_utilizzabili.GetComponent<TextMeshProUGUI>();


        
    }
   
}
