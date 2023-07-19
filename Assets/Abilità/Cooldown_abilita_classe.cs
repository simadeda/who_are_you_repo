using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooldown_abilita_classe : MonoBehaviour
{
    public string btn_attiva_abl_classe = "btn_abilità_classe";
    public Image darkMask;

    private bool coolDownComplete;
    [SerializeField] private Abilita abilita_classe;
    [SerializeField] private GameObject player_in_game;
    [SerializeField] private Abilita_utilizzabili_cooldown abl_cla_util;
    
    private bool is_utilizzabile;

    bool cooldown_rimanente_uti_nuovo;

    private float cooldown_abl_classe;
   
    private float abl_classe_prx_tempo_pronto;
 
    private float cooldown_classe_rimanente;

    void Awake()
    {
        player_in_game = GameObject.Find("Player");

        is_utilizzabile = abilita_classe.utilizzabili;
        if (is_utilizzabile)
        {
            abl_cla_util.GetComponent<Abilita_utilizzabili_cooldown>();
            abl_cla_util.UI_utilizzabili_attiva(abilita_classe);
        }
        inizializza_cooldown(abilita_classe, player_in_game);
    }

    public void inizializza_cooldown(Abilita abl_classe, GameObject player_in_game)
    {
        abilita_classe = abl_classe;
        //abilitySource = GetComponent<AudioSource>();
        cooldown_abl_classe = abilita_classe.cooldown;
        abl_classe.inizializza(player_in_game); //***********#### qui vengono attivati tutti i dati relativi all' abilità ####*********//

        AbilityReady();
    }

    void Update()
    {
        if (is_utilizzabile)
            abl_cla_util.cooldown_uti(cooldown_abl_classe, cooldown_classe_rimanente,darkMask,player_in_game, cooldown_rimanente_uti_nuovo);
        else
        {
            coolDownComplete = (Time.time >= abl_classe_prx_tempo_pronto);
            if (coolDownComplete)
            {
                AbilityReady();
                if (Input.GetButtonDown(btn_attiva_abl_classe))
                {
                    ButtonTriggered(player_in_game);
                }
            }
            else
            {
                CoolDown();
            }
        }
    }
    public void AbilityReady()
    {
        darkMask.enabled = false;
    }
    public void CoolDown()
    {
        cooldown_classe_rimanente -= Time.deltaTime;
        darkMask.fillAmount = (cooldown_classe_rimanente / cooldown_abl_classe);
    }
    public void ButtonTriggered(GameObject player_in_game)
    {
        cooldown_rimanente_uti_nuovo = false;
        if (!darkMask.enabled)
            darkMask.enabled = true;
        else
            cooldown_rimanente_uti_nuovo = true;
        abl_classe_prx_tempo_pronto = cooldown_abl_classe + Time.time;
        cooldown_classe_rimanente = cooldown_abl_classe;

        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();

        if (is_utilizzabile)
        {
           abl_cla_util.inizio_cooldown_abilita_uti(cooldown_abl_classe, cooldown_classe_rimanente, darkMask, cooldown_rimanente_uti_nuovo);
        }
        abilita_classe.TriggerAbility(player_in_game);        
    }

}
