using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Gestione_salvataggi 
{
   static string percorso = Application.persistentDataPath + "/Salvataggio.save";  
   public static void Salvataggio(LettoreXML salvataggio_stato_continente, Opzioni salvataggio_opzioni, int scelta_salvataggio)
   {
        BinaryFormatter formattatore = new BinaryFormatter();     //CREAZIOEN DEL FORMATTATORE IN BINARIO
        FileStream flusso_file = new FileStream(percorso, FileMode.Create);   //CREAZIONE DEL FILE TRAMITE IL PERCORSO
      


        SalvataggioData salva_carica_cont_stato = new SalvataggioData(salvataggio_stato_continente);  //PRENDE GLI OGETTI DAL COSTRUTTORE DI Cont_stato_prsn_data per rendere tutto più comodo
        formattatore.Serialize(flusso_file, salva_carica_cont_stato);    //IL FORMATTATORE SERIALIZZA (mette in sequenza i dati da Cont_stato_prsn_data) salva_carica_cont_stato
        flusso_file.Close();   //SI CHIUDE IL TRASFERIMENTO DEI FILE

        SalvataggioData salva_opzioni = new SalvataggioData(salvataggio_opzioni);  //PRENDE GLI OGETTI DAL COSTRUTTORE DI Cont_stato_prsn_data per rendere tutto più comodo
        formattatore.Serialize(flusso_file, salvataggio_opzioni);    //IL FORMATTATORE SERIALIZZA (mette in sequenza i dati da Cont_stato_prsn_data) salva_carica_cont_stato
        flusso_file.Close();   //SI CHIUDE IL TRASFERIMENTO DEI FILE
    }

    public static SalvataggioData Caricamento()
    {
        if(File.Exists(percorso))
        {
            BinaryFormatter formattatore = new BinaryFormatter();
            FileStream flusso_file = new FileStream(percorso, FileMode.Open);
            SalvataggioData caricamento = formattatore.Deserialize(flusso_file) as SalvataggioData;
            flusso_file.Close();     //SI CHIUDE IL TRASFERIMENTO DEI FILE 
            return caricamento;
        }
        else
        {
            Debug.Log("Path non trovato" + percorso);
            return null;
        }  
    }
}
