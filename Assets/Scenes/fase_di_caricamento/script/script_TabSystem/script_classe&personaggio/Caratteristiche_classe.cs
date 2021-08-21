using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caratteristiche_classe : MonoBehaviour
{
    public GameObject txt_classe;
    private TextMeshProUGUI TextMesH_classe; 
   
    string nome_classe;
    string[] tipo_classe = new string[2] { "Assalto", "Supporto" };
    void Start()
    {
        TextMesH_classe = txt_classe.GetComponent<TextMeshProUGUI>(); //presa componenti
        nome_classe = LettoreXML.Classe;
        TextMesH_classe.text = nome_classe;

    }

    void Tipo_classe()
    {

    }
    
    
}
