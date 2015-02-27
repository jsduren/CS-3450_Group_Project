using UnityEngine;
using System.Collections;

public class enemyAIscript : MonoBehaviour {

	public float jetDistance;
	public float pursuitDistance;
	public float stopPursuitDistance;
	public float range;
	public Transform Jet;
	public float rotationDamping;
	public float chaseStartRange;
	public float movespeed;
	public float shootRate;
	public GameObject shot;
	public Transform shootingOrigin;

	AudioSource UnitAudio;
	private float lastShotTime = float.MinValue;
	// Use this for initialization
	void Start () {
		UnitAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		jetDistance = Vector3.Distance (Jet.position, transform.position);
		if (jetDistance < pursuitDistance) {
			turnToJet();
			if(jetDistance > stopPursuitDistance )
				pursue();
			if(Time.time > lastShotTime + (3.0f / shootRate) && jetDistance <= range){
				UnitAudio.Play();
				Instantiate(shot, shootingOrigin.position, shootingOrigin.rotation);
				lastShotTime = Time.time;
			}
			//InvokeRepeating("LaunchProjectile", 0f, 0.3f);

		}
		/*
		if (jetDistance < 40) {
//			Instantiate(shot, transform.position, transform.rotation);
			if(jetDistance > 10 )
			{

				pursue();
			}
		}*/
	}

	void turnToJet()
	{
		Quaternion rotation = Quaternion.LookRotation (Jet.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation,
		                                       Time.deltaTime * rotationDamping);
	}

	void LaunchProjectile()
	{
		UnitAudio.Play();
		Instantiate(shot, shootingOrigin.position, shootingOrigin.rotation);
	}

	void pursue()
	{
		transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
	}
}
