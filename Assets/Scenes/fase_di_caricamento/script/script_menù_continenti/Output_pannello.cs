using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Output_pannello : MonoBehaviour
{
    public GameObject continente,stato,capitale,num_stati;
    private TextMeshProUGUI textMesH1, textMesH2, textMesH3, textMesH4;
    private void Awake()
    {
        textMesH1 = continente.GetComponent<TextMeshProUGUI>();
        textMesH2 = stato.GetComponent<TextMeshProUGUI>();
        textMesH3 = capitale.GetComponent<TextMeshProUGUI>();
        textMesH4 = num_stati.GetComponent<TextMeshProUGUI>();
    }
    public void Visualizzazione_pannello(string continente_selezionato, string stato_selezionato, string capitale_selezionata, string n_stati)
    {
        textMesH1.text = continente_selezionato;

        textMesH2.text = stato_selezionato;

        textMesH3.text = capitale_selezionata;

        textMesH4.text = n_stati;
    }

}
