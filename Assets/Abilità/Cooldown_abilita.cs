using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Cooldown_abilita : MonoBehaviour
{
    public string btn_abilita_classe = "btn_abilità_classe";
    public string btn_abilita_stato = "btn_abilità_stato";
    public Image darkMask;
    
    [SerializeField] private Abilita abilita_classe;
    [SerializeField] private Abilita abilita_stato;
    [SerializeField] private GameObject player_in_game;

    //private AudioSource abilitySource;

    private float cooldown_abl_classe;
    //private float cooldown_abl_stato;

    private float abl_ready_classe;
    //private float abl_ready_stato;

    private float cooldwon_abl_classe_rimanente;
    //private float cooldwon_abl_stato_rimanente;

    void Start()
    {
        inizializza(abilita_classe, abilita_stato, player_in_game);
    }

    public void inizializza(Abilita abl_classe, Abilita abl_stato, GameObject player_in_game)
    {
        abilita_classe = abl_classe;
        //abilita_stato = abl_stato;
        //abilitySource = GetComponent<AudioSource>();
        cooldown_abl_classe = abilita_classe.cooldown;
        abl_classe.inizializza(player_in_game);

        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > abl_ready_classe);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonDown(btn_abilita_classe))
            {
                ButtonTriggered(player_in_game);
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        cooldwon_abl_classe_rimanente -= Time.deltaTime;
        darkMask.fillAmount = (cooldwon_abl_classe_rimanente / cooldown_abl_classe);
    }

    private void ButtonTriggered(GameObject player_in_game)
    {
        abl_ready_classe = cooldown_abl_classe + Time.time;
        cooldwon_abl_classe_rimanente = cooldown_abl_classe;
        darkMask.enabled = true;
        
        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();
        abilita_classe.TriggerAbility(player_in_game);
    }

}
