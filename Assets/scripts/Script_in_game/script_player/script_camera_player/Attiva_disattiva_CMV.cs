using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attiva_disattiva_CMV : MonoBehaviour
{
    public Transform player;
    private AnimationController animationController;
    private Salva_player salva_player;
 
    void Awake()
    {
        animationController = player.GetComponent<AnimationController>();
        salva_player = player.GetComponent<Salva_player>();
        salva_player.CMV_camera_prop = this;

        bool ante_personaggio = animationController.Anteprima_personaggio;

        if (ante_personaggio)
            disattivaCam();
        else
            attivaCam();
    }

    public void attivaCam()
    {
        this.gameObject.SetActive(true);
    }

    public void disattivaCam()
    {
        this.gameObject.SetActive(false);
    }

}
