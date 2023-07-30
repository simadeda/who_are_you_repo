using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Output_pannello : MonoBehaviour
{
    public UnityEngine.GameObject continente,stato,capitale,num_stati,abilita_classe,abilita_stato;
    private TextMeshProUGUI textMesH1, textMesH2, textMesH3, textMesH4, textMesH5, textMesH6;
    private void Awake()
    {
        textMesH1 = continente.GetComponent<TextMeshProUGUI>();
        textMesH2 = stato.GetComponent<TextMeshProUGUI>();
        textMesH3 = capitale.GetComponent<TextMeshProUGUI>();
        textMesH4 = num_stati.GetComponent<TextMeshProUGUI>();
        textMesH5 = abilita_classe.GetComponent<TextMeshProUGUI>();
        textMesH6 = abilita_stato.GetComponent<TextMeshProUGUI>();
    }
    
    public void Visualizzazione_pannello(string continente_selezionato, string stato_selezionato, string capitale_selezionata, string n_stati, string abilita_classe, string abilita_stato)
    {
        textMesH1.text = continente_selezionato;

        textMesH2.text = stato_selezionato;

        textMesH3.text = capitale_selezionata;

        textMesH4.text = n_stati;

        textMesH5.text = abilita_classe;

        textMesH6.text = abilita_stato;
    }

}
