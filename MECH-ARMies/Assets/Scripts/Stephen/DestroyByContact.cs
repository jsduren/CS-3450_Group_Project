using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public float health;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player" || other.gameObject.GetType().Name == "Shot2")
		{
			return;
		}

		Destroy(other.gameObject);
		health -= 10;
		if (health == 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			//playerAudio.clip = explosionAudio;
			//playerAudio.volume = setVolume;
			//playerAudio.Play();
		}
	}
}