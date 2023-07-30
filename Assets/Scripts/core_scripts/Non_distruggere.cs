using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Non_distruggere : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<Non_distruggere>().Length; i++)
        {
            if (Object.FindObjectsOfType<Non_distruggere>()[i] != this)
            {
                if (Object.FindObjectsOfType<Non_distruggere>()[i].name == gameObject.name)
                    Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
