using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Suoni[] ArrSuoni;
   
    void Awake()
    {
       for(int i =0; i< ArrSuoni.Length; i++)
       {
            Suoni s = ArrSuoni[i];
            s.FonteAudio = gameObject.AddComponent<AudioSource>();
            s.FonteAudio.clip = s.Clip;
            s.FonteAudio.volume = s.Volume;
            s.FonteAudio.pitch = s.Picco;
       }
    }
  
    public void PlaySuono(string Nomesuono)
    {
        Suoni s = Array.Find(ArrSuoni, Suoni => Suoni.NomeSuono == Nomesuono);
        s.FonteAudio.Play();
    }

}

