using UnityEngine;
using System.Collections;

public class enemyAIscript : MonoBehaviour {

	public float targetDistance;
	public float pursuitDistance;
	public float stopPursuitDistance;
	public float range;
	public float rotationDamping;
	public float movespeed;
	public float shootRate;
	public GameObject shot;
	public Transform shootingOrigin;
	public GameObject target;
    public float health = 10;

	AudioSource UnitAudio;
	private float lastShotTime = float.MinValue;
	// Use this for initialization
	void Start () {
		UnitAudio = GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider other) 
	{
		if (target != null)
			return;

        if (other!=null && other.GetComponent<ObjectAttributes>() != null && other.GetComponent<ObjectAttributes>().unitType == "Mech") 
			if (transform.GetComponent<ObjectAttributes> ().currentTeam != other.gameObject.GetComponent<ObjectAttributes> ().currentTeam)
			{
				target = other.gameObject;
			}
	}
	void ApplyDamage(int damage)
	{
		health -= damage;
		if (health < 0) {
			Destroy (gameObject);
		}
	}
	void Update()
	{
		if(target==null)return;
		var target2Dposition = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z);
		targetDistance = Vector3.Distance (transform.position, target2Dposition);
		//turn to look
		Quaternion rotation = Quaternion.LookRotation (target2Dposition - transform.position,Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
		//pursue

		if (targetDistance > stopPursuitDistance)
			transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		
		if (Time.time > lastShotTime + (3.0f / shootRate) && targetDistance <= range) {
			UnitAudio.Play ();
			Instantiate (shot, shootingOrigin.position, shootingOrigin.rotation);
			lastShotTime = Time.time;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject != target)
			return;
		target = null;
	}

	void LaunchProjectile()
	{
		UnitAudio.Play();
		var result = (GameObject)Instantiate(shot, shootingOrigin.position, shootingOrigin.rotation);
		var component = result.GetComponent<ObjectAttributes> ();
		component.currentTeam = transform.GetComponent<ObjectAttributes> ().currentTeam;
	}
}
