using UnityEngine;
using System.Collections;

public class Sphere3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ColorCaptured(string colorChange)
    {
        if (colorChange == "Neutral")
        {
            gameObject.renderer.material.color = Color.white;
            return;
        }
        if (colorChange == "Player1")
        {
            gameObject.renderer.material.color = Color.red;
            return;
        }
        if (colorChange == "Player2")
        {
            gameObject.renderer.material.color = Color.blue;
        }
    }
}
