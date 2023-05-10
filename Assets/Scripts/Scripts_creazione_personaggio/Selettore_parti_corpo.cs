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

    public void scelta_occhi_player(int index)
    {
        string occhi_player = "occhi_";
        int occhi_index;
        occhi_player += caratteristiche_personaggio.Get_occhi;
        for (occhi_index = 0; occhi_index < Selezione_parti_corpo[index].opzioni_parti_corpo.Length; occhi_index++)
        {
            if (occhi_player.Equals(Selezione_parti_corpo[index].opzioni_parti_corpo[occhi_index].nome_parte_corpo))
            {
                corpo_personaggio.parti_corpo_personaggio[index].parte_corpo = Selezione_parti_corpo[index].opzioni_parti_corpo[occhi_index];
                break;
            }
        }
    }
    public void scelta_capelli_player(int index)
    {
        string capelli_player = "capelli_";
        int capelli_index;
        capelli_player += caratteristiche_personaggio.Get_occhi;
        for (capelli_index = 0; capelli_index < Selezione_parti_corpo[index].opzioni_parti_corpo.Length; capelli_index++)
        {
            if (capelli_player.Equals(Selezione_parti_corpo[index].opzioni_parti_corpo[capelli_index].nome_parte_corpo))
            {
                corpo_personaggio.parti_corpo_personaggio[index].parte_corpo = Selezione_parti_corpo[index].opzioni_parti_corpo[capelli_index];
                break;
            }
        }
    }

    public void scelta_parti_player(int index)
    {
        if (Selezione_parti_corpo[index].Nome_parte_corpo == "Occhi")
            scelta_occhi_player(index);

        if (Selezione_parti_corpo[index].Nome_parte_corpo == "Capelli")
            scelta_capelli_player(index);

        int n_rand;
        n_rand = Random_number1.Rnd(Selezione_parti_corpo[index].opzioni_parti_corpo.Length);
        corpo_personaggio.parti_corpo_personaggio[index].parte_corpo = Selezione_parti_corpo[index].opzioni_parti_corpo[n_rand];
    }
}

[System.Serializable]
public class Selezione_parti_corpo
{
    public string Nome_parte_corpo;
    public SO_parti_corpo_sprite[] opzioni_parti_corpo;
    [HideInInspector] public int indice_parte_corpo_corrente;
}
