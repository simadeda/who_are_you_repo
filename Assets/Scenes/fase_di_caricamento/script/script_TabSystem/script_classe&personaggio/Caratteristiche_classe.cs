using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caratteristiche_classe : MonoBehaviour
{
    public GameObject txt_classe, txt_armamento, txt_tipo;
    private TextMeshProUGUI TextMesH_classe, TextMesH_armamento, TextMesH_tipo;

    string nome_classe;
    string[] tipo_classe = new string[3] { "Assalto", "Supporto","Demolitore"};
    string[] armamento = new string[3] { "Pesante", "Leggero","Pesante & Leggero"};

    void Start()
    {
        TextMesH_classe = txt_classe.GetComponent<TextMeshProUGUI>(); //presa componenti
        TextMesH_armamento = txt_armamento.GetComponent<TextMeshProUGUI>();
        TextMesH_tipo= txt_tipo.GetComponent<TextMeshProUGUI>();
        nome_classe = LettoreXML.Classe;
        TextMesH_classe.text = nome_classe;
        Armamento(armamento, nome_classe);
        Tipo_classe(tipo_classe,nome_classe);
    }
     
    void Armamento(string[] armamento, string classe)
    {
        switch (classe)
        {
            case "Guerrafondaio":
                TextMesH_armamento.text = armamento[0];
                break;

            case "Velocista":
                TextMesH_armamento.text = armamento[1];
                break;

            case "Attaccabrighe":
                TextMesH_armamento.text = armamento[1];
                break;

            case "Doc":
                TextMesH_armamento.text = armamento[1];
                break;

            case "Marksman":
                TextMesH_armamento.text = armamento[0];
                break;

            case "Armaiolo":
                TextMesH_armamento.text = armamento[0];
                break;

            case "Piromane":
                TextMesH_armamento.text = armamento[2];
                break;
        }
    }

    void Tipo_classe(string[] tipo_classe, string classe)
    {
        switch (classe)
        {
            case "Guerrafondaio":
                TextMesH_tipo.text = tipo_classe[0];
                break;

            case "Velocista":
                TextMesH_tipo.text = tipo_classe[0];
                break;

            case "Attaccabrighe":
                TextMesH_tipo.text = tipo_classe[0];
                break;

            case "Doc":
                TextMesH_tipo.text = tipo_classe[1];
                break;

            case "Marksman":
                TextMesH_tipo.text = tipo_classe[1];
                break;

            case "Armaiolo":
                TextMesH_tipo.text = tipo_classe[1];
                break;

            case "Piromane":
                TextMesH_tipo.text = tipo_classe[2];
                break;
        }
    }
    
}
