using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Caratteristiche_abilita_stato_classe : MonoBehaviour
{
    public UnityEngine.GameObject txt_abilita_stato, txt_abilita_classe, lettoreXML,img_abilita_classe,img_abilita_stato,descrizione_abilità_stato,descrizione_abilità_classe;
    TextMeshProUGUI textMesh_abilita_stato, textMesh_abilita_classe, textMesh_desc_abilita_classe, textMesh_desc_abilita_stato;
    public Sprite[] arr_abilita_classe = new Sprite[7];
    public Sprite[] arr_abilita_stato = new Sprite[18];
    Image abilita_classe_img;
    Image abilita_stato_img;

    string abilita_classe, abilita_stato, desc_abl_stato, desc_abl_classe;
    void Start()
    {
        textMesh_abilita_stato = txt_abilita_stato.GetComponent<TextMeshProUGUI>();
        textMesh_abilita_classe = txt_abilita_classe.GetComponent<TextMeshProUGUI>();
        textMesh_desc_abilita_classe = descrizione_abilità_classe.GetComponent<TextMeshProUGUI>();
        textMesh_desc_abilita_stato = descrizione_abilità_stato.GetComponent<TextMeshProUGUI>();

        abilita_classe_img = img_abilita_classe.GetComponent<Image>();
        abilita_stato_img = img_abilita_stato.GetComponent<Image>();

        abilita_classe = LettoreXML.Abilita_classe;
        abilita_stato = LettoreXML.Abilita_stato;
        desc_abl_classe = LettoreXML.Descrizone_abilita_classe;
        desc_abl_stato = LettoreXML.Descrizone_abilita_stato;

        textMesh_abilita_classe.text = abilita_classe;
        textMesh_abilita_stato.text = abilita_stato;
        textMesh_desc_abilita_classe.text = desc_abl_classe;
        textMesh_desc_abilita_stato.text = desc_abl_stato;


        Abilita_classe_stato(abilita_classe, abilita_stato);
    }

    void Abilita_classe_stato(string abilita_classe, string abilita_stato)
    {
        

        switch (abilita_classe)
        {
            case "Scudo Balistico":
                abilita_classe_img.sprite = arr_abilita_classe[0];
            break;

            case "Schivata":
                abilita_classe_img.sprite = arr_abilita_classe[1];
            break;

            case "Spinta":
                abilita_classe_img.sprite = arr_abilita_classe[2];
            break;

            case "Cura e Via":
                abilita_classe_img.sprite = arr_abilita_classe[3];
            break;

            case "Big Shot":
                abilita_classe_img.sprite = arr_abilita_classe[4];
            break;

            case "Kit Supporto":
                abilita_classe_img.sprite = arr_abilita_classe[5];
            break;

            case "Tanica":
                abilita_classe_img.sprite = arr_abilita_classe[6];
            break;
        }

        switch(abilita_stato)
        {
            case "Kord":
                abilita_stato_img.sprite = arr_abilita_stato[0];
                break;

            case "Shaolinquan":
                abilita_stato_img.sprite = arr_abilita_stato[1];
                break;

            case "Bomba al Nokia":
                abilita_stato_img.sprite = arr_abilita_stato[2];
                break;

            case "Carica Regale":
                abilita_stato_img.sprite = arr_abilita_stato[3];
                break;

            case "Samurai":
                abilita_stato_img.sprite = arr_abilita_stato[4];
                break;

            case "Libertà":
                abilita_stato_img.sprite = arr_abilita_stato[5];
                break;

            case "La Marioneta":
                abilita_stato_img.sprite = arr_abilita_stato[6];
                break;
            case "Bolas":
                abilita_stato_img.sprite = arr_abilita_stato[7];
                break;

            case "Macumba":
                abilita_stato_img.sprite = arr_abilita_stato[8];
                break;

            case "Vichingo":
                abilita_stato_img.sprite = arr_abilita_stato[9];
                break;

            case "Spitfire":
                abilita_stato_img.sprite = arr_abilita_stato[10];
                break;

            case "La Famiglia":
                abilita_stato_img.sprite = arr_abilita_stato[11];
                break;

            case "Vetro Albanese":
                abilita_stato_img.sprite = arr_abilita_stato[12];
                break;

            case "Furia degli Dei":
                abilita_stato_img.sprite = arr_abilita_stato[13];
                break;
            case "Luna Zayana":
                abilita_stato_img.sprite = arr_abilita_stato[14];
                break;

            case "Afa del Deserto":
                abilita_stato_img.sprite = arr_abilita_stato[15];
                break;

            case "Rugby":
                abilita_stato_img.sprite = arr_abilita_stato[16];
                break;

            case "Forza Animale":
                abilita_stato_img.sprite = arr_abilita_stato[17];
                break;
        }

    }
    
}
