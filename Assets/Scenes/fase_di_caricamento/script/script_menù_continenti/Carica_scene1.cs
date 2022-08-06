using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Carica_scene1 : MonoBehaviour
{
    public void caricatore(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void caricatore_edifici(string scena)
    {
        SceneManager.LoadScene(scena);
    }

}

