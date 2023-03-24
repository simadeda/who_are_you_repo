using UnityEngine;
using UnityEngine.UI;

// codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you
public class Selettore_parti_corpo : MonoBehaviour
{
    // Full Character Body
    [SerializeField] private SO_corpo_personaggio corpo_personaggio;
    [SerializeField] private Caratteristiche_personaggio caratteristiche_personaggio;
    // Body Part Selections
    [SerializeField] private Selezione_parti_corpo[] Selezione_parti_corpo;

    private void Start()
    {
        // Get All Current Body Parts
        for (int index_parte_corpo = 0; index_parte_corpo < Selezione_parti_corpo.Length; index_parte_corpo++)
        {
            scelta_parti_player(index_parte_corpo);
        }
    }

    public void scelta_parti_player(int index)
    {
        int n_rand;
        n_rand = Random_number1.Rnd(Selezione_parti_corpo[index].opzioni_parti_corpo.Length);
        corpo_personaggio.parti_corpo_personaggio[index].parte_corpo = Selezione_parti_corpo[index].opzioni_parti_corpo[n_rand];
    }

    /*
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
*/
    private void GetPartiCorpoCorrenti(int indice_parte_corpo)
    {
        // Get Current Body Part Animation ID
        Selezione_parti_corpo[indice_parte_corpo].indice_parte_corpo_corrente = corpo_personaggio.parti_corpo_personaggio[indice_parte_corpo].parte_corpo.ID_animazione_parte_corpo;
    }

}

[System.Serializable]
public class Selezione_parti_corpo
{
    public string Nome_parte_corpo;
    public SO_parti_del_corpo[] opzioni_parti_corpo;
    [HideInInspector] public int indice_parte_corpo_corrente;
}
