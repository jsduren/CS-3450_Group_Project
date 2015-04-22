using UnityEngine;
using System.Collections;

public class TargetingController : MonoBehaviour {

    private UnitController unitCont;

	// Use this for initialization
	void Start () {
        unitCont = gameObject.GetComponentInParent<UnitController>();
	}
	
	// Update is called once per frame
	void Update () {

        //UnityEngine.Debug.Log(string.Format("Targeting Triggered {0}", _UnitGameObject.transform.position));
        if (unitCont.possibleTarget != null && unitCont.possibleTarget.GetComponent<UnitController>() != null && unitCont.ThisUnit._CurTarget == null)
        {
            if (unitCont.possibleTarget.GetComponent<UnitController>().ThisUnit._CurTeam != unitCont.ThisUnit._CurTeam && unitCont.possibleTarget.GetComponent<UnitController>().ThisUnit._IsShootable && !unitCont.possibleTarget.GetComponent<UnitController>().ThisUnit._IsDead)
            {
                unitCont.ThisUnit._CurTarget = unitCont.possibleTarget;
            }
        }
	}
}
