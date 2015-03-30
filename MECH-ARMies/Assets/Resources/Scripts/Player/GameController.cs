using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//private bool gameOverPlayer1;
	//private bool gameOverPlayer2;
	
	public int Player1Money;
	public int Player2Money;
	public int StartingMoney;
	public GameObject MenuController;
    public GameObject Ship;
    public GameObject gunShot;
    public GameObject missileShot;
	
    Vector3 shipspawn = new Vector3(105.0f, 35.0f, 105.0f);

	// Use this for initialization
    void Start()
    {

        Instantiate(MenuController);

        for (int x = 0; x < BaseStaticValues.MainBaseArray.Length; x++)
        {
            BaseStaticValues.MainBaseArray[x] = GameObject.FindGameObjectWithTag("Player" + (x + 1) + "Base");
            //Debug.Log(string.Format("Main Base {0} Initialized",x+1));
        }

        MenuController = GameObject.FindGameObjectWithTag("MenuController");

        for (int i = 0; i < BaseStaticValues.SmallBaseArray.Length; i++)
        {
            BaseStaticValues.SmallBaseArray[i] = GameObject.FindGameObjectWithTag("SmallBase" + (i + 1));
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
        for (int x = 0; x < BaseStaticValues.MainBaseArray.Length; x++)
        {
            if (BaseStaticValues.MainBaseArray[x] != null && BaseStaticValues.MainBaseArray[x].GetComponent<MainBaseHealth>().isDead)
            {
                if (BaseStaticValues.MainBaseArray[x].GetComponent<ObjectAttributes>().currentTeam == "Player1")
                {
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
    
}
