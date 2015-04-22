using UnityEngine;
using System.Collections;

public class MissileRangeCollider : MonoBehaviour {

    private const string ColliderStr = "MissileRange";
    private const float TimeToInitialize = .25f;
    private float TimeofInitialization;
	// Use this for initialization
	void Start ()
	{
        TimeofInitialization = TimeToInitialize + Time.time;        
	}
	
	// Update is called once per frame
	void Update () {
        if (TimeofInitialization < Time.time && Time.time < TimeofInitialization + TimeToInitialize)
        {
            if (gameObject != null && gameObject.GetComponentInParent<UnitController>() != null && (gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles || gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.Missiles))
            {
                if (gameObject.GetComponentInParent<UnitController>() != null && gameObject.GetComponent<SphereCollider>() != null)
                {
                    gameObject.GetComponent<SphereCollider>().radius = gameObject.GetComponentInParent<UnitController>().ThisUnit._MissileRange;
                }
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && gameObject.GetComponentInParent<UnitController>() != null && other.GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.PlayerPlane && gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTarget == null && other.GetComponentInParent<UnitController>().ThisUnit._IsShootable && other.GetComponentInParent<UnitController>().ThisUnit._CurTeam != gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTeam && (gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles || gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.Missiles))
        {
            gameObject.GetComponentInParent<UnitController>().possibleTarget = other.gameObject;
            //gameObject.GetComponentInParent<UnitController>().ThisUnit.Shoot(other.gameObject, ColliderStr);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && gameObject.GetComponentInParent<UnitController>() != null && other.GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.PlayerPlane && gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTarget == null && other.GetComponentInParent<UnitController>().ThisUnit._IsShootable && other.GetComponentInParent<UnitController>().ThisUnit._CurTeam != gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTeam && (gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles || gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.Missiles))
        {
            gameObject.GetComponentInParent<UnitController>().possibleTarget = other.gameObject;
            //gameObject.GetComponentInParent<UnitController>().ThisUnit.Shoot(other.gameObject, ColliderStr);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && gameObject.GetComponentInParent<UnitController>() != null && other.gameObject == gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTarget)
        {
            gameObject.GetComponentInParent<UnitController>().possibleTarget = null;
            gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTarget = null;
        }
    }
}
