using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_classi :MonoBehaviour
{
    //private string nome_classe;
    public int vita_classe;

    private void Start()
    {
        //nome_classe = LettoreXML.Classe;
    }
  
    public int Vita_classe
    {
        get { return vita_classe; }
        set { vita_classe = value; }
    }
}
