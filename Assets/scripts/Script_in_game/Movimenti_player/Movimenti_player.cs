using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimenti_player : MonoBehaviour
{
    private float velocita = 10f;
    static float orizzontale_controller = 0;
    static float verticale_controller = 0;
    private new Rigidbody2D rigidbody;
    private Vector3 direzione = new Vector3(0, 0, 0);
    //public CharacterController controlli;
    private Animator animator;
    public Attacco_player attacco;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        direzione = Vector3.zero;
        direzione.x = Input.GetAxisRaw("Horizontal");

        direzione.y = Input.GetAxisRaw("Vertical");
        aggiorna_animazioni_e_movimento();
    }

    private void aggiorna_animazioni_e_movimento()
    {
        if (direzione != Vector3.zero)
        {
            muovi_player();
            animator.SetFloat("orizzontale", direzione.x);
            verticale_controller = direzione.y;
            animator.SetFloat("verticale", direzione.y);
            orizzontale_controller = direzione.x;
            animator.SetBool("si_muove", true);
        }
        else
        {
            Idle();
            animator.SetBool("si_muove", false);
        }
    }

    private void muovi_player()
    {
        rigidbody.MovePosition(transform.position + direzione * velocita * Time.deltaTime);
    }

    /*void Update()
    {
        float spara_hori = Input.GetAxisRaw("Spara_Horizontal");
        float spara_verti = Input.GetAxisRaw("Spara_Vertical");

        if (spara_hori != 0 || spara_verti != 0)
        {
            attacco.Attacco_melee(spara_hori, spara_verti);
        }
    }
    */

    void Idle()
    {
        if (verticale_controller != 0)
        {
            animator.SetFloat("idle_verticale", verticale_controller);
            orizzontale_controller = 0;
            animator.SetFloat("idle_orizzontale", orizzontale_controller);
        }

        if (orizzontale_controller != 0)
        {
            animator.SetFloat("idle_orizzontale", orizzontale_controller);
            verticale_controller = 0;
            animator.SetFloat("idle_verticale", verticale_controller);
        }
    }

    public float Velocita_player
    {
        get { return velocita; }
        set { velocita = value; }
    }
}


