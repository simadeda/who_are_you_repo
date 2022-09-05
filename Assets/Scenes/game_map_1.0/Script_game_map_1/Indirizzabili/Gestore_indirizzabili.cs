using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;


public class Gestore_indirizzabili : MonoBehaviour
{
    [SerializeField]
    private AssetReference player_reference;
    [SerializeField]
    private AssetReference boscaiolo_reference;
    [SerializeField]
    private AssetReference La_porta_uguale_pe_tutti;
    [SerializeField]
    private CinemachineVirtualCamera segui_player;
    [SerializeField]
    private Camera camera_overword;

    private GameObject Player_caricato;
    private Interazioni Interazioni;

    private void Start()
    {
        Addressables.InitializeAsync().Completed += Gestore_indirizzabili_completato;
    }

    private void Gestore_indirizzabili_completato(AsyncOperationHandle<IResourceLocator> obj)
    {
        player_reference.InstantiateAsync().Completed += player_completato;

        La_porta_uguale_pe_tutti.InstantiateAsync().Completed += porta_completata;

        boscaiolo_reference.InstantiateAsync();
    }

    private void porta_completata(AsyncOperationHandle<GameObject> porta)
    {
        Transform Oggetto_bambino_porta = porta.Result.transform.GetChild(0);
        Interazioni = Oggetto_bambino_porta.GetComponent<Interazioni>();
    }

    private void player_completato(AsyncOperationHandle<GameObject> player)
    {
        segui_player.Follow = player.Result.transform;

        var canvas = player.Result.GetComponentInChildren<Canvas>();
        canvas.worldCamera = camera_overword;

        Player_caricato = player.Result;

        Transform Oggetto_bambino_player = Player_caricato.transform.GetChild(0);
        Interazioni_playerUI interazione = Oggetto_bambino_player.GetComponent<Interazioni_playerUI>();

        Interazioni.interazioni_UI = interazione;
    }

 

   


}


