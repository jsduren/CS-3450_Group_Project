using UnityEngine;
using System.Collections;

public class TargetingController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (GetComponentInParent<UnitController>() && GetComponentInParent<UnitController>().ThisUnit._CurTarget && (
	        Vector3.Distance(GetComponentInParent<UnitController>().ThisUnit._CurTarget.transform.position,
                GetComponentInParent<UnitController>().transform.position) > GetComponentInParent<UnitController>().ThisUnit._GuardRange || GetComponentInParent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>().ThisUnit._IsDead || !GetComponentInParent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>().ThisUnit._IsShootable))
	    {
	        GetComponentInParent<UnitController>().possibleTarget = null;
	        GetComponentInParent<UnitController>().ThisUnit._CurTarget = null;
	    }

        //UnityEngine.Debug.Log(string.Format("Targeting Triggered {0}", _UnitGameObject.transform.position));
        if (GetComponentInParent<UnitController>().possibleTarget != null && GetComponentInParent<UnitController>().possibleTarget.GetComponent<UnitController>() != null && GetComponentInParent<UnitController>().ThisUnit._CurTarget == null)
        {
            if (GetComponentInParent<UnitController>().possibleTarget.GetComponent<UnitController>().ThisUnit._CurTeam != GetComponentInParent<UnitController>().ThisUnit._CurTeam && GetComponentInParent<UnitController>().possibleTarget.GetComponent<UnitController>().ThisUnit._IsShootable && !GetComponentInParent<UnitController>().possibleTarget.GetComponent<UnitController>().ThisUnit._IsDead)
            {
                GetComponentInParent<UnitController>().ThisUnit._CurTarget = GetComponentInParent<UnitController>().possibleTarget;
            }
        }
	}
}
