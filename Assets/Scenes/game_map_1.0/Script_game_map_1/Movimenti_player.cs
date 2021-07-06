using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimenti_player : MonoBehaviour
{
    [SerializeField]
    float velocita = 5f;
    Vector2 direzione = new Vector2(0, 0);
    public CharacterController controlli;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
              
       direzione.x = Input.GetAxisRaw("Horizontal") * velocita * Time.fixedDeltaTime;
       transform.Translate(direzione * velocita * Time.fixedDeltaTime);
        

     
    }
}
