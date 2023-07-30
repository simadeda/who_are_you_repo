using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Mimetismo_caratteristica : MonoBehaviour
{
    private int durata_mimetismo;
    private UnityEngine.GameObject virtual_cam;
    private CinemachineVirtualCamera camera_in_gioco_attiva;
    private void Awake()
    {
        virtual_cam = UnityEngine.GameObject.Find("CM_vcam");
        camera_in_gioco_attiva = virtual_cam.GetComponent<CinemachineVirtualCamera>();
    }
    public void comportamento_in_azione()
    {
        StartCoroutine(durata_buff_FOV(camera_in_gioco_attiva));
    }
    IEnumerator durata_buff_FOV(CinemachineVirtualCamera camera_in_gioco_attiva)
    {
        camera_in_gioco_attiva.m_Lens.OrthographicSize = 12f;
        yield return new WaitForSeconds(durata_mimetismo);
        camera_in_gioco_attiva.m_Lens.OrthographicSize = 8f;
    }
    public int Durata_mimetismo
    {
        set { durata_mimetismo = value; }
    }

}
