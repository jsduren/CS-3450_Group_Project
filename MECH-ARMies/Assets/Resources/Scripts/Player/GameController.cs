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

    private int enemyTick = 1000;
    private GameObject infantryPrefab;
    private GameObject jeepPrefab;
	
    Vector3 shipspawn = new Vector3(105.0f, 35.0f, 105.0f);

	// Use this for initialization
    void Start()
    {
        Instantiate(MenuController);

        for (var x = 0; x < BaseStaticValues.MainBaseArray.Length; x++)
        {
            BaseStaticValues.MainBaseArray[x] = GameObject.FindGameObjectWithTag("Player" + (x + 1) + "Base");
            //Debug.Log(string.Format("Main Base {0} Initialized",x+1));
        }

        MenuController = GameObject.FindGameObjectWithTag("MenuController");

        for (var i = 0; i < BaseStaticValues.SmallBaseArray.Length; i++)
        {
            BaseStaticValues.SmallBaseArray[i] = GameObject.FindGameObjectWithTag("SmallBase" + (i + 1));
            //Debug.Log(string.Format("Small Base {0} Initialized",i+1));
        }

        //initialize other values
        Player1Money = StartingMoney;
        Player2Money = StartingMoney;
        Ship = (GameObject)Instantiate(Ship, shipspawn, Ship.transform.rotation);
        infantryPrefab = (GameObject)Resources.Load("Prefabs/InfantryV2");
        jeepPrefab = (GameObject)Resources.Load("Prefabs/JeepV2");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    EnemyLoop();
	    foreach (var t in BaseStaticValues.MainBaseArray)
	    {
	        if (t != null && t.GetComponent<MainBaseHealth>().isDead)
	        {
	            if (t.GetComponent<ObjectAttributes>().currentTeam == "Player1")
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

    private void EnemyLoop()
    {
        enemyTick++;
        if (enemyTick%1000 == 0)
        {
            if (enemyTick == 1000*2)
            {
                Debug.Log("Spawn infantry");

                //create infantry
                var enemyBasePosition = BaseStaticValues.MainBaseArray[1].gameObject.transform.position;
                var enemyBaseRotation = BaseStaticValues.MainBaseArray[1].gameObject.transform.rotation;

                for (var i = 0; i < 4; i++)
                {
                    var newUnit = (GameObject) Instantiate(infantryPrefab, new Vector3(enemyBasePosition.x + Random.Range(-10, 10), enemyBasePosition.y, enemyBasePosition.z + Random.Range(-10, 10)), enemyBaseRotation);
                    newUnit.GetComponent<UnitController>().curProgram = "Nearest Base";
                    newUnit.GetComponent<UnitController>().curTeam = "Player2";
                }
            }
            else if(enemyTick == 1000*5)
            {
                Debug.Log("Spawn jeep");

                //create vehicles
                var enemyBasePosition = BaseStaticValues.MainBaseArray[1].gameObject.transform.position;
                var enemyBaseRotation = BaseStaticValues.MainBaseArray[1].gameObject.transform.rotation;

                for (var i = 0; i < 4; i++)
                {
                    var newUnit = (GameObject)Instantiate(jeepPrefab,
                        new Vector3(enemyBasePosition.x + Random.Range(-10, 10), enemyBasePosition.y,
                            enemyBasePosition.z + Random.Range(-10, 10)), enemyBaseRotation);
                    newUnit.GetComponent<UnitController>().curProgram = "Attack Main";
                    newUnit.GetComponent<UnitController>().curTeam = "Player2";
                }

                enemyTick = 0;
            }
            else if (enemyTick > 1000*5)
                enemyTick = 0;
        }
    }
}
