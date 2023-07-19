using UnityEngine;

public class Salva_player : MonoBehaviour
{
    private AnimationController animatore_player;
    private Transform transform;
    private Attiva_disattiva_CMV CMV_cam;
    private Health_player health_Player;
    private GameObject barra_vita_fisica;
 
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void da_anteprima_a_real_player()
    {
        if (gameObject.scene.name != "menù_personaggio")
        {
            animatore_player = gameObject.GetComponent<AnimationController>();
            animatore_player.Anteprima_personaggio = false;

            health_Player = gameObject.GetComponent<Health_player>();
            health_Player.enabled = true;
            barra_vita_fisica = GameObject.Find("Barra_vita");
           // health_Player.barra_Vita = barra_vita_fisica;
            
            CMV_cam.gameObject.SetActive(true);
            CMV_cam.attivaCam();

            transform = gameObject.GetComponent<Transform>();
            transform.localScale = new Vector3(1, 1, 0);

            transform.position = new Vector3(0, 0, 0);
        }
    }
    public Attiva_disattiva_CMV CMV_camera_prop 
    { 
        get { return CMV_cam; } 
        set {; CMV_cam = value; } 
    }
}
