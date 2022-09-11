using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Rileva_porte : MonoBehaviour
{
    bool Player_rilevato;
    public Gestore_indirizzabili indirizzabili;
    static int i = 0;
    int indice = 0; 

    public void Edificio_rilevato(string nome_edificio)
    {
        if (Player_rilevato != true)
        {
            Player_rilevato = true;
            if (i == 2)
                i = 0;

            indice = nome_edificio.IndexOf("(");
            nome_edificio = nome_edificio.Substring(0,indice);
                   
            string scena_corrente = SceneManager.GetActiveScene().name;
            Gestore_indirizzabili.scene_precedenti[i] = scena_corrente;
            i++;

            indirizzabili.carica_scene_indirizzabili(nome_edificio); //parte da vedere quando il palyer è intenzionato ad uscire
        }
        else
            Player_rilevato = false;
    }

}

