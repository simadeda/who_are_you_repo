using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_player : MonoBehaviour
{
    public int num_max_vita;
    public int num_corrente_vita;
    int danno = 0;
    string nome_classe;

    public GameObject barra12;
    public GameObject barra10;

    public Barra_vita barra_Vita;

    bool guerrafondaio = false;
      
    void Start()
    {
        nome_classe = LettoreXML.Classe;
        if (nome_classe == "Guerrafondaio") //se è true viene abilitata la barra della vita del guerrafondaio
        {
            guerrafondaio = true;
            num_max_vita = 12;
            num_corrente_vita = num_max_vita;
            barra10.SetActive(false);
            barra12.SetActive(true);
            //barra_Vita.barra_vita12(num_corrente_vita,danno);
        }
        else
        {
            num_max_vita = 10;
            num_corrente_vita = num_max_vita;
            //barra_Vita.barra_vita10(num_corrente_vita,danno);
        }
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            danno = 1;
            Prendi_danno(danno);
            danno = 0;
        }
    }

    void Prendi_danno(int danno)
    {
        if (guerrafondaio == true)
            num_corrente_vita = barra_Vita.barra_vita12(num_corrente_vita, danno);
        else
            num_corrente_vita = barra_Vita.barra_vita10(num_corrente_vita, danno);
    }
}
