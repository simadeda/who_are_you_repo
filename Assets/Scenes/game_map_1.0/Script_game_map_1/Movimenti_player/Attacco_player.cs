using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacco_player : MonoBehaviour
{
    public Animator animator;
    float cooldawn_attacco = 0f;
    float fire_rate = 2f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            if (Time.time >= cooldawn_attacco)
            {
                Attacco();
                cooldawn_attacco = Time.time + 1f /fire_rate;
            }
    }
    void Attacco()
    {

        animator.SetTrigger("attacco");
    }
}
