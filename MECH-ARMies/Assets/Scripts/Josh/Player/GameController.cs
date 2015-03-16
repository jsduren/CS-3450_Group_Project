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
	
	// Use this for initialization
	void Start () {

		Instantiate(MenuController);

		for (int x = 0; x < mainBases.Length; x++) {
			mainBases [x] = GameObject.FindGameObjectWithTag ("Player" + (x + 1) + "Base");
		}

		MenuController = GameObject.FindGameObjectWithTag ("MenuController");

		for (int i = 0; i < smallBases.Length; i++) {
			smallBases [i] = GameObject.FindGameObjectWithTag ("SmallBase" + (i + 1));
		}

		//initialize other values
		Player1Money = StartingMoney;
		Player2Money = StartingMoney;
		//Ship = (GameObject) Instantiate(Ship, location,Ship.transform.rotation);
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

    public GameObject FindNearestBase(GameObject curClosestBase, GameObject unitGameObject)
    {
        if (curClosestBase.GetComponent<UnitController>().ThisUnit._CurTeam !=
            unitGameObject.GetComponent<UnitController>().ThisUnit._CurTeam)
        {
            float distance = 2000f;
            if (unitGameObject.GetComponent<UnitController>().ThisUnit._UnitProgram == ProgramType.NearestBase)
            {
                for (int k = 0; k < smallBases.Length; k++)
                {
                    if (smallBases[k] != null &&
                        smallBases[k].GetComponent<SmallBaseAttributes>().currentTeam !=
                        GetComponent<ObjectAttributes>().currentTeam)
                    {
                        if (distance >=
                            Vector3.Distance(smallBases[k].transform.position, unitGameObject.transform.position))
                        {
                            distance = Vector3.Distance(smallBases[k].transform.position,
                                unitGameObject.transform.position);
                            curClosestBase = smallBases[k];
                        }
                    }
                }
            }

            for (int z = 0; z < mainBases.Length; z++)
            {
                if (mainBases[z] != null &&
                    mainBases[z].GetComponent<MainBaseAttributes>().currentTeam !=
                    GetComponent<ObjectAttributes>().currentTeam)
                {
                    if (distance >= Vector3.Distance(mainBases[z].transform.position, unitGameObject.transform.position))
                    {
                        distance = Vector3.Distance(mainBases[z].transform.position, unitGameObject.transform.position);
                        curClosestBase = mainBases[z];
                    }
                }
            }

            return curClosestBase;
        }
        return null;
    }


}
