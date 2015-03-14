using UnityEngine;
using System.Collections;




public class UnitController : MonoBehaviour {

    public Unit ThisUnit;
    public string curTeam = "Neutral";
    public string unitType;
    private string prevProgram;
    public string curProgram;
    private GameObject gameController;
    private Component gameContComponent;
    public GameObject curTarget;
    public GameObject curClosestBaseNow;
    // Use this for initialization
	void Start ()
	{
	    gameController = GameObject.FindGameObjectWithTag("GameController");
	    gameContComponent = gameController.GetComponent<GameController>();
	    UnitInitialization(curTeam, unitType);
	    ThisUnit._UnitGameObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        //! For updating the class when the Program is changed 
	    if (curProgram != prevProgram)
	    {
	        prevProgram = curProgram;
            ProgramChange(curProgram);
	    }
        //! For updating the unit class when the curTeam is changed
	    if (curTeam != "Neutral" && curTeam != ThisUnit._CurTeam)
	    {
	        ThisUnit._CurTeam = curTeam;
	    }
        curTarget = ThisUnit.Shoot(curTarget);
	    if (ThisUnit._UnitProgram == ProgramType.Guard)
	    {
            curClosestBaseNow = ThisUnit.Move(curTarget);
	    }
	    else
	    {
            curClosestBaseNow = ThisUnit.Move(curClosestBaseNow);
	    }
        curClosestBaseNow = ThisUnit.Move(curClosestBaseNow);
        ThisUnit.Death();
	}

    private void UnitInitialization(string team, string curUnit)
    {
        switch (curUnit)
        {
            case "Infantry":
                ThisUnit = new Infantry(team, ProgramType.NearestBase);
                break;
            case "Jeep":
                ThisUnit = new Jeep(team, ProgramType.NearestBase);
                break;
            case "Tank":
                ThisUnit = new Tank(team, ProgramType.NearestBase);
                break;
            case "SAM":
                ThisUnit = new SAM(team, ProgramType.NearestBase);
                break;
            case "Turret":
                ThisUnit = new Turret(team, ProgramType.StandGround);
                break;
            case "MainBase":
                ThisUnit = new MainBase(team, ProgramType.StandGround);
                break;
            case "SmallBase":
                ThisUnit = new SmallBase(team, ProgramType.NearestBase);
                break;
            case "Shots":
                ThisUnit = new Shots(team);
                break;
            case "PlayerPlane":
                ThisUnit = new PlayerPlane(team, ProgramType.StandGround);
                break;
            case "PlayerMech":
                ThisUnit = new PlayerMech(team, ProgramType.StandGround);
                break;

        }
    }

    private void ProgramChange(string newProg)
    {
        switch (newProg)
        {
            case "Stand Ground":
                ThisUnit._UnitProgram = ProgramType.StandGround;
                break;
            case "Guard":
                ThisUnit._UnitProgram = ProgramType.Guard;
                break;
            case "Nearest Base":
                ThisUnit._UnitProgram = ProgramType.NearestBase;
                break;
            case "Attack Main":
                ThisUnit._UnitProgram = ProgramType.AttackMain;
                break;
            case "Shot Fired":
                ThisUnit._UnitProgram = ProgramType.ShotFired;
                break;
        }
    }


}
