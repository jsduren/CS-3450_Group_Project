using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private float speed = 250.0f;
	public int timer = 60;
    
    void Start ()
    {
        rigidbody.velocity = (transform.forward) * speed;
    }

	void Update()
	{
		timer--;
		if (timer < 0)
			DestroyImmediate (this.gameObject);
	}

	void OnTriggerStay(Collider other) 
	{
		if (timer > 55)return;//this is wrong, figure out a better way to make sure the currentTeam of the bullet is identical to the shooter before this is called
		if (other.GetComponent<ObjectAttributes> ().unitType == "PlayerHunterSeeker" || other.GetComponent<ObjectAttributes> ().unitType == "Mech") 
		//	if (gameObject.GetComponent<UnitAttributes> ().currentTeam != other.gameObject.GetComponent<UnitAttributes> ().currentTeam)
		{
			other.gameObject.SendMessage("ApplyDamage",1);
			Destroy(gameObject);
		}
	}
}
