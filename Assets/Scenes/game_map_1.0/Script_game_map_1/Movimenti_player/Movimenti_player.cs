using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimenti_player : MonoBehaviour
{
    [SerializeField]
    float velocita = 15f;
    static float sx_dx_controller = 0;
    static float dietro_avanti_controller = 0;
    Vector2 direzione = new Vector2(0, 0);
    public CharacterController controlli;
    public Animator animator;
   
    void FixedUpdate()
    {
       direzione.x = Input.GetAxisRaw("Horizontal") * velocita * Time.fixedDeltaTime;
       transform.Translate(direzione * velocita *  Time.fixedDeltaTime);
       animator.SetFloat("verticale", direzione.y);
       dietro_avanti_controller = direzione.y;
       Idle();


       direzione.y = Input.GetAxisRaw("Vertical") * velocita * Time.fixedDeltaTime;
       transform.Translate(direzione * velocita * Time.fixedDeltaTime);
       animator.SetFloat("orizzontale", direzione.x);
       sx_dx_controller = direzione.x;
       Idle();

       animator.SetFloat("velocità",direzione.sqrMagnitude);

    }

    void Idle()
    {
        if(dietro_avanti_controller != 0)
        {
            animator.SetFloat("idle_dietro_avanti", dietro_avanti_controller);
            sx_dx_controller = 0;
            animator.SetFloat("idle_sx_dx", sx_dx_controller);
        }

        if(sx_dx_controller != 0)
        {
            animator.SetFloat("idle_sx_dx", sx_dx_controller);
            dietro_avanti_controller = 0;
            animator.SetFloat("idle_dietro_avanti", dietro_avanti_controller);
        }
            
        
    }
}
