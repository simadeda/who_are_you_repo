using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocità_aumentata_script : Comportamento_abilita
{
    private const string nome = "velocità aumentata";
    private const Caratt_tempo_abilita tempo_iniziale = Caratt_tempo_abilita.inizio;
    Velocità_aumentata_script() : base(new Informazioni_base_abilita(nome),tempo_iniziale)
    {

    }
}
