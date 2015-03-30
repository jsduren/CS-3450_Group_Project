using UnityEngine;
using System.Collections;
using System.Linq;

public class UnitMovement : MonoBehaviour
{
    Transform player2MainBase;
    private Unit ThisUnit;
    public GameObject playerGameObject;
    private GameObject curclosestBaseNow;
    private GameObject temp;
    private bool isAwake = false;


    // Use this for initialization
    void Awake()
    {
        ThisUnit = new Jeep("Player1", ProgramType.NearestBase, gameObject);

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        ThisUnit._UnitGameObject = gameObject;
        Debug.Log(string.Format("Waking UP"));

        curclosestBaseNow = GameObject.FindGameObjectWithTag("Player2Base");
        isAwake = true;
    }

    // Update is called once per frameif 
    void Update()
    {
        if (isAwake && GetComponent<NavMeshAgent>() != null)
        {
            Debug.Log(string.Format("Moving to Closest Base Now"));
            temp = ThisUnit.Move(curclosestBaseNow, gameObject.transform);
            curclosestBaseNow = temp;
            if (GetComponent<NavMeshAgent>() != null && curclosestBaseNow != null)
            {
                GetComponent<NavMeshAgent>().SetDestination(curclosestBaseNow.transform.position);
            }
            //isAwake = false;
        }
    }
}
