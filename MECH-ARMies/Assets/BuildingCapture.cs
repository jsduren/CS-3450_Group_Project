using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class BuildingCapture : MonoBehaviour
{

    // Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitController>().ThisUnit._UnitType == UType.Infantry && 
            other.GetComponent<UnitController>().ThisUnit._UnitProgram == ProgramType.NearestBase)
        {
            gameObject.GetComponentInParent<UnitController>().ThisUnit.BaseCapture(other.gameObject);
        }
    }

}
