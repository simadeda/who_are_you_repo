using UnityEngine;
using UnityEngine.UI;

// codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you
public class Selettore_parti_corpo : MonoBehaviour
{
    // Full Character Body
    [SerializeField] private SO_corpo_personaggio corpo_personaggio;
    // Body Part Selections
    [SerializeField] private Selezione_parti_corpo[] Selezione_parti_corpo;

    private void Start()
    {
        // Get All Current Body Parts
        for (int i = 0; i < Selezione_parti_corpo.Length; i++)
        {
            GetPartiCorpoCorrenti(i);
        }
    }

    public void ProssimaParteCorpo(int indice_parte_corpo)
    {
        if (ConvalidaNumIdentificativo(indice_parte_corpo))
        {
            if (Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente < Selezione_parti_corpo[indice_parte_corpo].bodyPartOptions.Length - 1)
            {
                Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente++;
            }
            else
            {
                Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente = 0;
            }

            AggiornaParteCorrente(indice_parte_corpo);
        }
    }

    public void CorpoPrecedente(int indice_parte_corpo)
    {
        if (ConvalidaNumIdentificativo(indice_parte_corpo))
        {
            if (Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente > 0)
            {
                Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente--;
            }
            else
            {
                Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente = Selezione_parti_corpo[indice_parte_corpo].bodyPartOptions.Length - 1;
            }

            AggiornaParteCorrente(indice_parte_corpo);
        }    
    }

    private bool ConvalidaNumIdentificativo(int indice_parte_corpo)
    {
        if (indice_parte_corpo > Selezione_parti_corpo.Length || indice_parte_corpo < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetPartiCorpoCorrenti(int indice_parte_corpo)
    {
        // Get Current Body Part Name
        Selezione_parti_corpo[indice_parte_corpo].testo_parte_corpo_componente.text = corpo_personaggio.characterBodyParts[indice_parte_corpo].bodyPart.bodyPartName;
        // Get Current Body Part Animation ID
        Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente = corpo_personaggio.characterBodyParts[indice_parte_corpo].bodyPart.bodyPartAnimationID;
    }

    private void AggiornaParteCorrente(int indice_parte_corpo)
    {
        // Update Selection Name Text
        Selezione_parti_corpo[indice_parte_corpo].testo_parte_corpo_componente.text = Selezione_parti_corpo[indice_parte_corpo].bodyPartOptions[Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente].bodyPartName;
        // Update Character Body Part
        corpo_personaggio.characterBodyParts[indice_parte_corpo].bodyPart = Selezione_parti_corpo[indice_parte_corpo].bodyPartOptions[Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente];
    }
}

[System.Serializable]
public class Selezione_parti_corpo
{
    public string Nome_parte_corpo;
    public SO_parti_del_corpo[] bodyPartOptions;
    public Text testo_parte_corpo_componente;
    [HideInInspector] public int indice_parte_corpo_corrente;
}
