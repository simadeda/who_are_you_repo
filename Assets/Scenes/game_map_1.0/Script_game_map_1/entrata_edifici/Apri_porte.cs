using UnityEngine;

public class Apri_porte : MonoBehaviour
{
    bool Player_rilevato;
    public Carica_scene1 carica_scene;
    
    public void Entra_nell_edificio()
    {      
        if (Player_rilevato != true)
        {
            Player_rilevato = true;
            carica_scene.caricatore_edifici("armeria");
        }
    }
    
   
}


