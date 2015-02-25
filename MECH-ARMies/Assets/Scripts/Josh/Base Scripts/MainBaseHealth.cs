using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainBaseHealth : MonoBehaviour {

	public int startingBaseHealth = 1000;
	public int currentBaseHealth;
	public Image damageImage;
	public Slider healthSlider;
	public AudioClip explosionClip;
	public AudioClip damagedClip;
	public Animation damagedAnimation;
	public GameObject baseExplosion;
	
	Animator anim;
	AudioSource baseAudio;
	bool isDead;
	bool damaged;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		baseAudio = GetComponent<AudioSource> ();
		currentBaseHealth = startingBaseHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			anim.SetTrigger ("Damaged");
			damageImage.enabled = true;
		} else {
			damageImage.enabled = false;
		}
	}


	public void TakeDamage(int amount){
		damaged = true;
		currentBaseHealth -= amount;
		healthSlider.value = currentBaseHealth;
		baseAudio.clip = damagedClip;
		baseAudio.Play ();

		if (currentBaseHealth <= 0 && isDead) {
			Destroyed();
		}	
	}

	void Destroyed(){
		isDead = true;

		anim.SetTrigger ("Explode");

		baseAudio.clip = explosionClip;
		baseAudio.Play ();
	}
}
