using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacco_player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    float cooldawn_attacco = 0f;
    float fire_rate = 2f;
    private float spara_hori;
    private float spara_verti;
    private bool isAttackPressed;
    private bool isAttacking;
    private int tipo_arma_equipagiata;

    /*void Update()
    {
      spara_hori = Input.GetAxisRaw("Spara_Horizontal");
      spara_verti = Input.GetAxisRaw("Spara_Vertical");

      if (spara_hori != 0 || spara_verti != 0)
      {
          isAttackPressed = true;
      }
}
*/
    public void Attacco_melee(float spara_h, float spara_v)
    {
         if (Time.time >= cooldawn_attacco)
         {
            Animazione_attacco(spara_h,spara_v);
            cooldawn_attacco = Time.time + 1f /fire_rate;
         }
    }
    void Animazione_attacco(float spara_h, float spara_v)
    {
        animator.SetTrigger("attacco");
        if(spara_h == 1 || spara_h == -1)
        {
            animator.SetFloat("attacco_orizzontale", spara_h);
        }
    }

    private void FixedUpdate()
    {
        //attacco
        /*
        if (isAttackPressed)
        {
            isAttackPressed = false;

            if (!isAttacking)
            {
                isAttacking = true;

         
                    ChangeAnimationState(PLAYER_ATTACK);
                    Invoke("AttackComplete", attackDelay);

            }


        }*/
    }

    void AttackComplete()
    {
        isAttacking = false;
    }
}
