using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bordi : MonoBehaviour
{
   
    float largezza_sprite = 12.50f;
    Vector2 angolo_destro;
    Vector2 angolo_sinistro;
    Vector2 posizione;
       
    void FixedUpdate()
    {
        posizione = transform.position;

        angolo_destro = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        angolo_sinistro = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        
        angolo_destro.x -= largezza_sprite;
        angolo_destro.y -= largezza_sprite;
        angolo_sinistro.x += largezza_sprite;
        angolo_sinistro.y += largezza_sprite;

        posizione.x = Mathf.Clamp(posizione.x, angolo_sinistro.x, angolo_destro.x);
        posizione.y = Mathf.Clamp(posizione.y, angolo_sinistro.y, angolo_destro.y);
        
        transform.position = posizione;
    }

}
