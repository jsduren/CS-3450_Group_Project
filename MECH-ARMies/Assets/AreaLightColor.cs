using UnityEngine;
using System.Collections;

public class AreaLightColor : MonoBehaviour {

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
            gameObject.light.color = Color.white;
            return;
        }
        if (colorChange == "Player1")
        {
            gameObject.light.color = Color.red;
            return;
        }
        if (colorChange == "Player2")
        {
            gameObject.light.color = Color.blue;
        }
    }
}
