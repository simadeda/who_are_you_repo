using FarrokhGames.SpriteAnimation;
using UnityEngine;

/// <summary>
/// Example class for playing animations, flipping artwork, and playing sounds on triggers
/// </summary>
public class AnimationController : MonoBehaviour
{
	[SerializeField] AudioClip[] _footsteps;

	IAnimator _animator;
	AudioSource _audioSource;
	ISpriteAnimator _spriteAnimator;
	public bool anteprima_personaggio;

	private float velocita = 10f;
	private bool si_muove = true;
	public int arma_equipaggiata = 0;

	[SerializeField]
	private new Rigidbody2D rigidbody;

	private Vector3 direzione = new Vector3(0, 0, 0);
	private Vector3 direzione_idle = new Vector3(0, 0, 0);

	void Awake()
	{
		_animator = GetComponent<IAnimator>();
		_animator.OnTrigger += HandleTrigger;
		_audioSource = GetComponent<AudioSource>();
		_spriteAnimator = _animator as ISpriteAnimator;
	}

	void Update()
	{
		direzione = Vector3.zero;
        
	    direzione.x = Input.GetAxisRaw("Horizontal");
	    direzione.y = Input.GetAxisRaw("Vertical");
		
		if (direzione.x != 0 || direzione.y != 0)
			si_muove = true;
		else
			si_muove = false;

		if(si_muove)
        {
			direzione_idle.x = direzione.x;
			direzione_idle.y = direzione.y;
		}
	
		animazioni_movimenti_player(direzione.x, direzione_idle.x, direzione.y, direzione_idle.y, si_muove);
	}

    private void FixedUpdate()
    {
		//se la scena corrente e quella del menù personaggio non andare a muovi_player
		if (!anteprima_personaggio)
			rigidbody.MovePosition(transform.position + direzione * velocita * Time.deltaTime);
	}

