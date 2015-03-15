using UnityEngine;
using System.Collections;
using System.Linq;

public class UnitMovement : MonoBehaviour {
	Transform player2MainBase;
	NavMeshAgent nav;

	private GameObject[] smallBases = new GameObject[9];
	private GameObject[] mainBases = new GameObject[2];
	public GameObject playerGameObject;
	
	public GameObject closestBaseNow;
	private bool isAwake = false;
	
	// Use this for initialization
	void Awake () {

		for (int x = 0; x < mainBases.Length; x++) {
			mainBases [x] = GameObject.FindGameObjectWithTag ("Player" + (x + 1) + "Base");
		}
		
		playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		
		for (int i = 0; i < smallBases.Length; i++) {
			smallBases [i] = GameObject.FindGameObjectWithTag ("SmallBase" + (i + 1));
		}
		nav = GetComponent<NavMeshAgent> ();
		closestBaseNow = GameObject.FindGameObjectWithTag ("Player1Base");
		isAwake = true;
	}
	
	// Update is called once per frameif 
	void Update () {
		if (isAwake) {
			nav.SetDestination (FindNearestBase ());
		}
	}
	
	public Vector3 FindNearestBase(){
		var closestBase = new Vector3(2000f,2000f,2000f);
		var distance = 2000f;
	    foreach (var t in smallBases)
	    {
	        if (t != null)
	        {
	            if (t.GetComponent<SmallBaseAttributes>().currentTeam != GetComponent<ObjectAttributes>().currentTeam)
	            {
	                if (distance >= Vector3.Distance(t.transform.position, gameObject.transform.position))
	                {
	                    distance = Vector3.Distance(t.transform.position, gameObject.transform.position);
	                    closestBase = t.transform.position;
	                    closestBaseNow = t;
	                }
	            }
	        }
	    }

	    for (int z = 0; z < mainBases.Length; z++) {
			if (mainBases[z] != null && mainBases[z].GetComponent<MainBaseAttributes>().currentTeam != GetComponent<ObjectAttributes>().currentTeam){
				if (distance >= Vector3.Distance (mainBases[z].transform.position, gameObject.transform.position)){
					distance = Vector3.Distance (mainBases[z].transform.position, gameObject.transform.position);
					closestBase = mainBases[z].transform.position;
					closestBaseNow = mainBases[z];
				}
			}
		}

		return closestBase;
	}


	
	
}
