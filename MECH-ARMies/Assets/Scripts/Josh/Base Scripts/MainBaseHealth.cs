using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainBaseHealth : MonoBehaviour {

	public int startingBaseHealth = 1000;
	public int currentBaseHealth;
	public Image damageImage;
	public Slider healthSlider;
	public AudioClip damagedClip;
	public Animator damagedAnimation;
	public GameObject playerObject;
	public Vector3 playerStartingPosition;
	public float timeAfterDamageToEnd = 6f;
	private float timeWhenDamageAnimEnds;

	Animator anim;
	AudioSource baseAudio;
	private bool isDead = false;
	private bool damaged;
	public bool testDamage;
	public int damageDelt;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		baseAudio = GetComponent<AudioSource> ();
		currentBaseHealth = startingBaseHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (testDamage) {
			TakeDamage(damageDelt);
		}

		if (damaged) {
			anim.SetBool ("isDamaged", true);
		}
		if(damaged && timeWhenDamageAnimEnds < Time.time){
			anim.SetBool ("isDamaged", false);
			damaged = false;
		}
	}


	public void TakeDamage(int amount){
		timeWhenDamageAnimEnds = Time.time + timeAfterDamageToEnd;
		damaged = true;
		currentBaseHealth -= amount;
		healthSlider.value = currentBaseHealth;
		baseAudio.Play ();

		if (currentBaseHealth <= 0) {
			isDead = true;
			testDamage = false;
			damaged = false;
		}
		if (isDead) {
			Destroyed();
		}	
	}

	void Destroyed(){
		isDead = true;
		playerObject.GetComponent<Transform>().position = playerStartingPosition;
		anim.SetBool ("isDestroyed", true);
	}
}
