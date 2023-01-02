using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rileva_porte : Manager_scene //far divenatre qusto script un prefab
{
    bool Player_rilevato;
   
    public void Edificio_rilevato(string nome_edificio)
    {

        if (Player_rilevato != true)
        {
            Player_rilevato = true;
            string scena_corrente = SceneManager.GetActiveScene().name;
            Manager_entra_edifici(nome_edificio,scena_corrente);
        }
        else
            Player_rilevato = false;
    }

}
