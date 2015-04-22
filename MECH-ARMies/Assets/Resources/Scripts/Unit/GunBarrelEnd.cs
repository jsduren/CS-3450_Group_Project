using UnityEngine;
using System.Collections;

public class GunBarrelEnd : MonoBehaviour
{

    public AudioSource shotFiredAudioSource;

	// Use this for initialization
	void Start ()
	{
	    shotFiredAudioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
