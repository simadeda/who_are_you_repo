using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Carica_player : MonoBehaviour
{
    private AnimationController animatore_player;
    private GameObject player;
    private Transform player_transform;

    [SerializeField]
    private Barra_vita UI_vita_player;
    [SerializeField]
    private Gestore_classi gestore_classi;
    [SerializeField]
    private CinemachinePixelPerfect CMV_camera;

    private void Awake()
    {
        da_anteprima_a_real_player();
    }
    public void da_anteprima_a_real_player()
    {
        if (gameObject.scene.name != "menù_personaggio")
        {
            player = GameObject.Find("Player");

            player_transform = player.GetComponent<Transform>();
            Health_player vita_player = player.GetComponent<Health_player>();
            vita_player.enabled = true;

            vita_player.Gestore_classi = gestore_classi;
            vita_player.barra_Vita = UI_vita_player;

            animatore_player = player.GetComponent<AnimationController>();
            animatore_player.Anteprima_personaggio = false;

            CMV_camera.VirtualCamera.Follow = player_transform;
                  
            player_transform.localScale = new Vector3(1, 1, 0);
            player_transform.position = new Vector3(0, 0, 0);
        }
    }

}
