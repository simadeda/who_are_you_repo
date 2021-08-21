using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caratteristiche_classe : MonoBehaviour
{
    public GameObject txt_classe;
    private TextMeshProUGUI TextMesH_classe;
   
    string nome_classe;
    void Start()
    {
        TextMesH_classe = txt_classe.GetComponent<TextMeshProUGUI>(); //presa componenti
        nome_classe = LettoreXML.Classe;

        Nome_classe(nome_classe);
    }

    public void Nome_classe(string nome_classe)
    {
        TextMesH_classe.text = nome_classe;
    }
    
}
