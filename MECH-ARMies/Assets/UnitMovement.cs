using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour {
	Transform player2MainBase;
	NavMeshAgent nav;
	// Use this for initialization
	void Awake () {
		player2MainBase = GameObject.FindGameObjectWithTag ("Player2Base").transform;
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (player2MainBase.position);
	}
}
