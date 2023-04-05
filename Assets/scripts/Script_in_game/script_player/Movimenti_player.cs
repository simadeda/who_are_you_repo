using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimenti_player : MonoBehaviour
{
    private float velocita = 10f;

    private Animator animator;

    static float muoviti_orizzontale = 0;
    static float muoviti_verticale = 0;
    private new Rigidbody2D rigidbody;
    private string stato_corrente;
    private string animazione_corrente;

    private Vector3 direzione = new Vector3(0, 0, 0);
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void cambia_stato_player(string nuovo_stato)
    {

    }

    private void Update()
    {
        direzione = Vector3.zero;
        direzione.x = Input.GetAxisRaw("Horizontal");

        direzione.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        //idle
        if (muoviti_verticale != 0)
        {
            animator.SetFloat("idle_verticale", muoviti_verticale);
            muoviti_orizzontale = 0;
            animator.SetFloat("idle_orizzontale", muoviti_orizzontale);
        }

        if (muoviti_orizzontale != 0)
        {
            animator.SetFloat("idle_orizzontale", muoviti_orizzontale);
            muoviti_verticale = 0;
            animator.SetFloat("idle_verticale", muoviti_verticale);
        }

        //camminata
        if (direzione != Vector3.zero)
        {
            muovi_player();
            animator.SetFloat("orizzontale", direzione.x);
            muoviti_verticale = direzione.y;
            animator.SetFloat("verticale", direzione.y);
            muoviti_orizzontale = direzione.x;
            animator.SetBool("si_muove", true);
        }
        else
        {
            animator.SetBool("si_muove", false);
        }
    }

    private void muovi_player()
    {
        rigidbody.MovePosition(transform.position + direzione * velocita * Time.deltaTime);
    }

    public float Velocita_player
    {
        get { return velocita; }
        set { velocita = value; }
    }
}


