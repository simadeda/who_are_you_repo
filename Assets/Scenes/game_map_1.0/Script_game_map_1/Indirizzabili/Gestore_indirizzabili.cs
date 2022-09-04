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

    private IEnumerator coroutine;
    private void Start()
    {
        Addressables.InitializeAsync().Completed += Gestore_indirizzabili_completato;
    }

    private void Gestore_indirizzabili_completato(AsyncOperationHandle<IResourceLocator> obj)
    {
        AsyncOperationHandle<GameObject> porta = La_porta_uguale_pe_tutti.InstantiateAsync().Completed += mymethod;

        var player = player_reference.InstantiateAsync();

        coroutine = Prova(porta,player);
        StartCoroutine(coroutine);

        boscaiolo_reference.InstantiateAsync();
    }

    private AsyncOperationHandle<GameObject> mymethod(AsyncOperationHandle<GameObject> obj)
    {
        return obj;
    }

    IEnumerator Prova(AsyncOperationHandle<GameObject> porta, AsyncOperationHandle<GameObject> player)
    {
        Transform bambino = porta.Result.transform.GetChild(0);
        bambino.gameObject.SetActive(false);

        segui_player.Follow = player.Result.transform;

        var canvas = player.Result.GetComponentInChildren<Canvas>();
        canvas.worldCamera = camera_overword;

         
        bambino.gameObject.SetActive(false);

        yield return new WaitForSeconds(10f);

        bambino.gameObject.SetActive(true);
    }


}


