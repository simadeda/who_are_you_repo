using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml;

public class LettoreXML_continenti_stati_personaggio : MonoBehaviour
{
    public string Nome_continente, Stato_selezionato;
    public void letturaXML_continenti(int num_rnd,out int n_stati,out string nome_continente)
    {
        n_stati = 0;
        nome_continente = "";

        if (File.Exists("Assets/XML/continenti.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("Assets/XML/continenti.xml");
                nome_continente = Doc.SelectSingleNode("/continenti/continente[@id='" + num_rnd.ToString() + "']/nome").InnerText;
                Nome_continente = nome_continente;
                string num_stati_str = Doc.SelectSingleNode("/continenti/continente[@id='" + num_rnd.ToString() + "']/n_stato").InnerText;
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
        if (File.Exists("Assets/XML/stati.xml"))
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("Assets/XML/stati.xml");
                nome_stato_selezionato = Doc.SelectSingleNode("/stati/" + nome_continente + "/stato[@id='" + num_rnd.ToString() + "']/nome").InnerText;
                Stato_selezionato = nome_stato_selezionato;
                capitale = Doc.SelectSingleNode("/stati/" + nome_continente + "/stato[@id='" + num_rnd.ToString() + "']/capitale").InnerText;
            }
            catch (Exception e)
            {
              Debug.Log("errore " + e);
            }
        
    }

    public string lettura_personaggi(int num_rnd, string nome_continente, string nome_stato)
    {
        string nome_personaggio = "";
        if (File.Exists("Assets/XML/personaggi.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("Assets / XML / personaggi.xml");
                nome_personaggio = Doc.SelectSingleNode("/personaggi/" + nome_continente + nome_stato + "personaggio[@id='" + num_rnd.ToString()+ "']/nome").InnerText;
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
        return nome_personaggio;
    }
}
   
