using System;
using System.IO;
using System.Xml;
using UnityEngine;

public class LettoreXML : MonoBehaviour
{
    public static string Nome_continente, Stato_selezionato, Classe, Abilita_classe, Abilita_stato, Descrizone_abilita_stato, Descrizone_abilita_classe, Descrizone_classe ,Armi_utilizzabili;
    public void LetturaXML_continenti(int num_rnd, out int n_stati, out string nome_continente)
    {
        n_stati = 0;
        nome_continente = "";

        if (File.Exists("Assets/XML/continenti.xml")) // vede se il path è "corretto" e se lo è entra
        {
            try
            {
                XmlDocument Doc = new XmlDocument(); //creazione di una variabile di tipo XmlDocument per lavorare con i file .XML
                Doc.Load("Assets/XML/continenti.xml"); //carica il file continenti.XML
                nome_continente = Doc.SelectSingleNode("/continenti/continente[@id='" + num_rnd.ToString() + "']/nome").InnerText; //tramite la funzione SelectSingleNode e num_rand ( un numero random) vien epreso un continente
                Nome_continente = nome_continente;
                string num_stati_str = Doc.SelectSingleNode("/continenti/continente[@id='" + num_rnd.ToString() + "']/n_stato").InnerText; //stessa cosa del continente ma qui invece per lo stato
                n_stati = int.Parse(num_stati_str); //conversione da string a int
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
    }

    public void LetturaXML_stati(int num_rnd, string nome_continente, out string nome_stato_selezionato, out string capitale)
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

    public void Lettura_abilità_stato(int num_stato, string nome_continente, out string abilita_stato)
    {
        abilita_stato = "";
        string descrizone_abilita_stato = "";
        if (File.Exists("Assets/XML/abilità_stati.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("Assets/XML/abilità_stati.xml");
                abilita_stato = Doc.SelectSingleNode("/abilita_stati/" + nome_continente + "/stato[@id='" + num_stato.ToString() + "']/nome_abilita").InnerText;
                descrizone_abilita_stato = Doc.SelectSingleNode("/abilita_stati/" + nome_continente + "/stato[@id='" + num_stato.ToString() + "']/descrizione").InnerText;
                Abilita_stato = abilita_stato;
                Descrizone_abilita_stato = descrizone_abilita_stato;
            }
            catch(Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
    }

    public (string, string) Lettura_personaggi(int num_rnd, string nome_continente, string nome_stato)
    {
        string Nome_personaggio = " ";
        string Cognome_personaggio = " ";
        if (File.Exists("Assets/XML/personaggi.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("Assets/XML/personaggi.xml");
                Nome_personaggio = Doc.SelectSingleNode("/personaggi/" + nome_continente + "/" + nome_stato + "/personaggio[@id='" + num_rnd.ToString() + "']/nome").InnerText;
                Cognome_personaggio = Doc.SelectSingleNode("/personaggi/" + nome_continente + "/" + nome_stato + "/personaggio[@id='" + num_rnd.ToString() + "']/cognome").InnerText;
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
        return (Nome_personaggio, Cognome_personaggio);
    }

    public void Lettura_abilita_classe(int num_rnd, out string nome_classe, out string abilita_classe)
    {
        abilita_classe = "";
        nome_classe = "";
        string descrizione_classe;
        string descrizione_abilita_classe;
        string armi_utilizzabili;

        if (File.Exists("Assets/XML/abilità_classi.xml"))
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load("Assets/XML/abilità_classi.xml");
                abilita_classe = Doc.SelectSingleNode("/abilita_classi/classe[@id='" + num_rnd.ToString() + "']/nome_abilita").InnerText;
                nome_classe = Doc.SelectSingleNode("/abilita_classi/classe[@id='" + num_rnd.ToString() + "']/nome_classe").InnerText;
                descrizione_classe = Doc.SelectSingleNode("/abilita_classi/classe[@id='" + num_rnd.ToString() + "']/descrizione_classe").InnerText;
                descrizione_abilita_classe = Doc.SelectSingleNode("/abilita_classi/classe[@id='" + num_rnd.ToString() + "']/descrizione_abilita").InnerText;
                armi_utilizzabili = Doc.SelectSingleNode("/abilita_classi/classe[@id='" + num_rnd.ToString() + "']/armamento").InnerText;

                Classe = nome_classe;
                Abilita_classe = abilita_classe;
                Descrizone_abilita_classe = descrizione_abilita_classe;
                Descrizone_classe = descrizione_classe;
                Armi_utilizzabili = armi_utilizzabili;
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }

    }

    public (string[], string[]) Lettura_armi(string[] nome_arma, string[] descrizione_arma)
    {
        int n = 0;
        if (File.Exists("Assets/XML/armi.xml")) // vede se il path è "corretto" e se lo è entra
        {
            try
            {
                XmlDocument Doc = new XmlDocument(); //creazione di una variabile di tipo XmlDocument per lavorare con i file .XML
                Doc.Load("Assets/XML/armi.xml"); //carica il file continenti.XML
                if (Classe == "Attaccabrighe")
                    n = 2;
                for (int i = n; i < n + 2; i++)
                {
                    nome_arma[i] = Doc.SelectSingleNode("/tutte_le_armi/armi_inizio/arma_base[@id='" + i.ToString() + "']/nome_arma").InnerText; //tramite la funzione SelectSingleNode e num_rand ( un numero random) vien epreso un continente
                    descrizione_arma[i] = Doc.SelectSingleNode("/tutte_le_armi/armi_inizio/arma_base[@id='" + i.ToString() + "']/descrizione_arma").InnerText;
                    //nome arma e descrizione arma DEVONO essere array CAPITO?????
                }
            }
            catch (Exception e)
            {
                Debug.Log("errore " + e);
            }
        }
        return (nome_arma, descrizione_arma);
    }
}
