using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caratteristiche_abilita_satto_classe : MonoBehaviour
{
    public GameObject abilita_stato, abilita_classe, lettoreXML;
    TextMeshProUGUI textMesh_abilita_stato, textMesh_abilita_classe;
   

    void Start()
    {
        textMesh_abilita_stato = abilita_stato.GetComponent<TextMeshProUGUI>();
        textMesh_abilita_classe = abilita_classe.GetComponent<TextMeshProUGUI>();
        Abilita_classe_stato();

    }

    void Abilita_classe_stato()
    {
        string abilita_classe = LettoreXML.Abilita_classe;

        textMesh_abilita_classe.text = abilita_classe;


    }
    
}
