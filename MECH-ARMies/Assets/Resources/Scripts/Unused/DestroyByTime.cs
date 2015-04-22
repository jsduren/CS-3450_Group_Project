using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifetime = 4f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
	}

}
