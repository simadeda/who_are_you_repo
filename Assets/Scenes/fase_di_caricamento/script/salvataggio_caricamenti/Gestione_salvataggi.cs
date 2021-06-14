using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Gestione_salvataggi 
{
   static string percorso = Application.persistentDataPath + "/Salvataggio.save";  
   public static void Salvataggio(LettoreXML salvataggio)
   {
        BinaryFormatter formattatore = new BinaryFormatter();           //CREAZIOEN DEL FORMATTATORE IN BINARIO
        Cont_stato_prsn_data salva_carica_cont_stato = new Cont_stato_prsn_data(salvataggio);  //PRENDE GLI OGETTI DAL COSTRUTTORE DI Cont_stato_prsn_data 
                                                                                    //per rendere tutto più comodo
        FileStream flusso_file = new FileStream(percorso, FileMode.Create);         //CREAZIONE DEL FILE TRAMITE IL PERCORSO
        formattatore.Serialize(flusso_file, salva_carica_cont_stato);          //IL FORMATTATORE SERIALIZZA (mette in sequenza i dati da Cont_stato_prsn_data) salva_carica_cont_stato
        flusso_file.Close();        //SI CHIUDE IL TRASFERIMENTO DEI FILE 
   }

    public static Cont_stato_prsn_data Caricamento()
    {
        if(File.Exists(percorso))
        {
            BinaryFormatter formattatore = new BinaryFormatter();
            FileStream flusso_file = new FileStream(percorso, FileMode.Open);
            Cont_stato_prsn_data caricamento = formattatore.Deserialize(flusso_file) as Cont_stato_prsn_data;
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
