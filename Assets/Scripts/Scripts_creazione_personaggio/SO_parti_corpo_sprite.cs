using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "parte del corpo sprite", menuName = "Parte del corpo sprite")]
public class SO_parti_corpo_sprite : ScriptableObject
{
    //codice scrittoda da tutmo (youtube.com/tutmo) 
    //reciclato da daniele iapadre per who are you
    //--Contiene dettagli su gli sprite di una parte del corpo--
    //GLI SPRITE DEVONO ESSERE GIà ORDINATI 

    // Body Part Details
    public string nome_parte_corpo;
    public int ID_animazione_parte_corpo;
    
    // List Containing All Body Part Animations
    public List<Sprite> tutti_sprite_corpo = new List<Sprite>();

}
