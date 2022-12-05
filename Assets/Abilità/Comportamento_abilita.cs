using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamento_abilita : MonoBehaviour
{
    private Informazioni_base_abilita info_basi;
    private Caratt_tempo_abilita tempo_inizio;

    public Comportamento_abilita(Informazioni_base_abilita ainfo_basi, Caratt_tempo_abilita atempo_inizio)
    {
        info_basi = ainfo_basi;
        tempo_inizio = atempo_inizio;
    }

    public enum Caratt_tempo_abilita { inizio, durante, fine };

    public virtual void comportamento_in_azione(GameObject player)
    {
        Debug.LogError("DEVI DEFINIRE UN COMPORTAMENTO, RICONTROLLA TUTTE LE FUNZIONI DEI COMPORTAMENTI PER LE ABILITA'");
    }

    public Informazioni_base_abilita Info_base_comport_abilita
    {
        get { return info_basi; }
    }

    public Caratt_tempo_abilita comport_abilita_tempo_inizio
    {
        get { return tempo_inizio; }
    }
}
