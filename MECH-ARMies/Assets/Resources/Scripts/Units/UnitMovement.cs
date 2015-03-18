using UnityEngine;
using System.Collections;
using System.Linq;

public class UnitMovement : MonoBehaviour
{
    Transform player2MainBase;
    NavMeshAgent nav;
    private Unit ThisUnit;
    public GameObject playerGameObject;
    private GameObject gameController;
    private GameObject curclosestBaseNow;
    private GameObject temp;
    private bool isAwake = false;

    // Use this for initialization
    void Awake()
    {
        ThisUnit = new Jeep("Player1", ProgramType.NearestBase, gameObject);
        gameController = GameObject.FindGameObjectWithTag("GameController");

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        ThisUnit._UnitGameObject = gameObject;
        Debug.Log(string.Format("Waking UP"));

        nav = GetComponent<NavMeshAgent>();
        curclosestBaseNow = GameObject.FindGameObjectWithTag("Player2Base");
        isAwake = true;
    }

    // Update is called once per frameif 
    void Update()
    {
        if (isAwake && GetComponent<NavMeshAgent>() != null)
        {
            Debug.Log(string.Format("Moving to Closest Base Now"));
            temp = ThisUnit.Move(gameController, curclosestBaseNow, gameObject.transform);
            curclosestBaseNow = temp;
            if (GetComponent<NavMeshAgent>() != null && curclosestBaseNow != null)
            {
                GetComponent<NavMeshAgent>().SetDestination(curclosestBaseNow.transform.position);
            }
            //isAwake = false;
        }
    }
}
