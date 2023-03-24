using System.Collections.Generic;
using UnityEngine;
//codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you
[CreateAssetMenu(fileName = "parte del corpo", menuName = "Parte del corpo")]
public class SO_parti_del_corpo : ScriptableObject
{
    //--Contiene dettagli sulle animazioni di una parte del corpo--

    // Body Part Details
    public string nome_parte_corpo;
    public int ID_animazione_parte_corpo;

    // List Containing All Body Part Animations
    public List<AnimationClip> tutte_animazioni_corpo = new List<AnimationClip>();
}