using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interazioni_playerUI : MonoBehaviour
{
    [SerializeField] private GameObject premi_e;

    public bool attivo = false;
    public void attiva_interazione()
    {
        attivo = true;
        premi_e.SetActive(attivo);
    }

    public void disattiva_interazione()
    {
        attivo = false;
        premi_e.SetActive(attivo);
    }
}
