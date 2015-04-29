using UnityEngine;
using System.Collections;

public class GunRangeCollider : MonoBehaviour
{

    private const string ColliderStr = "GunRange";
    private const float TimeToInitialize = .25f;
    private float TimeofInitialization;

	// Use this for initialization
	void Start () {
        TimeofInitialization = TimeToInitialize + Time.time;        
	}
	
	// Update is called once per frame
	void Update () {
        if (TimeofInitialization < Time.time && Time.time < TimeofInitialization + TimeToInitialize)
        {
            if (gameObject.GetComponentInParent<UnitController>() != null && (gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles || gameObject.GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.Guns))
            {
                gameObject.GetComponent<SphereCollider>().radius = gameObject.GetComponentInParent<UnitController>().ThisUnit._GunRange;
            }
        }
	}

    void OnTriggerEnter(Collider otherTarget)
    {

        if (otherTarget.GetComponentInParent<UnitController>() &&
            GetComponentInParent<GunController>() &&
            GetComponentInParent<UnitController>() &&
            otherTarget.GetComponentInParent<UnitController>().ThisUnit._UnitType != UType.PlayerPlane &&
            GetComponentInParent<UnitController>().ThisUnit._CurTarget == null &&
            otherTarget.GetComponentInParent<UnitController>().ThisUnit._IsShootable &&
            otherTarget.GetComponentInParent<UnitController>().ThisUnit._CurTeam !=
            GetComponentInParent<UnitController>().ThisUnit._CurTeam &&
            (GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.Guns ||
                GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles))
        {
            GetComponentInParent<GunController>().Shoot();
        }
    }

    void OnTriggerStay(Collider otherTarget)
    {
        
        if (otherTarget.GetComponentInParent<UnitController>() &&
            GetComponentInParent<GunController>() &&
            GetComponentInParent<UnitController>() &&
            otherTarget.GetComponentInParent<UnitController>().ThisUnit._UnitType != UType.PlayerPlane &&
            GetComponentInParent<UnitController>().ThisUnit._CurTarget == null &&
            otherTarget.GetComponentInParent<UnitController>().ThisUnit._IsShootable &&
            otherTarget.GetComponentInParent<UnitController>().ThisUnit._CurTeam !=
            GetComponentInParent<UnitController>().ThisUnit._CurTeam &&
            (GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.Guns ||
                GetComponentInParent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles))
        {
            GetComponentInParent<GunController>().Shoot();
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        
    }
}
