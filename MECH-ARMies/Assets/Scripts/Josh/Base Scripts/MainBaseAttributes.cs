using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainBaseAttributes : MonoBehaviour {
	public bool setTeam;		// True = Team 1  False = Team 2
	public bool currentTeam; 	// True = Team 1  False = Team 2
	public int startingBaseHealth = 1000;
	public int currentBaseHealth;
	public Image damageImage;
	public Slider healthSlider;
	public AudioClip explosionClip;

	Animator anim;
	AudioSource baseDamagedAudio;
	bool isDead;
	bool damaged;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		baseDamagedAudio = GetComponent<AudioSource> ();
		currentBaseHealth = startingBaseHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.enabled = true;
		}
	}
}
