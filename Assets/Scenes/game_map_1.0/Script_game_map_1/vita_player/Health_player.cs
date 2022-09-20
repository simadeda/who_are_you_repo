using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_player : MonoBehaviour
{
    public Base_classi Classe_base;
    public int num_max_vita;
    public int num_corrente_vita;
    int danno = 0;
   
    public Barra_vita barra_Vita;
        
      
    void Start()
    {
        num_max_vita = Classe_base.vita_classe;
        num_corrente_vita = num_max_vita;
        barra_Vita.Imposta_vita(num_corrente_vita);
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            danno = 15;
            Prendi_danno(danno);
            danno = 0;
        }
    }

    void Prendi_danno(int danno)
    {
        num_corrente_vita -= danno;
        barra_Vita.Barra_corrente(num_corrente_vita);
    }
}
