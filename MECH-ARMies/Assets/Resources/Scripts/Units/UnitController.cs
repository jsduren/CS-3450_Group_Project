using UnityEngine;
using System.Collections;




public class UnitController : MonoBehaviour {

    public Unit ThisUnit;
    public string curTeam = "Neutral";
    public int dealDamage;
    public float gunRange;
    private const string NoColliderStr = "NoCollider";
    public string unitType;
    public string curProgram;
    public string prevProgram = "Stand Ground";
    public GameObject curTarget;
    public GameObject curClosestBaseNow;
    private bool isAwake = false;
    // Use this for initialization
	void Start ()
	{
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

	    ThisUnit._CurrentTransform = gameObject.transform;

        //! For updating the unit class when the curTeam is changed
        if (curTeam != null && ThisUnit._CurTeam != null && curTeam != ThisUnit._CurTeam)
	    {
            curTeam = ThisUnit._CurTeam;
	    }

	    if (ThisUnit._CurTarget != null)
	    {
	        ThisUnit.Aiming();
	        ThisUnit._CurTarget = ThisUnit.Shoot(ThisUnit._CurTarget, NoColliderStr);
	    }

	    if (isAwake && ThisUnit._UnitProgram == ProgramType.Guard)
	    {
	        curTarget = ThisUnit.Move(ThisUnit._CurTarget, gameObject.transform);
	    }
	    else
	    {
	        curClosestBaseNow = ThisUnit.Move(curClosestBaseNow, gameObject.transform);
	        isAwake = false;
	    }
	    ThisUnit.Death();

        ThisUnit.Move(null, null);

        if (Input.GetButton("Fire1"))
        {
            ThisUnit.Shoot(gameObject, "Jet");
        }

        if (Input.GetButtonDown("Change"))
        {
            ThisUnit.SwitchPlayer(gameObject);
        }

        if (Input.GetButtonDown("CargoDrop"))
        {
            ThisUnit.dropCargo();
        }

	}

    private void UnitInitialization(string team, string curUnit)
    {
        switch (curUnit)
        {
            case "Infantry":
                ThisUnit = new Infantry(team, ProgramType.StandGround, gameObject)
                {
                    _DropTransform = gameObject.transform,
                };
                break;
            case "Jeep":
                ThisUnit = new Jeep(team, ProgramType.StandGround, gameObject)
                {
                    _DropTransform = gameObject.transform,
                };
                break;
            case "Tank":
                ThisUnit = new Tank(team, ProgramType.StandGround, gameObject)
                {
                    _DropTransform = gameObject.transform,                };
                break;
            case "SAM":
                ThisUnit = new SAM(team, ProgramType.StandGround, gameObject)
                {
                    _DropTransform = gameObject.transform,
                };
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
            case "Shot":
                ThisUnit = new Shot(team, gameObject)
                {
                    _DropTransform = gameObject.transform,
                    _Damage = dealDamage,
                    _GunRange = gunRange
                };
                break;
            case "Missile":
                ThisUnit = new Missile(team, gameObject)
                {
                    _DropTransform = gameObject.transform,
                };
                break;
            case "PlayerPlane":
                ThisUnit = new PlayerPlane(team, gameObject);
                break;
            case "PlayerMech":
                ThisUnit = new PlayerMech(team, gameObject);
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
                ThisUnit._UnitProgram = ProgramType.Shot;
                break;
            case "Missile Fired":
                ThisUnit._UnitProgram = ProgramType.Missile;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        var otherUnitController = other.GetComponentInParent<UnitController>();
        if (otherUnitController == null) return;
        if (ThisUnit == null || otherUnitController.ThisUnit == null) return;
        if (ThisUnit._IsShootable && (otherUnitController.ThisUnit._UnitType == UType.Shot || otherUnitController.ThisUnit._UnitType == UType.Missile) && otherUnitController.ThisUnit._CurTeam != ThisUnit._CurTeam)
        {
            ThisUnit.TakeDamage(otherUnitController.ThisUnit._Damage, other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        var cargo = other.gameObject;

        if (Input.GetButtonDown("CargoMove"))
        {
            if (ThisUnit.pickupCargo(cargo)) ;

        }

    }

}
