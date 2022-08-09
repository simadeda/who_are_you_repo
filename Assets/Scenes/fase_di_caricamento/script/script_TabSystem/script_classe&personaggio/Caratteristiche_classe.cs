using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caratteristiche_classe : MonoBehaviour
{
    public GameObject txt_classe, txt_armamento, txt_tipo, txt_descrizione;
    private TextMeshProUGUI TextMesH_classe, TextMesH_armamento, TextMesH_tipo, TextMesH_descr;

    string nome_classe ,descrizione_classe;
    string[] tipo_classe = new string[3] { "Assalto", "Supporto","Demolitore"};
    string[] armamento = new string[3] { "Pesante", "Leggero","Pesante & Leggero"};

    void Start()
    {
        //presa componenti
        TextMesH_classe = txt_classe.GetComponent<TextMeshProUGUI>(); 
        TextMesH_armamento = txt_armamento.GetComponent<TextMeshProUGUI>();
        TextMesH_tipo = txt_tipo.GetComponent<TextMeshProUGUI>();
        TextMesH_descr = txt_descrizione.GetComponent<TextMeshProUGUI>();

        nome_classe = LettoreXML.Classe;
        descrizione_classe = LettoreXML.Descrizone_classe;
        TextMesH_classe.text = nome_classe;

        Armamento(armamento, tipo_classe, nome_classe, descrizione_classe);
    }
     
    void Armamento(string[] armamento, string[] tipo_classe, string classe, string descrizione_classe)
    {
        switch (classe)
        {
            case "Guerrafondaio":
                TextMesH_armamento.text = armamento[0];
                TextMesH_tipo.text = tipo_classe[0];
                TextMesH_descr.text = descrizione_classe;
                break;

            case "Velocista":
                TextMesH_armamento.text = armamento[1];
                TextMesH_tipo.text = tipo_classe[0];
                TextMesH_descr.text = descrizione_classe;
                break;

            case "Attaccabrighe":
                TextMesH_armamento.text = armamento[1];
                TextMesH_tipo.text = tipo_classe[0];
                TextMesH_descr.text = descrizione_classe;
                break;

            case "Doc":
                TextMesH_armamento.text = armamento[1];
                TextMesH_tipo.text = tipo_classe[1];
                TextMesH_descr.text = descrizione_classe;
                break;

            case "Marksman":
                TextMesH_armamento.text = armamento[0];
                TextMesH_tipo.text = tipo_classe[1];
                TextMesH_descr.text = descrizione_classe;
                break;

            case "Armaiolo":
                TextMesH_armamento.text = armamento[0];
                TextMesH_tipo.text = tipo_classe[1];
                TextMesH_descr.text = descrizione_classe;
                break;

            case "Piromane":
                TextMesH_armamento.text = armamento[2];
                TextMesH_tipo.text = tipo_classe[2];
                TextMesH_descr.text = descrizione_classe;
                break;
        }
    }

}
