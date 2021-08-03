using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Random_number : MonoBehaviour
{
    private int num_rnd;
    public int Rnd(int num_rnd_max)
    {
        num_rnd = Random.Range(0, num_rnd_max);
        return num_rnd;
    }

}

