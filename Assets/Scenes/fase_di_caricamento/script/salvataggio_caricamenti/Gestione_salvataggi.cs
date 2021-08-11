using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Gestione_salvataggi 
{
   static string percorso = Application.persistentDataPath + "/Salvataggio.save";  
   public static void Salvataggio(LettoreXML salvataggi_fileXML, int scelta_salvataggio)
   {
        BinaryFormatter formattatore = new BinaryFormatter();     //CREAZIOEN DEL FORMATTATORE IN BINARIO
        FileStream flusso_file = new FileStream(percorso, FileMode.Create);   //CREAZIONE DEL FILE TRAMITE IL PERCORSO
      
        switch(scelta_salvataggio)
        {
            case 0:
                DepositoData salva_carica_cont_stato = new DepositoData(salvataggi_fileXML);  //PRENDE GLI OGETTI DAL COSTRUTTORE DI Cont_stato_prsn_data per rendere tutto più comodo
                formattatore.Serialize(flusso_file, salva_carica_cont_stato);    //IL FORMATTATORE SERIALIZZA (mette in sequenza i dati da Cont_stato_prsn_data) salva_carica_cont_stato
            break;
                            
        }
        flusso_file.Close();   //SI CHIUDE IL TRASFERIMENTO DEI FILE
                
    }

    public static DepositoData Caricamento()
    {
        if(File.Exists(percorso))
        {
            BinaryFormatter formattatore = new BinaryFormatter();
            FileStream flusso_file = new FileStream(percorso, FileMode.Open);
            DepositoData caricamento = formattatore.Deserialize(flusso_file) as DepositoData;
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
