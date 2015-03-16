using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//private bool gameOverPlayer1;
	//private bool gameOverPlayer2;
	
	public GameObject[] smallBases = new GameObject[9];
	public GameObject[] mainBases = new GameObject[2];
	public int Player1Money;
	public int Player2Money;
	public int StartingMoney;
	public GameObject MenuController;
    public GameObject Ship;
	
    Vector3 shipspawn = new Vector3(105.0f, 35.0f, 105.0f);

	// Use this for initialization
    void Start()
    {

        Instantiate(MenuController);

        for (int x = 0; x < mainBases.Length; x++)
        {
            mainBases[x] = GameObject.FindGameObjectWithTag("Player" + (x + 1) + "Base");
            //Debug.Log(string.Format("Main Base {0} Initialized",x+1));
        }

        MenuController = GameObject.FindGameObjectWithTag("MenuController");

        for (int i = 0; i < smallBases.Length; i++)
        {
            smallBases[i] = GameObject.FindGameObjectWithTag("SmallBase" + (i + 1));
            //Debug.Log(string.Format("Small Base {0} Initialized",i+1));
        }

        //initialize other values
        Player1Money = StartingMoney;
        Player2Money = StartingMoney;
        Ship = (GameObject)Instantiate(Ship, shipspawn, Ship.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () 
    {
		for (int x = 0; x < mainBases.Length; x++)
        {
			if (mainBases[x] != null && mainBases[x].GetComponent<MainBaseHealth>().isDead) {
				if (mainBases[x].GetComponent<ObjectAttributes>().currentTeam == "Player1"){
					//Put success script here
				}else{
					//Put failure script here
				}
			}
		}

		/*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bool IsVisible = _menuController.gameObject.GetComponent("IsVisible");
            IsVisible = !IsVisible;
        } */



	}

    public GameObject FindNearestBase(GameObject unitGameObject)
    {
        Debug.Log(string.Format("FindingNearestBase Function Ran"));
        float distance = 4000f;
        GameObject tempClosestBase = null;
        //Debug.Log(string.Format("FindingNearestBase Function If UnitProgram is NearestBase"));
        for (int k = 0; k < smallBases.Length; k++)
        {
            Debug.Log(string.Format("Small Base Test: {0}", k));
            Debug.Log(string.Format("Small Base Test if Null: {0}", smallBases[k].GetComponent<UnitController>() == null));
            Debug.Log(string.Format("Small Base Test if unitGame Object is Null: {0}", unitGameObject.GetComponent<UnitController>() == null));
            if (smallBases[k].GetComponent<UnitController>() != null && unitGameObject.GetComponent<UnitController>() != null && smallBases[k].GetComponent<UnitController>().ThisUnit._CurTeam != unitGameObject.GetComponent<UnitController>().ThisUnit._CurTeam)
            {
                if (distance >=
                    Vector3.Distance(smallBases[k].transform.position, unitGameObject.transform.position))
                {
                    distance = Vector3.Distance(smallBases[k].transform.position,
                        unitGameObject.transform.position);
                    tempClosestBase = smallBases[k];
                    Debug.Log(string.Format("Closest Small Base {0}", k));
                }
            }
        }


        for (int z = 0; z < mainBases.Length; z++)
        {
            Debug.Log(string.Format("Testing Main Base {0}", z));
            if (mainBases[z].GetComponent<UnitController>() != null && unitGameObject.GetComponent<UnitController>() != null &&
                mainBases[z].GetComponent<UnitController>().ThisUnit._CurTeam !=
                unitGameObject.GetComponent<UnitController>().ThisUnit._CurTeam)
            {
                if (distance >= Vector3.Distance(mainBases[z].transform.position, unitGameObject.transform.position))
                {
                    distance = Vector3.Distance(mainBases[z].transform.position, unitGameObject.transform.position);
                    tempClosestBase = mainBases[z];
                    Debug.Log(string.Format("Closest Main Base {0}", z));
                }
            }
        }
        if (tempClosestBase != null)
        {
            Debug.Log(string.Format("Closest Base Returned: {0}", tempClosestBase.transform.position));
        }
        return tempClosestBase;
    }


}
