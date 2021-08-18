using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancette_script : MonoBehaviour
{
    public RectTransform lancetta_minuti, lancetta_ore;
    float start_time1,start_time2;
    [SerializeField]
    float angolo,velocita_rotazione_ore,velocita_rotazione_minuti;
    void Start()
    {
        start_time1 = Time.time;
        start_time2 = Time.time;
    }
    void FixedUpdate()
    {
        Lancette();
    }

    public void Lancette()
    {
        if (Time.time - start_time1 >= velocita_rotazione_ore)
        {
            //rotazione lancette ore
            Vector3 direzione2 = lancetta_ore.localEulerAngles;

            direzione2.z += angolo; //la direzione che prendono (30°)

            lancetta_ore.localEulerAngles = direzione2;
            start_time1 = Time.time;
        }

        if (Time.time - start_time2 >= velocita_rotazione_minuti)
        {
            //rotazione lancette minuti
            Vector3 direzione1 = lancetta_minuti.localEulerAngles;

            direzione1.z += angolo; //la direzione che prendono (30°)

            lancetta_minuti.localEulerAngles = direzione1;
            start_time2 = Time.time;
        }

    }

}
