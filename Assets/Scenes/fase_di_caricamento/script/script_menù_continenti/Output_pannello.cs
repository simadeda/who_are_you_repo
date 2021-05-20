using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Output_pannello : MonoBehaviour
{
    public GameObject continente,stato,capitale,num_stati;
    private TextMeshProUGUI textMesH;
    public void Visualizzazione_pannello(string continente_selezionato, string stato_selezionato, string capitale_selezionata, string n_stati)
    {

        textMesH = continente.GetComponent<TextMeshProUGUI>();
        textMesH.text = continente_selezionato;

        textMesH = stato.GetComponent<TextMeshProUGUI>();
        textMesH.text = stato_selezionato;


        textMesH = capitale.GetComponent<TextMeshProUGUI>();
        textMesH.text = capitale_selezionata;

        
        textMesH = num_stati.GetComponent<TextMeshProUGUI>();
        textMesH.text = n_stati;
    
    }

}
