using System.Collections.Generic;
using UnityEngine;
//codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you
[CreateAssetMenu(fileName = "parte del corpo", menuName = "Parte del corpo")]
public class SO_parti_del_corpo : ScriptableObject
{
    //--Contiene dettagli sulle animazioni di una parte del corpo--

    // Body Part Details
    public string bodyPartName;
    public int bodyPartAnimationID;

    // List Containing All Body Part Animations
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();
}