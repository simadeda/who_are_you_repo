using System.Collections.Generic;
using UnityEngine;
// codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you

public class Manager_parti_corpo : MonoBehaviour
{
    //--Aggiorna tutte le animazioni in modo che corrispondano alle selezioni del giocatore--

    [SerializeField] private SO_corpo_personaggio corpo_personaggio;

    // String Arrays
    [SerializeField] private string[] tipi_parti_corpo;
    [SerializeField] private string[] stato_personaggio;
    [SerializeField] private string[] direzioni_personaggio;
    
    // Animation
    private Animator animator;
    private AnimationClip clip_animazioni;
    private AnimatorOverrideController animazioni_controller_override;
    private AnimazioniClipOverride clip_animazioni_default;

    private void Start()
    {
        // Set animator
        animator = GetComponent<Animator>();
        animazioni_controller_override = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animazioni_controller_override;

        clip_animazioni_default = new AnimazioniClipOverride(animazioni_controller_override.overridesCount);
        animazioni_controller_override.GetOverrides(clip_animazioni_default);

        // Set body part animations
        Aggiorna_parti_corpo();
    }

    public void Aggiorna_parti_corpo()
    {
        // Override default animation clips with character body parts
        for (int i = 0; i < tipi_parti_corpo.Length; i++)
        {
            // Get current body part
            string parte_corpo = tipi_parti_corpo[i];
            // Get current body part ID
            string ID_parte = corpo_personaggio.characterBodyParts[i].bodyPart.bodyPartAnimationID.ToString();

            for (int indice_stato = 0; indice_stato < stato_personaggio.Length; indice_stato++)
            {
                string state = stato_personaggio[indice_stato];
                for (int directionIndex = 0; directionIndex < direzioni_personaggio.Length; directionIndex++)
                {
                    string direzione = direzioni_personaggio[directionIndex];

                    // Get players animation from player body
                    // ***NOTE: Unless Changed Here, Animation Naming Must Be: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_idle_down)
                    clip_animazioni = Resources.Load<AnimationClip>("Animazioni/Animazioni_player/" + parte_corpo + "/" + parte_corpo + "_" + ID_parte + "_" + state + "_" + direzione);

                    // Override default animation
                    clip_animazioni_default[parte_corpo + "_" + 0 + "_" + state + "_" + direzione] = clip_animazioni;
                }
            }
        }
        // Apply updated animations
        animazioni_controller_override.ApplyOverrides(clip_animazioni_default);
    }

    public class AnimazioniClipOverride : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimazioniClipOverride(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}