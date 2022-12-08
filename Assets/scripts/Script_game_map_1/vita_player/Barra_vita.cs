using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_vita : MonoBehaviour
{
    public Slider barra_vita;
    public void Imposta_vita(int num_corrente_vita)
    {
        barra_vita.maxValue = num_corrente_vita;
        barra_vita.value = num_corrente_vita;
    }

    public void Barra_corrente(int num_corrente_vita)
    {
        barra_vita.value = num_corrente_vita;
               
    }

}
