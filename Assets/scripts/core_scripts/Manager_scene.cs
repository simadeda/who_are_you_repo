using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_scene : MonoBehaviour
{
    private static string[] ultime_scene = new string[2];
    public Rileva_porte rileva_porte;
    public Carica_scene carica_scene;
    static int i = 0;

    public void Manager_entra_edifici(string nome_edificio, string scena_corrente)
    {           
        if (i == 2)
            i = 0; 
        ultime_scene[i] = scena_corrente;
        i++;
        if (nome_edificio == "porta_uscita_edifici")
        {
            string mappa_ritorno = ultime_scene[0];
            
            Manager_cambia_mappa(mappa_ritorno);
        }
        else
            carica_scene.caricatore_string(nome_edificio);
    }

    public void Manager_cambia_mappa(string mappa)
    {
        carica_scene.caricatore_string(mappa);
    }

}
