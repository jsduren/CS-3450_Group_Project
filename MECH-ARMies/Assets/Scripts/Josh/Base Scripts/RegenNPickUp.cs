using UnityEngine;

public class RegenNPickUp : MonoBehaviour {

    private int spawnCounter = 0;
    public GameObject playerUnit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    spawnCounter++;
	    if (spawnCounter > 6000)
	    {
	        spawnCounter = 0;
	        Instantiate(playerUnit);
	    }
	}
}
