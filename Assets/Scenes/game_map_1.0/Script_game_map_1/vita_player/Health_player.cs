using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_player : MonoBehaviour
{
    public int num_max_vita;
    public int num_corrente_vita;
    float danno = 0f;
   
    public Barra_vita barra_Vita;
        
      
    void Start()
    {
        
        
         num_max_vita = 100;
         num_corrente_vita = num_max_vita;
         //barra_Vita.barra_vita10(num_corrente_vita,danno);
        
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

    void Prendi_danno(float danno)
    {
        //num_corrente_vita = barra_Vita.
    }
}
