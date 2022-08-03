using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apri_porte : MonoBehaviour
{
    bool Player_rilevato = false;
    public GameObject Pos_porta,premi_e;
    public Carica_scene1 carica_scene;
    public LayerMask player_mask;
    public float altezza_area;
    public float larghezza_area;

    private void Update()
    {
        Player_rilevato = Physics2D.OverlapBox(Pos_porta.transform.position, new Vector2(larghezza_area, altezza_area),0,player_mask);
      
        if(Player_rilevato == true)
        {
            premi_e.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                carica_scene.caricatore_edifici("edifici");
            }
        }
        else
            premi_e.SetActive(false);
    }
      
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Pos_porta.transform.position, new Vector3(larghezza_area, altezza_area, 1));
    }
}


