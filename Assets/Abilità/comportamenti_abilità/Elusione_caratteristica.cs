using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elusione_caratteristica : Comportamento_abilita
{
    private const string nome = "elusione";
    private const Caratt_tempo_abilita tempo_inizio = Caratt_tempo_abilita.inizio;
    Elusione_caratteristica() : base (new Informazioni_base_abilita(nome), tempo_inizio)
    {

    }
}
