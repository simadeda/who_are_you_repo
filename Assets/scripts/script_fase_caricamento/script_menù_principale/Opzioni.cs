using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Opzioni : MonoBehaviour
{
    private Cerchio_caricamento cerchio_caricamento;
    public AudioMixer Mixer_main;
    public RectTransform icona_caricamento;
    public GameObject Pannellopzioni,Btn_ok,Sound_icon;
    public Sprite[] Sound_icon_img = new Sprite[2];
    public bool Controllo;
    IEnumerator caricamento_normale;
    public Slider Slider_volume;
    public TMPro.TMP_Dropdown Risoluzioni_disponibili, Qualità_disponibili;
    static int i = 0;

    public Resolution[] Risoluzioni;

    void Start()
    {
        cerchio_caricamento = icona_caricamento.GetComponent<Cerchio_caricamento>();
        float Volume = PlayerPrefs.GetFloat("volume");
        SetVolume(Volume);
    }

    public void Applica()
    {
        icona_caricamento.gameObject.SetActive(true);
        Salvataggio_opzioni();
        caricamento_normale = cerchio_caricamento.Icona_caricamento_normale(icona_caricamento);
        StartCoroutine(caricamento_normale); //caricamento normale corroutine
    }

    public void ShowHide_pannel()
    {
        if (Controllo == false)
        {
            Pannellopzioni.gameObject.SetActive(true);
            RisoluzioneDrop();          
        }
        else
        {
            if (caricamento_normale != null)
                StopCoroutine(caricamento_normale);
            icona_caricamento.gameObject.SetActive(false);
            Pannellopzioni.gameObject.SetActive(false);
        }
                 
    }

    public void Salvataggio_opzioni()
    {
        Risoluzioni_disponibili.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt("valore_risoluzione", Risoluzioni_disponibili.value);
            PlayerPrefs.Save();
        }));

        Qualità_disponibili.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt("valore_qualita", Qualità_disponibili.value);
            PlayerPrefs.Save();
        }));

        i = 0;
    }
    public void RisoluzioneDrop()
    {
        int res_corrente = 0;
        Slider_volume.value = PlayerPrefs.GetFloat("volume", -3f);

        Mixer_main.SetFloat ("volume_menù_principale", PlayerPrefs.GetFloat("volume"));
        
        Qualità_disponibili.value = PlayerPrefs.GetInt("valore_qualita", 3);

        Risoluzioni = Screen.resolutions;

        if(i != Risoluzioni.Length)
        { 
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
        }
        i = 0;
       
    }
    public void Fullscreen(bool Full_scrn)
    {
        Screen.fullScreen = Full_scrn;
    }
    public void QualitaVideo(int Qualità)
    {
        QualitySettings.SetQualityLevel(Qualità);
    }
    public void SetVolume(float Volume)
    {
        PlayerPrefs.SetFloat("volume", Volume);
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
