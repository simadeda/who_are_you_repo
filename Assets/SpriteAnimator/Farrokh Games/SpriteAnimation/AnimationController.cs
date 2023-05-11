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
	public bool anteprima_personaggio;

	private float velocita = 10f;
	private bool si_muove = false;
	private int arma_equipagiata = 0;

	[SerializeField]
	private new Rigidbody2D rigidbody;

	private Vector3 direzione = new Vector3(0, 0, 0);

	void Awake()
	{
		_animator = GetComponent<IAnimator>();
		_animator.OnTrigger += HandleTrigger;
		_audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		direzione = Vector3.zero;

		direzione.x = Input.GetAxisRaw("Horizontal");
		direzione.y = Input.GetAxisRaw("Vertical");

		animazioni_movimenti_player(direzione.x, direzione.y);
	}

	public void animazioni_movimenti_player(float muoviti_verticale, float muoviti_orizzontale)
    {
		//idle melee corto
		if (muoviti_verticale < 0 && !si_muove && arma_equipagiata == 0)
		{
			_animator.Play("idle_verticale_dietro_melee_corto");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && !si_muove && arma_equipagiata == 0)
		{
			_animator.Play("idle_verticale_avanti_melee_corto");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && !si_muove && arma_equipagiata == 0)
		{
			_animator.Play("idle_orizzontale_sx_melee_corto");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && !si_muove && arma_equipagiata == 0)
		{
			_animator.Play("idle_orizzontale_dx_melee_corto");
			muoviti_verticale = 0;
		}
		//movimento melee corto
		if (muoviti_verticale < 0 && si_muove && arma_equipagiata == 0)
		{
			_animator.Play("camminata_verticale_dietro_melee_corto");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && si_muove && arma_equipagiata == 0)
		{
			_animator.Play("camminata_verticale_avanti_melee_corto");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && si_muove && arma_equipagiata == 0)
		{
			_animator.Play("camminata_idle_orizzontale_sx_melee_corto");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && si_muove && arma_equipagiata == 0)
		{
			_animator.Play("camminata_idle_orizzontale_dx_melee_corto");
			muoviti_verticale = 0;
		}

		//idle pistola
		if (muoviti_verticale < 0 && !si_muove && arma_equipagiata == 1)
		{
			_animator.Play("idle_verticale_dietro_pistola");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && !si_muove && arma_equipagiata == 1)
		{
			_animator.Play("idle_verticale_avanti_pistola");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && !si_muove && arma_equipagiata == 1)
		{
			_animator.Play("idle_orizzontale_sx_pistola");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && !si_muove && arma_equipagiata == 1)
		{
			_animator.Play("idle_orizzontale_dx_pistola");
			muoviti_verticale = 0;
		}
		//muoviti pistola
		if (muoviti_verticale < 0 && si_muove && arma_equipagiata == 1)
		{
			_animator.Play("camminata_verticale_dietro_pistola");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && si_muove && arma_equipagiata == 1)
		{
			_animator.Play("camminata_verticale_avanti_pistola");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && si_muove && arma_equipagiata == 1)
		{
			_animator.Play("camminata_idle_orizzontale_sx_pistola");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && si_muove && arma_equipagiata == 1)
		{
			_animator.Play("camminata_idle_orizzontale_dx_pistola");
			muoviti_verticale = 0;
		}

		//idle arma
		if (muoviti_verticale < 0 && !si_muove && arma_equipagiata == 2)
		{
			_animator.Play("idle_verticale_dietro_arma");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && !si_muove && arma_equipagiata == 2)
		{
			_animator.Play("idle_verticale_avanti_arma");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && !si_muove && arma_equipagiata == 2)
		{
			_animator.Play("idle_orizzontale_sx_arma");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && !si_muove && arma_equipagiata == 2)
		{
			_animator.Play("idle_orizzontale_dx_arma");
			muoviti_verticale = 0;
		}
		//muoviti arma
		if (muoviti_verticale < 0 && si_muove && arma_equipagiata == 2)
		{
			_animator.Play("camminata_verticale_dietro_arma");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && si_muove && arma_equipagiata == 2)
		{
			_animator.Play("camminata_verticale_avanti_arma");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && si_muove && arma_equipagiata == 2)
		{
			_animator.Play("camminata_idle_orizzontale_sx_arma");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && si_muove && arma_equipagiata == 2)
		{
			_animator.Play("camminata_idle_orizzontale_dx_arma");
			muoviti_verticale = 0;
		}

		//idle melee lungo
		if (muoviti_verticale < 0 && !si_muove && arma_equipagiata == 3)
		{
			_animator.Play("idle_verticale_dietro_melee_lungo");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && !si_muove && arma_equipagiata == 3)
		{
			_animator.Play("idle_verticale_avanti_melee_lungo");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && !si_muove && arma_equipagiata == 3)
		{
			_animator.Play("idle_orizzontale_sx_melee_lungo");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && !si_muove && arma_equipagiata == 3)
		{
			_animator.Play("idle_orizzontale_dx_melee_lungo");
			muoviti_verticale = 0;
		}
		//muoviti melee lungo
		if (muoviti_verticale < 0 && si_muove && arma_equipagiata == 3)
		{
			_animator.Play("camminata_verticale_dietro_melee_lungo");
			muoviti_orizzontale = 0;
		}
		if (muoviti_verticale > 0 && si_muove && arma_equipagiata == 3)
		{
			_animator.Play("camminata_verticale_avanti_melee_lungo");
			muoviti_orizzontale = 0;
		}
		if (muoviti_orizzontale < 0 && si_muove && arma_equipagiata == 3)
		{
			_animator.Play("camminata_idle_orizzontale_sx_melee_lungo");
			muoviti_verticale = 0;
		}
		if (muoviti_orizzontale > 0 && si_muove && arma_equipagiata == 3)
		{
			_animator.Play("camminata_idle_orizzontale_dx_melee_lungo");
			muoviti_verticale = 0;
		}
		//se la scena corrente e quella del menù personaggio non andare a muovi_player
		if(!anteprima_personaggio)
			muovi_player();
	}

	private void muovi_player()
	{
		rigidbody.MovePosition(transform.position + direzione * velocita * Time.deltaTime);
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