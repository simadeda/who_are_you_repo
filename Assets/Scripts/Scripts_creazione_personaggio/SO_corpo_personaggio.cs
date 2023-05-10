using UnityEngine;
//codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you

[CreateAssetMenu(fileName = "corpo personaggio", menuName = "Corpo personaggio")]
public class SO_corpo_personaggio : ScriptableObject
{
    //--Contiene dettagli sull'intero corpo del personaggio--
    public BodyPart[] parti_corpo_personaggio;
}

[System.Serializable]
public class BodyPart
{
    public string nome_parte_corpo;
    public SO_parti_corpo_sprite parte_corpo;
}
