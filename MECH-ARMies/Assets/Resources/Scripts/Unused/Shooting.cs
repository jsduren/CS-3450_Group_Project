using System;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public float speed = 100.0f;
	public int timer = 60;
    private string team;
    
    
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

    //void OnTriggerStay(Collider other)
    //{
    //    if (timer > 55) return;//this is wrong, figure out a better way to make sure the currentTeam of the bullet is identical to the shooter before this is called
    //    if (other != null && other.GetComponent<ObjectAttributes>() != null && other.GetComponent<ObjectAttributes>().unitType == "Mech")
    //    //	if (gameObject.GetComponent<UnitAttributes> ().currentTeam != other.gameObject.GetComponent<UnitAttributes> ().currentTeam)
    //    {
    //        other.gameObject.SendMessage("ApplyDamage", 1);
    //        Destroy(gameObject);
    //    }
    //}


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof (UnitController)))
        {
            UnitController unitController = (UnitController)other.GetComponent(typeof(UnitController));

            if (unitController.curTeam != team)
            {
                unitController.InflictDamage(1);
            }
        }


        
    }*/


}
