using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salva_player : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void da_anteprima_a_real_player()
    {
        AnimationController animatore_player;
        Transform transform;

        if (gameObject.scene.name != "menù_personaggio")
        {
            animatore_player = gameObject.GetComponent<AnimationController>();
            animatore_player.anteprima_personaggio = false;

            transform = gameObject.GetComponent<Transform>();
            transform.localScale = new Vector3(1, 1, 0);

            transform.position = new Vector3(0, 0, 0);
        }

    }
}
