//==============================================================
// HealthSystem
// HealthSystem.Instance.TakeDamage (float Damage);
// HealthSystem.Instance.HealDamage (float Heal);
// HealthSystem.Instance.UseMana (float Mana);
// HealthSystem.Instance.RestoreMana (float Mana);
// Attach to the Hero.
//==============================================================

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public static HealthSystem Instance;
    public Animator deathAnim;
    public Image currentHealthBar;
	public Image currentHealthGlobe;
	public Text healthText;
	public float hitPoint = 100f;
	public float maxHitPoint = 100f;

	private bool flashActive;
	[SerializeField]
	private float flashLength = 0f;
	private float flashCounter = 0f;
	private SpriteRenderer playerSprite;

	
	public bool Regenerate = true;
	public float regen = 0.1f;
	private float timeleft = 0.0f;	// Left time for current interval
	public float regenUpdateInterval = 1f;

	public bool GodMode;
	public GameObject gameOverScreen;

	void Awake()
	{
		Instance = this;
	}
	
	
  	void Start()
	{
        UpdateGraphics();
        timeleft = regenUpdateInterval;
		playerSprite = GetComponent<SpriteRenderer>();
	}

	
	void Update ()
	{
		if (Regenerate)
			Regen();

		if (flashActive)
		{
			Flash();
		}
	}

	
	private void Regen()
	{
		timeleft -= Time.deltaTime;

		if (timeleft <= 0.0) // Interval ended - update health & mana and start new interval
		{
			// Debug mode
			if (GodMode)
			{
				HealDamage(maxHitPoint);
				//RestoreMana(maxManaPoint);
			}
			else
			{
				HealDamage(regen);
				//RestoreMana(regen);				
			}

			UpdateGraphics();

			timeleft = regenUpdateInterval;
		}
	}

	
	private void UpdateHealthBar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");
	}

	private void UpdateHealthGlobe()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthGlobe.rectTransform.localPosition = new Vector3(0, currentHealthGlobe.rectTransform.rect.height * ratio - currentHealthGlobe.rectTransform.rect.height, 0);
		healthText.text = hitPoint.ToString("0") + "/" + maxHitPoint.ToString("0");
	}

	public void TakeDamage(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;

		UpdateGraphics();

		StartCoroutine(PlayerHurts());
    }

	public void HealDamage(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	public void SetMaxHealth(float max)
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);

		UpdateGraphics();
	}
	
	private void UpdateGraphics()
	{
		UpdateHealthBar();
		UpdateHealthGlobe();
		//UpdateManaBar();
		//UpdateManaGlobe();
	}

	
	IEnumerator PlayerHurts()
	{
		// Player gets hurt. Do stuff.. play anim, sound..
		flashActive = true;
		flashCounter = flashLength;
		//PopupText.Instance.Popup("Ouch!", 1f, 1f); // Demo stuff!
		cinemachinechake.Instance.ShakeCamera(2f, .1f);//camera shake
        Debug.Log("ouch");
		if (hitPoint < 1) // Health is Zero!!
		{
			yield return StartCoroutine(PlayerDied()); // Hero is Dead
		}

		else
			yield return null;
	}

	
	IEnumerator PlayerDied()
	{
		deathAnim.Play("Male_Death");
		SoundManager.PlaySound("Player Death");
		cinemachinechake.Instance.ShakeCamera(3f, .1f);//camera shake
		Debug.Log("Dead");
        yield return new WaitForSeconds(2f);
        gameOverScreen.SetActive(true);

        yield return null;
	}

	public void Flash()
	{
		if (flashCounter > flashLength * .99f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
		}
		else if (flashCounter > flashLength * .82f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
		}
		else if (flashCounter > flashLength * .66f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
		}
		else if (flashCounter > flashLength * .49f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
		}
		else if (flashCounter > flashLength * .33f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
		}
		else if (flashCounter > flashLength * .16f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
		}
		else if (flashCounter > 0f)
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
		}
		else
		{
			playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			flashActive = false;
		}
		flashCounter -= Time.deltaTime;
	}
}
