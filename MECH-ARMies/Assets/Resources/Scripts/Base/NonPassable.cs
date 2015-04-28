using UnityEngine;
using System.Collections;

public class NonPassable : MonoBehaviour
{

    private GameObject theMenu;

	// Use this for initialization
	void Start () {
        theMenu = GameObject.FindGameObjectWithTag("MenuController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other != null)
            if (other.GetComponentInParent<UnitController>() != null)
                if (other.GetComponentInParent<UnitController>().unitType.Equals("PlayerPlane"))
            {
                other.GetComponentInParent<UnitController>().canDrop = false;
                theMenu.GetComponent<MenuController>().canOpen = true;
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (other != null)
            if (other.GetComponentInParent<UnitController>() != null)
                if (other.GetComponentInParent<UnitController>().unitType.Equals("PlayerPlane"))
            {
                other.GetComponentInParent<UnitController>().canDrop = true;
                theMenu.GetComponent<MenuController>().IsVisible = false;
                theMenu.GetComponent<MenuController>().canOpen = false;
            }
    }
}
