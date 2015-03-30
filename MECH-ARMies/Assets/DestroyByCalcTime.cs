using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class DestroyByCalcTime : MonoBehaviour
{
    private float shotRange;
    private float timeToDestroyShot;


	// Use this for initialization
	void Start ()
	{
	    shotRange = gameObject.GetComponent<UnitController>().ThisUnit._GunRange;
	    timeToDestroyShot = Time.time + (shotRange/BaseStaticValues.Shot.Velocity);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time >= timeToDestroyShot)
	    {
	        DestroyImmediate(gameObject);
	    }
	
	}
}
