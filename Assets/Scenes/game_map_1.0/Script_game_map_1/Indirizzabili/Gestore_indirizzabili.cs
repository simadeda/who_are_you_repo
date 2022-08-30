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
    private Movimento_camera movimento_camera;

    private void Start()
    {
        Addressables.InitializeAsync().Completed += Gestore_indirizzabili_completato;
    }

    private void Gestore_indirizzabili_completato(AsyncOperationHandle<IResourceLocator> obj)
    {
        player_reference.InstantiateAsync().Completed += Player_caricato;

        boscaiolo_reference.InstantiateAsync();
    }

    private void Player_caricato(AsyncOperationHandle<GameObject> obj)
    {
        movimento_camera.player = obj.Result.transform;
    }
}


