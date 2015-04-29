using UnityEngine;
using System.Collections;

public class LineOfSightCollider : MonoBehaviour {

    private const string ColliderStr = "LineOfSightRange";
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
            if (gameObject.GetComponentInParent<UnitController>() != null && gameObject.GetComponent<SphereCollider>() != null)
            {
                gameObject.GetComponent<SphereCollider>().radius = gameObject.GetComponentInParent<UnitController>().ThisUnit._GuardRange;
            }
        }
	}

    void OnTriggerEnter(Collider otherTarget)
    {
        if (otherTarget.GetComponentInParent<UnitController>() &&
            GetComponentInParent<UnitController>() && otherTarget.GetComponentInParent<UnitController>().ThisUnit._CurTeam != GetComponentInParent<UnitController>().ThisUnit._CurTeam)
        {
            GetComponentInParent<UnitController>().possibleTarget = otherTarget.gameObject;
        }
    }

    void OnTriggerStay(Collider otherTarget)
    {
        
        if (otherTarget.GetComponentInParent<UnitController>() &&
            GetComponentInParent<UnitController>() && otherTarget.GetComponentInParent<UnitController>().ThisUnit._CurTeam != GetComponentInParent<UnitController>().ThisUnit._CurTeam)
        {
            GetComponentInParent<UnitController>().possibleTarget = otherTarget.gameObject;
        }
    }

    void OnTriggerExit(Collider otherTarget)
    {
        if (otherTarget.GetComponentInParent<UnitController>() &&
            gameObject.GetComponentInParent<UnitController>() &&
            otherTarget.gameObject == gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTarget)
        {
            gameObject.GetComponentInParent<UnitController>().possibleTarget = null;
            gameObject.GetComponentInParent<UnitController>().ThisUnit._CurTarget = null;
        }
        
    }
}