    public void animazioni_movimenti_player(float muoviti_orizzontale, float direzione_idle_orizzontale, float muoviti_verticale, float direzione_idle_verticale, bool si_muove)
    {
		//Debug.Log(muoviti_verticale);
		Debug.Log("porca madonna" + direzione_idle_verticale);
		//Debug.Log(muoviti_orizzontale);
		Debug.Log("dio cane" + direzione_idle_orizzontale);
		 
		//**** idle melee corto ****//
		if (direzione_idle_verticale < 0 && !si_muove && arma_equipaggiata == 0)
			_animator.Play("idle_dietro");
		
		if (direzione_idle_verticale > 0 && !si_muove && arma_equipaggiata == 0)
			_animator.Play("idle_avanti");
		
		if (direzione_idle_orizzontale < 0 && !si_muove && arma_equipaggiata == 0)
		{ 		
			_animator.Play("idle_sx_dx");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale < 0;
		}
		if (direzione_idle_orizzontale > 0 && !si_muove && arma_equipaggiata == 0)
			_animator.Play("idle_sx_dx");
		

		//**** movimento melee corto ****//
		if (muoviti_verticale < 0 && si_muove && arma_equipaggiata == 0) 
	       _animator.Play("camminata_dietro");

		if (muoviti_verticale > 0 && si_muove && arma_equipaggiata == 0)
			_animator.Play("camminata_avanti");
		
		if ((muoviti_orizzontale > 0 || muoviti_orizzontale < 0) && si_muove && arma_equipaggiata == 0)
		{
			_animator.Play("camminata_sx_dx");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale > 0;
		}


		//**** idle pistola ****//
		if (muoviti_verticale < 0 && !si_muove && arma_equipaggiata == 1)
			_animator.Play("idle_con_pistola_avanti");

		if (muoviti_verticale > 0 && !si_muove && arma_equipaggiata == 1)
			_animator.Play("idle_con_pistola_dietro");

		if (direzione_idle_orizzontale < 0 && !si_muove && arma_equipaggiata == 1)
		{
			_animator.Play("idle_con_pistola_sx_dx");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale < 0;
		}
		if (direzione_idle_orizzontale > 0 && !si_muove && arma_equipaggiata == 1)
			_animator.Play("idle_con_pistola_sx_dx");


		//**** muoviti pistola ****//
		if (muoviti_verticale < 0 && si_muove && arma_equipaggiata == 1)
			_animator.Play("camminata_con_pistola_avanti");

		if (muoviti_verticale > 0 && si_muove && arma_equipaggiata == 1)
			_animator.Play("camminata_con_pistola_dietro");
		
		if ((muoviti_orizzontale > 0 || muoviti_orizzontale < 0) && si_muove && arma_equipaggiata == 1)
		{
			_animator.Play("camminata_sx_dx_con_pistola");
			if (_spriteAnimator != null)  _spriteAnimator.Flip = muoviti_orizzontale > 0; 
		}


		//**** idle arma ****//
		if (muoviti_verticale < 0 && !si_muove && arma_equipaggiata == 2)
			_animator.Play("idle_avanti_con_arma");
			
		if (muoviti_verticale > 0 && !si_muove && arma_equipaggiata == 2)
			_animator.Play("idle_dietro_con_arma");
			
		if (direzione_idle_orizzontale < 0 && !si_muove && arma_equipaggiata == 2)
		{
			_animator.Play("idle_sx_dx_con_arma");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale < 0;
		}
		if (direzione_idle_orizzontale > 0 && !si_muove && arma_equipaggiata == 2)
			_animator.Play("idle_sx_dx_con_arma");


		//**** muoviti arma ****//
		if (muoviti_verticale < 0 && si_muove && arma_equipaggiata == 2)
			_animator.Play("camminata_avanti_con_arma");
		
		if (muoviti_verticale > 0 && si_muove && arma_equipaggiata == 2)
			_animator.Play("camminata_dietro_con_arma");

		if ((muoviti_orizzontale > 0 || muoviti_orizzontale < 0) && si_muove && arma_equipaggiata == 2)
		{
			_animator.Play("camminata_sx_dx_con_arma");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale > 0;
		}


		//**** idle melee lungo ****//
		if (muoviti_verticale < 0 && !si_muove && arma_equipaggiata == 3)
			_animator.Play("idle_melee_lunga_dietro");
		
		if (muoviti_verticale > 0 && !si_muove && arma_equipaggiata == 3)
			_animator.Play("idle_melee_lunga_avanti");
		
		if (direzione_idle_orizzontale < 0 && !si_muove && arma_equipaggiata == 3)
		{
			_animator.Play("idle_melee_lunga_sx_dx");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale > 0;
		}
		if (direzione_idle_orizzontale > 0 && !si_muove && arma_equipaggiata == 3)
			_animator.Play("idle_melee_lunga_sx_dx");


		//**** muoviti melee lungo ****//
		if (muoviti_verticale < 0 && si_muove && arma_equipaggiata == 3)
			_animator.Play("camminata_avanti_con_melee_lunga");
		
		if (muoviti_verticale > 0 && si_muove && arma_equipaggiata == 3)
			_animator.Play("camminata_dietro_con_melee_lunga");
	
		if ((muoviti_orizzontale > 0 || muoviti_orizzontale < 0) && si_muove && arma_equipaggiata == 3)
		{
			_animator.Play("camminata_sx_dx_con_arma");
			if (_spriteAnimator != null)
				_spriteAnimator.Flip = muoviti_orizzontale > 0;
		}
	}

	void HandleTrigger(string trigger)
	{
		if (trigger == "footstep")
		{
			if (_footsteps.Length > 0)
			{
				var clip = _footsteps[UnityEngine.Random.Range(0, _footsteps.Length - 1)];
				_audioSource.PlayOneShot(clip);
			}
		}
	}

	public float Velocita_player
	{
		get { return velocita; }
		set { velocita = value; }
	}
}