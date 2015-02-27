using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour {
	Transform player2MainBase;
	NavMeshAgent nav;
	
	public GameObject[] smallBases = new GameObject[9];
	public GameObject[] mainBases = new GameObject[2];
	public GameObject playerGameObject;
	
	public GameObject closestBaseNow;
	
	// Use this for initialization
	void Awake () {
		player2MainBase = GameObject.FindGameObjectWithTag ("Player2Base").transform;
		
		for (int x = 0; x < mainBases.Length; x++) {
			mainBases [x] = GameObject.FindGameObjectWithTag ("Player" + (x + 1) + "Base");
		}
		
		playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		
		for (int i = 0; i < smallBases.Length; i++) {
			smallBases [i] = GameObject.FindGameObjectWithTag ("SmallBase" + (i + 1));
		}
		nav = GetComponent<NavMeshAgent> ();
		closestBaseNow = GameObject.FindGameObjectWithTag ("Player1Base");
	}
	
	// Update is called once per frameif 
	void Update () {
		nav.SetDestination (FindNearestBase ());
	}
	
	public Vector3 FindNearestBase(){
		Vector3 closestBase = new Vector3(2000f,2000f,2000f);
		float distance = 2000f;
		for (int k = 0; k < smallBases.Length; k++) {
			if (smallBases[k].GetComponent<SmallBaseAttributes>().currentTeam != GetComponent<UnitAttributes>().currentTeam){
				if (distance >= Vector3.Distance (smallBases[k].transform.position, gameObject.transform.position)){
					distance = Vector3.Distance (smallBases[k].transform.position, gameObject.transform.position);
					closestBase = smallBases[k].transform.position;
					closestBaseNow = smallBases[k];
				}
			}
		}
		
		for (int z = 0; z < mainBases.Length; z++) {
			if (mainBases[z].GetComponent<MainBaseAttributes>().currentTeam != GetComponent<UnitAttributes>().currentTeam){
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
