using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_player : MonoBehaviour
{ 
    //----#### IMPORTANTISSIMO, QUANDO MUORE IL PLAYER DEVI ASSOLUTAMENTE TOGLIERE LE CARATTERISTICHE ABILITA' DAL PLAYER CHE SONO STATE MESSE PER QUELLA PARTITA!!!! ####-----//
    public Gestore_classi Gestore_classi;
    public int num_max_vita;
    public int num_corrente_vita;
    private int danno = 0;
   
    public Barra_vita barra_Vita;
        
    void Start()
    {
        num_max_vita = Gestore_classi.vita_max_classe;
        num_corrente_vita = num_max_vita;
        barra_Vita.Imposta_vita(num_corrente_vita);
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            danno = 15;
            //qui bisogan mettere un if per verificare se la caratteristica ELUSIONE nelle abilità è attiva oppure no
            //se è attiva qualsiasi danno che il plaeyr riceve verrà messo a 0
            Prendi_danno(danno);
            danno = 0;
        }
    }

    public void Prendi_danno(int danno)
    {
        num_corrente_vita -= danno;
        barra_Vita.Barra_corrente(num_corrente_vita);
    }
}
