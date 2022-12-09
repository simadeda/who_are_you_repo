using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carica_scene : Manager_scene
{
    public void caricatore(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void caricatore_string(string scena)
    {
        SceneManager.LoadScene(scena);
    }
}
