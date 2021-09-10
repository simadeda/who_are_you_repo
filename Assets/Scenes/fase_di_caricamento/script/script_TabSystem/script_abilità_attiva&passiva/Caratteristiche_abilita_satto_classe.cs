using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Caratteristiche_abilita_satto_classe : MonoBehaviour
{
    public GameObject abilita_stato, abilita_classe, lettoreXML,img_abilita_classe;
    TextMeshProUGUI textMesh_abilita_stato, textMesh_abilita_classe;
    public Sprite[] arr_abilita_classe = new Sprite[7];
    Image abilita_classe_img;

    void Start()
    {
        textMesh_abilita_stato = abilita_stato.GetComponent<TextMeshProUGUI>();
        textMesh_abilita_classe = abilita_classe.GetComponent<TextMeshProUGUI>();
        abilita_classe_img = img_abilita_classe.GetComponent<Image>();

        Abilita_classe_stato();
    }

    void Abilita_classe_stato()
    {
        string abilita_classe = LettoreXML.Abilita_classe;

        textMesh_abilita_classe.text = abilita_classe;

        switch(abilita_classe)
        {
            case "giubotto pesante":
                abilita_classe_img.sprite = arr_abilita_classe[0];
            break;

            case "schivata":
                abilita_classe_img.sprite = arr_abilita_classe[1];
            break;

            case "spinta":
                abilita_classe_img.sprite = arr_abilita_classe[2];
            break;

            case "cura e via":
                abilita_classe_img.sprite = arr_abilita_classe[3];
            break;

            case "big shot":
                abilita_classe_img.sprite = arr_abilita_classe[4];
            break;

            case "kit supporto":
                abilita_classe_img.sprite = arr_abilita_classe[5];
            break;

            case "tanica":
                abilita_classe_img.sprite = arr_abilita_classe[6];
            break;
        }

    }
    
}
