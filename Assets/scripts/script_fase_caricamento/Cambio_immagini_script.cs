using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Cambio_immagini_script : MonoBehaviour
{
    public UnityEngine.GameObject video_img_intermittenza;
    public VideoClip[] clip_video_mappe;
    private VideoPlayer video;

    private void Start()
    {
        video = GetComponent<VideoPlayer>();
    }
   
    public void attiva_intermittenza(string continente)
    {
              
        switch (continente)
        {
            case "Asia":
                {
                    video.clip = clip_video_mappe[0];
                    video.Play();
                }
                break;
            case "America":
                {
                    video.clip = clip_video_mappe[1];
                    video.Play();
                }
                break;
            case "Europa":
                {
                    video.clip = clip_video_mappe[2];
                    video.Play();
                }
                break;
            case "Africa":
                {
                    video.clip = clip_video_mappe[3];
                    video.Play();
                }
                break;
            case "Oceania":
                {
                    video.clip = clip_video_mappe[4];
                    video.Play();
                }
                break;
        }
    }

    public void scambio_immagini(string continente)
    {
       video_img_intermittenza.gameObject.SetActive(true);
       attiva_intermittenza(continente);
    }

}





        
        