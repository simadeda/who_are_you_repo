using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacco_player : MonoBehaviour
{
    public Animator animator;
    float cooldawn_attacco = 0f;
    float fire_rate = 2f;
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
}
