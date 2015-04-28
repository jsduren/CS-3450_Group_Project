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
    public GameObject curTarget = null;
    public GameObject possibleTarget = null;
    public GameObject curClosestBaseNow = null;
    private bool isAwake = false;

    void Awake()
    {
        UnitInitialization(curTeam, unitType);
        isAwake = true;
    }

    // Use this for initialization
	void Start ()
	{
	    //UnitInitialization(curTeam, unitType);        
	    //isAwake = true;
        //if(ThisUnit != null)
        //    rigidbody.freezeRotation = true;
        //Debug.Log(string.Format("UnitController Start: ThisUnit !Null: {0}", ThisUnit != null));
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(string.Format("UnitController Update: ThisUnit !Null: {0}", ThisUnit != null));
	    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().gameOver)
	    {
	        ThisUnit._CanShoot = false;
	        ThisUnit._CanMove = false;
	        ThisUnit._IsShootable = false;
	    }

        //! For updating the class when the Program is changed 
	    if (curProgram != prevProgram)
	    {
	        prevProgram = curProgram;
            ProgramChange(curProgram);
	    }

        //Debug.Log(gameObject.transform);
        
        //! For updating the unit class when the curTeam is changed
        if (curTeam != null && ThisUnit!= null && ThisUnit._CurTeam != null && curTeam != ThisUnit._CurTeam)
	    {
            curTeam = ThisUnit._CurTeam;
	    }

	    if (ThisUnit != null)
	    {
	        ThisUnit.Death();

	        if (Input.GetButtonDown("Change"))
	        {
	            ThisUnit.SwitchPlayer(gameObject);
	        }

	        if (Input.GetButtonDown("CargoDrop"))
            {
                Debug.Log("wassupppppppppddd");
	            ThisUnit.dropCargo();
	        }
	    }
	}

    private void UnitInitialization(string team, string curUnit)
    {
        switch (curUnit)
        {
            case "Infantry":
                ThisUnit = new Infantry(team, ProgramType.StandGround, gameObject)
                {
                    _DropPosition = transform.position,
                    _DropRotation = transform.rotation
                };
                break;
            case "Jeep":
                ThisUnit = new Jeep(team, ProgramType.StandGround, gameObject)
                {
                    _DropPosition = transform.position,
                    _DropRotation = transform.rotation
                };
                break;
            case "Tank":
                ThisUnit = new Tank(team, ProgramType.StandGround, gameObject)
                {
                    _DropPosition = transform.position,
                    _DropRotation = transform.rotation
                };
                break;
            case "SAM":
                ThisUnit = new SAM(team, ProgramType.StandGround, gameObject)
                {
                    _DropPosition = transform.position,
                    _DropRotation = transform.rotation
                };
                break;
            case "Turret":
                ThisUnit = new Turret(team, ProgramType.StandGround, gameObject);
                break;
            case "MainBase":
                ThisUnit = new MainBase(team, ProgramType.StandGround, gameObject);
                break;
            case "SmallBase":
                ThisUnit = new SmallBase(team, ProgramType.StandGround, gameObject);
                break;
            case "Shot":
                ThisUnit = new Shot(team, gameObject)
                {
                    _DropPosition = transform.position,
                    _DropRotation = transform.rotation,
                    _Damage = dealDamage,
                    _GunRange = gunRange
                };
                break;
            case "Missile":
                ThisUnit = new Missile(team, gameObject)
                {
                    _DropPosition = transform.position,
                    _DropRotation = transform.rotation
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
            case "PlayerPlane":
                ThisUnit._UnitProgram = ProgramType.PlayerPlane;
                break;
            case "PlayerMech":
                ThisUnit._UnitProgram = ProgramType.PlayerMech;
                break;
            case "CompPlane":
                ThisUnit._UnitProgram = ProgramType.CompPlane;
                break;
            case "CompMech":
                ThisUnit._UnitProgram = ProgramType.CompMech;
                break;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<UnitController>() != null && ThisUnit._IsShootable && (other.GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.Shot || other.GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.Missile) && other.GetComponentInParent<UnitController>().ThisUnit._CurTeam != ThisUnit._CurTeam)
        {
            Debug.Log(string.Format("Triggered TakeDamage"));
            ThisUnit.TakeDamage(other.gameObject.GetComponentInParent<UnitController>().ThisUnit._Damage, other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        var cargo = other.gameObject;

        if (Input.GetButtonDown("CargoMove"))
        {
            if(ThisUnit.pickupCargo(cargo));
                
        }

    }

}
