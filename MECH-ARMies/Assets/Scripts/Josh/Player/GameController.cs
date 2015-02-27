using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private bool gameOverPlayer1;
	private bool gameOverPlayer2;
	
	public GameObject Player1MainBase;
	public GameObject Player2MainBase;
	public GameObject SmallBase1;
	public GameObject SmallBase2;
	public GameObject SmallBase3;
	public GameObject SmallBase4;
	public GameObject SmallBase5;
	public GameObject SmallBase6;
	public GameObject SmallBase7;
	public GameObject SmallBase8;
	public GameObject SmallBase9;
	public int Player1Money;
	public int Player2Money;
	public int StartingMoney;
	public GameObject MenuController;
	//public GameObject Ship;
	//private Vector3 location = new Vector3(105,34.5f,105);	
	
	//private MenuController _menuController;
	
	// Use this for initialization
	void Start () {
		//Make menuController
		Instantiate(MenuController);
		
		//initialize other values
		gameOverPlayer1 = false;
		gameOverPlayer2 = false;
		Player1Money = StartingMoney;
		Player2Money = StartingMoney;
		//Ship = (GameObject) Instantiate(Ship, location,Ship.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1MainBase.GetComponent<MainBaseHealth> ().isDead) {
			gameOverPlayer1 = true;	
		}
		
		if (Player2MainBase.GetComponent<MainBaseHealth> ().isDead) {
			gameOverPlayer2 = true;	
		}
		/*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bool IsVisible = _menuController.gameObject.GetComponent("IsVisible");
            IsVisible = !IsVisible;
        } */
	}
}
