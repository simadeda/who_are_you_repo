using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_vita : MonoBehaviour
{
    public Image[] array_hp10;
    public Image[] array_hp12;

    public int barra_vita10(int num_corrente_vita, int danno)
    {
        num_corrente_vita -= danno;
        for (int i = 0; i < array_hp10.Length; i++)
        {
            if (i >= num_corrente_vita)
                array_hp10[i].enabled = false;
            else
                array_hp10[i].enabled = true;
        }
        return num_corrente_vita;
    }

    public int barra_vita12(int num_corrente_vita, int danno)
    {
        num_corrente_vita -= danno;
        for (int i = 0; i < array_hp12.Length; i++)
        {
            if (i > num_corrente_vita)
                array_hp12[i].enabled = false;
            else
                array_hp12[i].enabled = true;
        }
        return num_corrente_vita;
    }

}
