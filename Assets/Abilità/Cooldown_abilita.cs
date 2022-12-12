using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Cooldown_abilita : MonoBehaviour
{
    public string btn_abilita_classe = "btn_abilit�_classe";
    public string btn_abilita_stato = "btn_abilit�_stato";
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
        inizializza_cooldown(abilita_classe, abilita_stato, player_in_game);
    }

    public void inizializza_cooldown(Abilita abl_classe, Abilita abl_stato, GameObject player_in_game)
    {
        abilita_classe = abl_classe;
        //abilita_stato = abl_stato;
        //abilitySource = GetComponent<AudioSource>();
        cooldown_abl_classe = abilita_classe.cooldown;
        abl_classe.inizializza(player_in_game); //qui vengono attivati tutti i dati relativi all' abilit�

        AbilityReady();
    }

 
    void Update()
    {
        bool coolDownComplete = (Time.time > abl_ready_classe);
        if (coolDownComplete)
        {
            //se � una abilit� di tipo utilizzabile (es con 3 utilizzi), se n'� stato utilizzato 1 il player pu� continuare a
            //premere il tasto finch� gli utilizzi non stanno a 0...quindi ogni volta che l'abilit� sar� pronta bisogna vedere quanti utilizzi sono stati effettuati ed incrementarli se necessario
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
