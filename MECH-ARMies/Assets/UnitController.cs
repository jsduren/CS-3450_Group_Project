using UnityEngine;
using System.Collections;




public class UnitController : MonoBehaviour {

    public Unit ThisUnit;
    public string curTeam = "Neutral";
    public string unitType;
    private string prevProgram;
    public string curProgram;
    private GameObject gameController;
    public GameObject curTarget;
    public GameObject curClosestBaseNow;
    public bool TestTeamChangeToPlayer1 = false;
    public bool TestTeamChangeToPlayer2 = false;
    public bool teamChanging = false;
    private bool isAwake = false;
    // Use this for initialization
	void Start ()
	{
	    gameController = GameObject.FindGameObjectWithTag("GameController");
	    UnitInitialization(curTeam, unitType);
	    isAwake = true;
	}
	
	// Update is called once per frame
	void Update () {

        //! For updating the class when the Program is changed 
	    if (curProgram != prevProgram)
	    {
	        prevProgram = curProgram;
            ProgramChange(curProgram);
	    }

        if (TestTeamChangeToPlayer1)
	    {
	        curTeam = "Player1";
	        TestTeamChangeToPlayer1 = false;
            teamChanging = true;
	    }
        if (TestTeamChangeToPlayer2)
        {
            curTeam = "Player2";
            TestTeamChangeToPlayer2 = false;
            teamChanging = true;
        }

	    
	        //! For updating the unit class when the curTeam is changed
        if (curTeam != null && ThisUnit._CurTeam != null && curTeam != ThisUnit._CurTeam)
	    {
            curTeam = ThisUnit._CurTeam;
	    }
        if (curTeam != null && ThisUnit._CurTeam != null && !teamChanging)
        {
	        curTarget = ThisUnit.Shoot(curTarget);
            if (isAwake && ThisUnit._UnitProgram == ProgramType.Guard)
	        {
	            curClosestBaseNow = ThisUnit.Move(gameController, curTarget, gameObject.transform);
	        }
	        else
	        {
	            curClosestBaseNow = ThisUnit.Move(gameController, curClosestBaseNow, gameObject.transform);
	            isAwake = false;
	        }
	        ThisUnit.Death();
	    }
	    if (curTeam != null && ThisUnit._CurTeam != null && curTeam == ThisUnit._CurTeam)
	    {
	        teamChanging = false;
	    }
	        
	    
	}

    private void UnitInitialization(string team, string curUnit)
    {
        switch (curUnit)
        {
            case "Infantry":
                ThisUnit = new Infantry(team, ProgramType.NearestBase, gameObject);
                break;
            case "Jeep":
                ThisUnit = new Jeep(team, ProgramType.NearestBase, gameObject);
                break;
            case "Tank":
                ThisUnit = new Tank(team, ProgramType.NearestBase, gameObject);
                break;
            case "SAM":
                ThisUnit = new SAM(team, ProgramType.NearestBase, gameObject);
                break;
            case "Turret":
                ThisUnit = new Turret(team, ProgramType.StandGround, gameObject);
                break;
            case "MainBase":
                ThisUnit = new MainBase(team, ProgramType.StandGround, gameObject);
                break;
            case "SmallBase":
                ThisUnit = new SmallBase(team, ProgramType.NearestBase, gameObject);
                break;
            case "Shots":
                ThisUnit = new Shots(team, gameObject);
                break;
            case "PlayerPlane":
                ThisUnit = new PlayerPlane(team, ProgramType.StandGround, gameObject);
                break;
            case "PlayerMech":
                ThisUnit = new PlayerMech(team, ProgramType.StandGround, gameObject);
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

    public void InflictDamage(int damage)
    {
        //
    }


}
