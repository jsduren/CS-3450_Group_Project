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

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && gameObject.GetComponentInParent<UnitController>() != null)
        {
            gameObject.GetComponentInParent<UnitController>().possibleTarget = other.gameObject;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && gameObject.GetComponentInParent<UnitController>() != null)
        {
            gameObject.GetComponentInParent<UnitController>().possibleTarget = other.gameObject;
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
