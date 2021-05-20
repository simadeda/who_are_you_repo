using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Suoni
{
    public string NomeSuono;
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Picco;

    [HideInInspector]
    public AudioSource FonteAudio;
}
