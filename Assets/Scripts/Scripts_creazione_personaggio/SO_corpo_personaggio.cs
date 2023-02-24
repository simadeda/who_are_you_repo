using UnityEngine;
//codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you

[CreateAssetMenu(fileName = "corpo personaggio", menuName = "Corpo personaggio")]
public class SO_corpo_personaggio : ScriptableObject
{
    //--Contiene dettagli sull'intero corpo del personaggio--
    public BodyPart[] characterBodyParts;
}

[System.Serializable]
public class BodyPart
{
    public string bodyPartName;
    public SO_parti_del_corpo bodyPart;
}
