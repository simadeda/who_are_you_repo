using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Opzioni : MonoBehaviour
{
    public AudioMixer Mixer_main;
    public GameObject Pannellopzioni,Btn_ok,Sound_icon;
    public Sprite[] Sound_icon_img = new Sprite[2];
    public bool Controllo;
    public Slider Slider_volume;
    public TMPro.TMP_Dropdown Risoluzioni_disponibili;
    public TMPro.TMP_Dropdown Qualit�_disponibili;

    public Resolution[] Risoluzioni;

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
    public void Salvataggio_opzioni()
    {
        Risoluzioni_disponibili.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt("valore_risoluzione", Risoluzioni_disponibili.value);
            PlayerPrefs.Save();
        }));

        Qualit�_disponibili.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt("valore_qualita", Qualit�_disponibili.value);
            PlayerPrefs.Save();
        }));
               
    }
    public void RisoluzioneDrop()
    {
        int i, res_corrente =0;
               
        Slider_volume.value = PlayerPrefs.GetFloat("volume", -3f);

        Mixer_main.SetFloat ("volume_men�_principale", PlayerPrefs.GetFloat("volume"));
        
        Qualit�_disponibili.value = PlayerPrefs.GetInt("valore_qualita", 3);

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
        Risoluzioni_disponibili.value = PlayerPrefs.GetInt("valore_risoluzione", res_corrente);

        Salvataggio_opzioni();
    }
    public void Fullscreen(bool Full_scrn)
    {
        Screen.fullScreen = Full_scrn;
    }
    public void QualitaVideo(int Qualit�)
    {
        QualitySettings.SetQualityLevel(Qualit�);
    }
    public void SetVolume(float Volume)
    {
        PlayerPrefs.SetFloat("volume", Volume);
        Mixer_main.SetFloat("volume_men�_principale", Volume);
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
