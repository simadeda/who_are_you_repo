using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void GameExit()
    {
        Application.Quit();
        Debug.Log("uscito");
    }

}
