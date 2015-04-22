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

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(other == null);
        if (other != null && other.GetComponent<UnitController>() != null)
        {
            //Debug.Log(string.Format("OnTriggerEnter Triggered by: {0}", other));

            if (other.GetComponent<UnitController>().ThisUnit._UnitType == UType.Infantry && other.GetComponent<UnitController>().ThisUnit._UnitProgram == ProgramType.NearestBase)
            {
                gameObject.GetComponentInParent<UnitController>().ThisUnit.BaseCapture(other.gameObject);
            }
        }
    }

}
