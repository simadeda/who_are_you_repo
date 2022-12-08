using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class Gestore_indirizzabili : MonoBehaviour
{
    //[SerializeField]
    //private AssetReference player_reference;
    //[SerializeField]
    //private Barra_vita barra_vita_Player;
    //[SerializeField]
    //private Gestore_classi gestore_classi;
    [SerializeField]
    private AssetReference boscaiolo_reference;
    //[SerializeField]
    //private AssetReference La_porta_uguale_pe_tutti;
    [SerializeField]
    private AssetReference armeria;
    //SerializeField]
    //private CinemachineVirtualCamera segui_player;
    [SerializeField]
    private Camera camera_overword;
   
    //private GameObject Player_caricato;
    //private Interazioni Interazioni;

    //carico scene
    static bool smonta_scena_prec = false;
    static private SceneInstance scena_indirizzabile_precedente;
    public static string[] scene_precedenti = new string[2];
          
    string scena_corrente;

    private void Start()
    {
        Addressables.InitializeAsync().Completed += Asset_indispensabili;
    }

    private void Asset_indispensabili(AsyncOperationHandle<IResourceLocator> obj)
    {
        //player_reference.InstantiateAsync().Completed += (Player_completato) =>
        
            //segui_player.Follow = Player_completato.Result.transform;
            //var vita_player = Player_completato.Result.GetComponentInChildren<Health_player>();
           // vita_player.barra_Vita = barra_vita_Player;
            //vita_player.Gestore_classi = gestore_classi;

            //var canvas = Player_completato.Result.GetComponentInChildren<Canvas>();
            //canvas.worldCamera = camera_overword;

            //Player_caricato = Player_completato.Result;

            scena_corrente = SceneManager.GetActiveScene().name;

            switch (scena_corrente)
            {
                case "Mappa_1":
                    Carica_asset_mappa_1();
                    break;

                case "armeria":
                    Carica_asset_armeria();
                    break;
            };
       
             
    }

    private void Carica_asset_armeria()
    {
        //La_porta_uguale_pe_tutti.InstantiateAsync().Completed += (Porta_completata) =>
        //{
            //Transform Oggetto_bambino_porta = Porta_completata.Result.transform.GetChild(0);
            //Interazioni = Oggetto_bambino_porta.GetComponent<Interazioni>();
            //Interazioni.indirizzabili = this;

            //Transform Oggetto_bambino_player = Player_caricato.transform.GetChild(0);
            //Interazioni_playerUI interazione = Oggetto_bambino_player.GetComponent<Interazioni_playerUI>();

            //Interazioni.interazioni_UI = interazione;

            //var rileva_porte = Porta_completata.Result.GetComponent<Rileva_porte>();
            //rileva_porte.indirizzabili = this;
        //};
            boscaiolo_reference.InstantiateAsync();
       
    }

    private void Carica_asset_mappa_1()
    {
        armeria.InstantiateAsync().Completed += (Armeria_esterno_completata) =>
        {
            Transform Oggetto_bambino_armeria = Armeria_esterno_completata.Result.transform.GetChild(0);
            var rileva_porte = Armeria_esterno_completata.Result.GetComponent<Rileva_porte>();
            rileva_porte.indirizzabili = this;

            //Interazioni = Oggetto_bambino_armeria.GetComponent<Interazioni>();

            //Transform Oggetto_bambino_player = Player_caricato.transform.GetChild(0);
            //Interazioni_playerUI interazione = Oggetto_bambino_player.GetComponent<Interazioni_playerUI>();

            //Interazioni.interazioni_UI = interazione;
            //Interazioni.indirizzabili = this;
        };


    }

    public void carica_scene_indirizzabili(string chiave_nome_scena)
    {   
        if(chiave_nome_scena == "porta_uscita_edifici")
        {
            chiave_nome_scena = scene_precedenti[0];
        }
        if (smonta_scena_prec)
        {
            Addressables.UnloadSceneAsync(scena_indirizzabile_precedente).Completed += scena_pulita;
        }
            Addressables.LoadSceneAsync(chiave_nome_scena,UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += scena_caricata;
    }

    private void scena_caricata(AsyncOperationHandle<SceneInstance> scena)
    {
        smonta_scena_prec = true;
        scena_indirizzabile_precedente = scena.Result;
    }

    private void scena_pulita(AsyncOperationHandle<SceneInstance> scena)
    {
        smonta_scena_prec = false;
        scena_indirizzabile_precedente = new SceneInstance();
    }
}


