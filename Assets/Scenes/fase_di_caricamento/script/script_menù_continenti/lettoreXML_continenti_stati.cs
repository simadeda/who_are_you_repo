using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml;

public class lettoreXML_continenti_stati : MonoBehaviour
{        
    public void letturaXML_continenti(int num_rnd,out int n_stati,out string nome_continente)
    {
        n_stati = 0;
        nome_continente = "";
        string num_stati_str;

        if (File.Exists("C:\\Users\\simadeda\\Desktop\\documenti di teso\\FILE.XML\\continenti.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("C:\\Users\\simadeda\\Desktop\\documenti di teso\\FILE.XML\\continenti.xml");
                nome_continente = Doc.SelectSingleNode("/continenti/continente[@id='" + num_rnd.ToString() + "']/nome").InnerText;
                num_stati_str = Doc.SelectSingleNode("/continenti/continente[@id='" + num_rnd.ToString() + "']/n_stato").InnerText;
                n_stati = int.Parse(num_stati_str);
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
    } 
    public void letturaXML_stati(int num_rnd, string nome_continente,out string nome_stato_selezionato, out string capitale)
    {
        nome_stato_selezionato = "";
        capitale = "";

        if (File.Exists("C:\\Users\\simadeda\\Desktop\\documenti di teso\\FILE.XML\\stati.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("C:\\Users\\simadeda\\Desktop\\documenti di teso\\FILE.XML\\stati.xml");
                nome_stato_selezionato = Doc.SelectSingleNode("/stati/" + nome_continente + "/stato[@id='" + num_rnd.ToString() + "']/nome").InnerText;
                capitale = Doc.SelectSingleNode("/stati/" + nome_continente + "/stato[@id='" + num_rnd.ToString() + "']/capitale").InnerText;
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
    }

    public void lettura_personaggi(int num_rnd, string nome_continente, string nome_stato)
    {

    }
}
   
