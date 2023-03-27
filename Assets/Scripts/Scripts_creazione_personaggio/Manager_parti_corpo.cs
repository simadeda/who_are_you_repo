using System.Collections.Generic;
using UnityEngine;
// codice scrittoda da tutmo (youtube.com/tutmo) 
//reciclato da daniele iapadre per who are you

public class Manager_parti_corpo : MonoBehaviour
{
    // ~~ 1. Updates All Animations to Match Player Selections

    [SerializeField] private SO_corpo_personaggio characterBody;

    // String Arrays
    public GameObject[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;
    private static bool parte_corpo_vuota = false;
    private string partID;
    [HideInInspector] private static int partIndex = 0;
    [HideInInspector] private static string partType;

    // Animation
    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController; //L'ANIMATOR OVERRIDE CONTROLLER PRENDE IL CONTROLLO DELLE ANIMAZIONI, QUINDI NON è PIù L'ANIMATOR A COMANDARE
    private AnimationClipOverrides defaultAnimationClips;
    private static Manager_parti_corpo body_parts_manager;

    private void Start()
    {
        // Set animator
        animator = GetComponent<Animator>();
        body_parts_manager = GetComponent<Manager_parti_corpo>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController; // QUI PRENDE IL CONTROLLO

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);
        defaultAnimationClips.Get_body_parts_override();
        // Set body part animations
        UpdateBodyParts();
    }

    public GameObject[] Get_parti_corpo
    {
        get { return bodyPartTypes; }
    }
    public bool Set_parte_corpo
    {
        set { parte_corpo_vuota = value; }
    }

    public void UpdateBodyParts()
    {
        Debug.Log("entro updatebodyparts");
        int stateindex = 0;
        int directionindex = 0;
        // Override default animation clips with character body parts
        for (partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            // Get current body part
            partType = bodyPartTypes[partIndex].name;
            // Get current body part ID

            //if (characterBody.characterBodyParts[partIndex].bodyPart != null)
            partID = characterBody.parti_corpo_personaggio[partIndex].parte_corpo.ID_animazione_parte_corpo.ToString();
            //else
            //nessuna_parte = true;
            parte_corpo_vuota = false;
            while (stateindex < characterStates.Length && !parte_corpo_vuota)
            {
                string state = characterStates[stateindex];
                while (directionindex < characterDirections.Length && !parte_corpo_vuota)
                {
                    string direction = characterDirections[directionindex];
                    // Get players animation from player body
                    // ***NOTE: Unless Changed Here, Animation Naming Must Be: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_idle_down)
                    animationClip = Resources.Load<AnimationClip>("Animazioni/Animazioni_player/ANIM_" + partType + "/" + partType + "_" + partID + "_" + state + "_" + direction);
                    if (animationClip == null)
                        defaultAnimationClips["parte_corpo_vuota"] = animationClip;//se c'è una parte del corpo che non ha animazione (es senza capelli)
                    else
                        defaultAnimationClips[partType + "_" + 0 + "_" + state + "_" + direction] = animationClip; //override animazione
                    directionindex++;
                }
                stateindex++;
                directionindex = 0;
            }
            stateindex = 0;
        }
        // Apply updated animations
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        private GameObject[] parti_corpo_override;
        public void Get_body_parts_override()
        {
            parti_corpo_override = body_parts_manager.Get_parti_corpo;
        }

        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                Debug.Log("entro animationclip set");
                //1)vedere se l'animazione è != dall' animazione nulla
                //2) stabilire se il gameObj della parte del corpo che sta venendo analizzata è attivo o no
                //2.2)se è uguale all' animazione nulla non fare niente
                //3) se l'animazione è effetivamnete diversa, bisogna attivare il gameObj
                //4)trovare l'index
                //5)override animazione
                bool corpo_corrente_attivo = parti_corpo_override[partIndex].activeInHierarchy;
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                {
                    if (corpo_corrente_attivo == false)
                        parti_corpo_override[partIndex].SetActive(true);
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
                }
                else if (corpo_corrente_attivo == true)
                {
                    parti_corpo_override[partIndex].SetActive(false);
                    body_parts_manager.Set_parte_corpo = true;
                }
            }
        }
    }
}