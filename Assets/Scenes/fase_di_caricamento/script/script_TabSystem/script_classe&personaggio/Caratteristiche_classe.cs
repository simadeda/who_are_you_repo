using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caratteristiche_classe : MonoBehaviour
{
    public GameObject txt_classe, txt_armamento;
    private TextMeshProUGUI TextMesH_classe, TextMesH_armamento;

    string nome_classe;
    string[] tipo_classe = new string[2] { "Assalto", "Supporto" };
    string[] armamento = new string[2] { "Pesante", "Leggero" };

    void Start()
    {
        TextMesH_classe = txt_classe.GetComponent<TextMeshProUGUI>(); //presa componenti
        TextMesH_armamento = txt_armamento.GetComponent<TextMeshProUGUI>();
        nome_classe = LettoreXML.Classe;
        TextMesH_classe.text = nome_classe;

        Nome_classe(nome_classe);
        Armamento(armamento, nome_classe);
    }

    public void Nome_classe(string nome_classe)
    {
        TextMesH_classe.text = nome_classe;
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
                TextMesH_armamento.text = armamento[0];
                break;
        }

    }

    void Tipo_classe()
        {

        }
    
}
