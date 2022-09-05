using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rileva_porte : MonoBehaviour
{
    bool Player_rilevato;
    public Carica_scene1 carica_scene;

    public void Edificio_rilevato(string nome_edificio)
    {
        if (Player_rilevato != true)
        {
            Player_rilevato = true;
            carica_scene.caricatore_edifici(nome_edificio);
        }
        else
            Player_rilevato = false;
    }

}
