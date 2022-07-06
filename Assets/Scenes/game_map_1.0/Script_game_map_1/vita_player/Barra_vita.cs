using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_vita : MonoBehaviour
{
    public int num_max_vita;
    public int num_corrente_vita;
    string nome_classe;

    public Image[] array_hp10;
    public Image[] array_hp12;
    public GameObject barra12;
    public GameObject barra10;

    bool guerrafondaio = false;
    private void barra_vita10()
    {
        if(num_corrente_vita > num_max_vita)
        {
            num_corrente_vita = num_max_vita;
        }

        for (int i = 0; i < array_hp10.Length; i++)
        {
            if (i > num_corrente_vita)
                array_hp10[i].enabled = false;
            else
                array_hp10[i].enabled = true;

            if (num_corrente_vita == 0)
            {
                //player morto
            }

        }
    }

    private void barra_vita12()
    {
        if (num_corrente_vita > num_max_vita)
        {
            num_corrente_vita = num_max_vita;
        }

        for (int i = 0; i < array_hp12.Length; i++)
        {
            if (i > num_corrente_vita)
                array_hp12[i].enabled = false;
            else
                array_hp12[i].enabled = true;

            if (num_corrente_vita == 0)
            {
                //player morto
            }

        }
    }

    private void Start()
    {
        nome_classe = LettoreXML.Classe;
        if(nome_classe == "Guerrafondaio")
        {
            guerrafondaio = true;
            num_max_vita = 12;
            num_corrente_vita = num_max_vita;
            barra10.SetActive(false);
            barra12.SetActive(true);
        }
        else
            {
                num_max_vita = 10;
                num_corrente_vita = 10;
            }
    }

    private void Update()
    {
        if(guerrafondaio)
            barra_vita12();
        else
            barra_vita10();
    }

}
