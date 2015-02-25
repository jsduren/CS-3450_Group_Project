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
	// Use this for initialization
	void Start () {
		gameOverPlayer1 = false;
		gameOverPlayer2 = false;
		Player1Money = StartingMoney;
		Player2Money = StartingMoney;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
