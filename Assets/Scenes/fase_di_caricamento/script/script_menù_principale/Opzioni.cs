using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Opzioni : MonoBehaviour
{
    public AudioMixer Mixer_main;
    public GameObject Pannellopzioni,Btn_ok,Sound_icon;
    public Sprite[] Sound_icon_img = new Sprite[2];
    public bool Controllo;

    public TMPro.TMP_Dropdown Risoluzioni_disponibili;
    
    Resolution[] Risoluzioni;

    public void ShowHide_pannel()
    {
        if (Controllo == false)
        {
            Pannellopzioni.gameObject.SetActive(true);
            RisoluzioneDrop();          
        }
        else
            Pannellopzioni.gameObject.SetActive(false); 
    }

    public void RisoluzioneDrop()
    {
        int i = 0, res_corrente = 0;

        Risoluzioni = Screen.resolutions;

        Risoluzioni_disponibili.ClearOptions();
        
        List<string> Risoluzioni_str = new List<string>();

        for (i = 0; i < Risoluzioni.Length; i++)
        {
            if (i % 2 == 1)
            {
                string DropdownRisoluzioni = Risoluzioni[i].width + "x" + Risoluzioni[i].height;
                Risoluzioni_str.Add(DropdownRisoluzioni);
            }
            
            if (Risoluzioni[i].width == Screen.currentResolution.width && Risoluzioni[i].height == Screen.currentResolution.height)
            {
                res_corrente = i;
            }
        }
        Risoluzioni_disponibili.AddOptions(Risoluzioni_str);
        Risoluzioni_disponibili.value = res_corrente;
    }
    public void Fullscreen(bool Full_scrn)
    {
        Screen.fullScreen = Full_scrn;
    }
    public void QualitàVideo(int Qualità)
    {
        QualitySettings.SetQualityLevel(Qualità);
    }
    public void SetVolume(float Volume)
    {
        Mixer_main.SetFloat("volume_menù_principale", Volume);
        if (Volume == -80)
        {
            Sound_icon.GetComponent<Image>().sprite = Sound_icon_img[1];
        }
        else
            {
            Sound_icon.GetComponent<Image>().sprite = Sound_icon_img[0];
            }

    }

}
