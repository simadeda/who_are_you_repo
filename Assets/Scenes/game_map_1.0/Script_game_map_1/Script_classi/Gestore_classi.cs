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
    private Base_classi attacabrighe = new Classe_velocista();

    void Start()
    {
        string nome_classe = LettoreXML.Classe;
        switch(nome_classe)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
