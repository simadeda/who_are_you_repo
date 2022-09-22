using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestore_classi : MonoBehaviour
{
    private Base_classi guerrafondaio = new Classe_guerrafondaio();
    private Base_classi armaiolo = new Classe_armaiolo();
    private Base_classi velocista = new Classe_velocista();
    private Base_classi doc = new Classe_doc();
    private Base_classi piromane = new Classe_piromane();
    private Base_classi marksman = new Classe_marksman();
    private Base_classi attacabrighe = new Classe_attaccabrighe();

    public static int vita_max_classe;


    void Start()
    {
        string nome_classe = LettoreXML.Classe;
        switch(nome_classe)
        {
            case "Guerrafondaio":
                Gestore_gerrafondaio();
                break;

            case "Velocista":
                Gestore_velocista();
                break;

            case "Attaccabrighe":
                Gestore_attacabrighe();
                break;
                
            case "Doc":
                Gestore_doc();
                break;

            case "Marksman":
                Gestore_marksman();
                break;

            case "Armaiolo":
                Gestore_armaiolo();
                break;

            case "Piromane":
                Gestore_piromane();
                break;
        }
    }

    private void Gestore_marksman()
    {
        vita_max_classe = marksman.vita_classe;
    }

    private void Gestore_piromane()
    {
        vita_max_classe = piromane.vita_classe;
    }

    private void Gestore_armaiolo()
    {
        vita_max_classe = armaiolo.vita_classe;
    }

    private void Gestore_doc()
    {
        vita_max_classe = doc.vita_classe;
    }

    private void Gestore_attacabrighe()
    {
        vita_max_classe = attacabrighe.vita_classe;
    }

    private void Gestore_velocista()
    {
        vita_max_classe = velocista.vita_classe;
    }

    private void Gestore_gerrafondaio()
    {
        vita_max_classe = guerrafondaio.vita_classe;
    }

   
}
