using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class carica_scene : MonoBehaviour
{
    public void caricatore(int i)
    {
        SceneManager.LoadScene(i);
    }
}
