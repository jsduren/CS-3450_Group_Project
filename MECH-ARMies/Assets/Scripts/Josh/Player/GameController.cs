using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private bool gameOverPlayer1;
	private bool gameOverPlayer2;
	
	public GameObject[] smallBases = new GameObject[9];
	public GameObject[] mainBases = new GameObject[2];
	public int Player1Money;
	public int Player2Money;
	public int StartingMoney;
	public GameObject MenuController;

    public GameObject enemyUnit;

    public GameObject PlayerGameObject;
    private Vector3 location = new Vector3(105, 34.5f, 105);
	
	
	//private MenuController _menuController;
	
	// Use this for initialization
	void Start () {
		//Make menuController
        PlayerGameObject = (GameObject)Instantiate(PlayerGameObject, location, PlayerGameObject.transform.rotation);

	    SpawnUnits();

		Instantiate(MenuController);

		for (int x = 0; x < mainBases.Length; x++) {
			mainBases [x] = GameObject.FindGameObjectWithTag ("Player" + (x + 1) + "Base");
		}

		MenuController = GameObject.FindGameObjectWithTag ("MenuController");

		for (int i = 0; i < smallBases.Length; i++) {
			smallBases [i] = GameObject.FindGameObjectWithTag ("SmallBase" + (i + 1));
		}

		//initialize other values
		gameOverPlayer1 = false;
		gameOverPlayer2 = false;
		Player1Money = StartingMoney;
		Player2Money = StartingMoney;
		//Ship = (GameObject) Instantiate(Ship, location,Ship.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < mainBases.Length; x++) {
			if (mainBases[x] != null && mainBases[x].GetComponent<MainBaseHealth>().isDead) {
				if (mainBases[x].GetComponent<ObjectAttributes>().currentTeam == "Player1"){
					gameOverPlayer1 = true;	
				}else{
					gameOverPlayer2 = true;
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

    void SpawnUnits()
    {
        var spawnLocs = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (var loc in spawnLocs)
        {
            Instantiate(enemyUnit, loc.transform.position, enemyUnit.transform.rotation);
        }
    }
    
}
