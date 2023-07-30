using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Abilita_utilizzabili_cooldown : MonoBehaviour
{
    public UnityEngine.GameObject utilizzabili_obj;

    public string btn_attiva_abl_classe = "btn_abilità_classe";

    [HideInInspector] public int count_utilizzabili;
    [HideInInspector] public int max_uti;
    [SerializeField] private Cooldown_abilita_classe cd_abl_classe;
    [SerializeField] private Cooldown_abilita_stato cd_abl_stato;

    private float[] cooldown_abilita_classe_rimanente_uti;
    private float cooldown_abl_classe_rimanente_temp;
    private int fill_ammount_da_completare;
    private int count_fillAmmount = 0;

    int[] arr_fill_ammount;

    private bool coolDownComplete;

    private TextMeshProUGUI txt_utilizzabbili;

    public void UI_utilizzabili_attiva(Abilita abilita_classe)
    {
        utilizzabili_obj.SetActive(true); //attiva il counter degli utilizzabili nello UI
        txt_utilizzabbili = utilizzabili_obj.GetComponent<TextMeshProUGUI>();
        max_uti = abilita_classe.max_utilizzabili; //prende il numero massimo di utilizzabili dalla abilità
        count_utilizzabili = max_uti; 
        arr_fill_ammount = new int[max_uti]; //array per contare quanti fillammount devono essere completati
        cooldown_abilita_classe_rimanente_uti = new float[max_uti];
        txt_utilizzabbili.text = max_uti.ToString();
    }

    //*****#### FUNZIONE CHE VIENE CHIAMATA DALL' UPDATE NELLA CLASSE COOLDOWN_ABILITA_CLASSE ####******//
    public void cooldown_uti(float cooldown_abl_classe ,float cooldown_abl_classe_rimanente, Image darkMask, UnityEngine.GameObject player_in_game, bool cooldown_rimanente_uti_nuovo)
    {
        cooldown_uti_finito(cooldown_abl_classe,cooldown_abl_classe_rimanente,darkMask, cooldown_rimanente_uti_nuovo);
        if (count_utilizzabili != 0)//mettere un' altra condizione che quando count_utilizzabili == 0 bisogna aspettare che gli utilizzi ritornino a 3 altrimenti non è possibile usarla di nuovo 
        {
            if (Input.GetButtonDown(btn_attiva_abl_classe))
            {
                count_utilizzabili--; //diminuisce perchè e stata appena attivata l'abilità
                if (count_utilizzabili <= 1)
                    count_fillAmmount++;

                cd_abl_classe.ButtonTriggered(player_in_game); //quando chiama questa funzione si reca alla classe principale "Cooldown_abilita_classe"
                                                               //e attiva la funzione buttonTrigger che di seguito attiva la funzione "inizio_cooldown_abilita_uti"

                fill_ammount_da_completare = max_uti - count_utilizzabili;
                arr_fill_ammount[count_fillAmmount] = fill_ammount_da_completare; //importante
                txt_utilizzabbili.text = count_utilizzabili.ToString();
            } 
        }
        if (count_utilizzabili == max_uti)
            cd_abl_classe.AbilityReady();
    }

    public void cooldown_uti_finito(float cooldown_abl_classe, float cooldown_abl_classe_rimanente, Image darkMask, bool cooldown_rimanente_uti_nuovo)
    {
        
        coolDownComplete = (cooldown_abl_classe_rimanente_temp <= 0); //controlla se il cooldown è finito
        if (coolDownComplete)
        {
            cooldown_abilita_classe_rimanente_uti[count_fillAmmount] = 0;
            arr_fill_ammount[count_fillAmmount] = 0;

            if (count_utilizzabili != max_uti) //se il coolodown è stato completato, vuol dire che è stata utilizzata l'abilità almeno una volta, e bisogan vedere se il counter per gli utilizzabili è sceso
                count_utilizzabili++;

            if (arr_fill_ammount.Distinct().Count() != 1) //serve per vedere se tutti gli elementi dell' array sonon uguali, ritorna 1 se sono tutti uguali
            {
                darkMask.enabled = true;
                count_fillAmmount--;
                cooldown_abl_classe_rimanente_temp = cooldown_abilita_classe_rimanente_uti[count_fillAmmount]; //viene riasseganto il tempo rimanete perchè il player ha attivato l'abilità più di 1 volta
                cooldown_rimanente_uti_nuovo = false;
                inizio_cooldown_abilita_uti(cooldown_abl_classe, cooldown_abl_classe_rimanente, darkMask, cooldown_rimanente_uti_nuovo);
            }            
            txt_utilizzabbili.text = count_utilizzabili.ToString();
        }
        else
            inizio_cooldown_abilita_uti(cooldown_abl_classe, cooldown_abl_classe_rimanente, darkMask, cooldown_rimanente_uti_nuovo);
    }

    public void inizio_cooldown_abilita_uti(float cooldown_abl_classe, float cooldown_abl_classe_rimanente, Image darkMask, bool cooldown_rimanente_uti_nuovo)
    {
        if (arr_fill_ammount[count_fillAmmount] != 0)//qui ci va tutte le volte che deve riempire il fillammount
        {
            cooldown_abl_classe_rimanente_temp -= Time.deltaTime;
            darkMask.fillAmount = (cooldown_abl_classe_rimanente_temp / cooldown_abl_classe);
        }

        if (cooldown_rimanente_uti_nuovo || arr_fill_ammount[count_fillAmmount] == 0)//qui ci va tutte le volte che l'abilità è stata cliccata piu di 1 volta
        {
            cooldown_abilita_classe_rimanente_uti[count_fillAmmount] = cooldown_abl_classe_rimanente;
            if (cooldown_abl_classe_rimanente_temp <= 0 && !cooldown_rimanente_uti_nuovo)//da vedere bene 
            {
                cooldown_abl_classe_rimanente_temp = cooldown_abilita_classe_rimanente_uti[count_fillAmmount];
            }
        }
    }
}
