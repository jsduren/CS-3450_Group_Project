using UnityEngine;
using System.Collections;

public class HealthCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && GetComponentInParent<UnitController>().ThisUnit._IsShootable && (other.GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.Shot || other.GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.Missile) && other.GetComponentInParent<UnitController>().ThisUnit._CurTeam != GetComponentInParent<UnitController>().ThisUnit._CurTeam)
        {
            Debug.Log(string.Format("Triggered TakeDamage"));
            GetComponentInParent<UnitController>().ThisUnit.TakeDamage(other.gameObject.GetComponentInParent<UnitController>().ThisUnit._Damage, other.gameObject);
        }
    }
}
