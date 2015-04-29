using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public enum UType
{
    Infantry = 0,
    Jeep = 1,
    Tank = 2,
    SAM = 3,
    Turret = 4,
    SmallBase = 5,
    MainBase = 6,
    Shot = 7,
    Missile = 8,
    PlayerPlane = 9,
    PlayerMech = 10,
    Unit = 11
}

public enum WeaponsType
{
    Guns = 0,
    Missiles = 1,
    GunsAndMissiles = 2
}

public enum ProgramType
{
    StandGround = 0,
    Guard = 1,
    NearestBase = 2,
    AttackMain = 3,
    Shot = 4,
    Missile = 5,
    PlayerPlane = 6,
    PlayerMech = 7,
    CompPlane = 8,
    CompMech = 9
}

public static class BaseStaticValues
{
    public static readonly string[] UnitStringNames =
    {
        "Infantry",
        "Jeep",
        "Tank",
        "SAM",
        "Turret",
        "SmallBase",
        "MainBase",
        "Shot",
        "Missile",
        "PlayerPlane",
        "PlayerMech"
    };

    // Max Player values for initializing
    public static class Player
    {
        public static readonly int MaxLife = 600;
        public static readonly int MaxGuns = 50;
        public static readonly float MaxEnergy = 100;
        public static readonly int GunDamage = 20;
        public static readonly float FireRate = 0.3f;
        public static readonly float GunRange = 35f;
        public static readonly float TransformRate = 1f;
        public static readonly float PickUpDropOffRate = .25f;
        public static readonly float Speed = 90;
        public static readonly WeaponsType Weapons = WeaponsType.Guns;
        public static readonly int MaxCargoCapacity = 4;
    }

    public static class Unit
    {
        public static float RotationDamping = 50f;
    }

    public static GameObject[] SmallBaseArray = new GameObject[9];
    public static GameObject[] MainBaseArray = new GameObject[2];

    //public static Object[] OrderingArray = { new Infantry(), new Jeep(), new Tank(), new SAM(), new Turret() };

   // private static int Cost = OrderingArray[(int) UType.Infantry].Cost;

    // Player 1 Data
    public static class Player1
    {
        public static int Life;
        public static int Guns;
        public static float Energy;
        public static int Credits;
    }

    // Player 2 Data
    public static class Player2
    {
        public static int Life;
        public static int Guns;
        public static float Energy;
        public static int Credits;
    }
    
    // Infantry Base Attributes
    public class Infantry : Object
    {
        public const int MaxLife = 150;
        public const float MaxEnergy = 200;
        public const int MaxGuns = 50;
        
        public static readonly float LineOfSight = 40;
        public static readonly float GunRange = 30;
        public static readonly int GunDamage = 10;
        public static readonly float GunFireRate = 0.2f;
        public static readonly int CargoSpace = 1;
        public static readonly int Cost = 40;
        public static readonly float ProductionTime = 3f;
        public static readonly WeaponsType Weapons = WeaponsType.Guns;
        public static readonly ProgramType[] PossibleProgTypes =
        {
            ProgramType.StandGround,
            ProgramType.Guard,
            ProgramType.NearestBase,
            ProgramType.AttackMain
        };

        
    }

    // Jeep Base Attributes
    public class Jeep : Object
	{
        public const int MaxLife = 250;
        public const float MaxEnergy = 200;
        public const int MaxGuns = 50;

		public static readonly float LineOfSight = 45;
		public static readonly float GunRange = 35;
		public static readonly int GunDamage = 15;
		public static readonly float GunFireRate = 0.2f;
        public static readonly int CargoSpace = 2;
		public static readonly int Cost = 40;
		public static readonly float ProductionTime = 3f;
		public static readonly WeaponsType Weapons = WeaponsType.Guns;
		public static readonly ProgramType[] PossibleProgTypes = 
		{
			ProgramType.StandGround,
			ProgramType.Guard,
			ProgramType.NearestBase,
			ProgramType.AttackMain
		};
	}
	
	// Tank Base Attributes
    public class Tank : Object
	{
        public const int MaxLife = 50;
        public const float MaxEnergy = 200;
        public const int MaxGuns = 50;

		public static readonly float LineOfSight = 20;
		public static readonly float GunRange = 20;
		public static readonly int GunDamage = 15;
		public static readonly float GunFireRate = 0.4f;
		public static readonly int CargoSpace = 3;
		public static readonly int Cost = 40;
		public static readonly float ProductionTime = 3f;
		public static readonly WeaponsType Weapons = WeaponsType.Guns;
		public static readonly ProgramType[] PossibleProgTypes = 
		{
			ProgramType.StandGround,
			ProgramType.Guard,
			ProgramType.NearestBase,
			ProgramType.AttackMain
		};
	}

    // SAM Base Attributes
    public class SAM : Object
	{
        public const int MaxLife = 50;
        public const float MaxEnergy = 200;
        public const int MaxMissiles = 50;
		public static readonly float LineOfSight = 20;
        public static readonly int CargoSpace = 3;
		public static readonly int Cost = 40;
		public static readonly float ProductionTime = 3f;
		public static readonly WeaponsType Weapons = WeaponsType.Missiles;
		public static readonly ProgramType[] PossibleProgTypes = 
		{
			ProgramType.StandGround,
			ProgramType.Guard,
			ProgramType.NearestBase,
			ProgramType.AttackMain
		};
	}

    // Turret Base Attributes
    public class Turret : Object
	{
        public const int MaxLife = 500;
        public const float MaxEnergy = 200;
        public const int MaxGuns = 50;
	    public const int MaxMissiles = 50;
		public static readonly float LineOfSight = 20;
		public static readonly float GunRange = 20;
		public static readonly int GunDamage = 15;
		public static readonly float GunFireRate = 0.4f;
        public static readonly int CargoSpace = 4;
		public static readonly int Cost = 40;
		public static readonly float ProductionTime = 3f;	
		public static readonly WeaponsType Weapons = WeaponsType.GunsAndMissiles;
		public static readonly ProgramType[] PossibleProgTypes = 
		{
			ProgramType.StandGround
		};
	}

    // SmallBase Base Attributes
	public static class SmallBase
	{
		public static readonly int MaxNumUnitsToCapture = 4;
    }

    // MainBase Base Attributes
	public static class MainBase
	{
		public const int MaxLife = 2000;
	}
	
    // Shot Base Attributes
	public static class Shot
	{
		public static readonly int Velocity = 250;
	}

    // Missile Base Attributes
	public static class Missile
	{
		public static readonly int Velocity = 50;
		public static readonly float Range = 40;
		public static readonly int Damage = 30;
		public static readonly float FireRate = 1f;
	}

}

public abstract class Unit : Object
{
    protected Unit()
    {
        _CurTeam = "Neutral";
        _UnitType = UType.Unit;
        _UnitProgram = ProgramType.StandGround;
    }

    protected Unit(string curTeam, ProgramType unitProgram, UType unitType)
    {
        _CurTeam = curTeam;
        _UnitType = unitType;
        _UnitProgram = unitProgram;
    }

    public string _CurTeam { get; set; }
    public UType _UnitType { get; set; }
    public ProgramType _UnitProgram { get; set; }

    public abstract bool _IsShootable { get; set; }
    public abstract bool _CanShoot { get; set; }
    public abstract bool _IsCapturable { get; set; }
    public abstract int _Life { get; set; }
    public abstract float _Energy { get; set; }
    public abstract int _Guns { get; set; }
    public abstract int _Missiles { get; set; }
    public abstract float _GunRange { get; set; }
    public abstract float _MissileRange { get; set; }
    public abstract float _GuardRange { get; set; }
    public abstract bool _CanMove { get; set; }
    public abstract bool _IsDead { get; set; }
    public abstract int _Player1UnitCapture { get; set; }
    public abstract int _Player2UnitCapture { get; set; }
    public abstract WeaponsType _Weapons { get; set; }
    public abstract int _GunAttackDamage { get; set; }
    public abstract int _CargoSpaceOfUnit { get; set; }
    public abstract int _CargoCapacity { get; set; }
    public abstract int _Damage { get; set; }
    public abstract float _GunFireRate { get; set; }
    public abstract Transform _CurrentTransform { get; set; }
    public abstract Vector3 _DropPosition { get; set; }
    public abstract Quaternion _DropRotation { get; set; }
    public abstract GameObject _CurTarget { get; set; }
    public abstract GameObject _CurDestination { get; set; }
    public abstract AreaLightColor[] _AreaLightsArray { get; set; }
    public abstract MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public abstract Transform _TargetedTransformOffset { get; set; }
    public abstract Transform _TargetTransform { get; set; }
    public abstract GunBarrelEnd[] _ShotOrigins { get; set; }
    public abstract Transform _ShotOriginTransform1 { get; set; }
    public abstract Transform _ShotOriginTransform2 { get; set; }
    public abstract bool _CanTransform { get; set; }
    public abstract float _NextTimeToTransform { get; set; }
    public abstract float _NextPickUpAfterDropOff { get; set; }
    public abstract float _NextGunShot { get; set; }
    public abstract float _NextMissileShot { get; set; }

    public abstract Object[] _Cargo { get; set; }

 public void TakeDamage(int damageAmount, GameObject shotGameObject)
    {
        //UnityEngine.Debug.Log(string.Format("TakeDamage Triggered {0}", _UnitGameObject.transform.position));
        if (_IsShootable && !_IsDead)
        {
            _Life -= damageAmount;
            //Destroy(shotGameObject);
            if (_Life <= 0)
            {
                _IsDead = true;
            }
        }
    }
    /*
    public void Aiming()
    {
        if (_CurTarget != null)
        {
            Vector3 targetPosition2d = new Vector3(_CurTarget.transform.position.x, _CurTarget.transform.position.y + 1, _CurTarget.transform.position.z);
            Transform aim_pan = _UnitGameObject.GetComponentInChildren<AimPan>().transform;
            aim_pan.LookAt(targetPosition2d);
            aim_pan.eulerAngles = new Vector3(0, aim_pan.eulerAngles.y, 0);
            if (_UnitType == UType.Jeep)
            {

                Transform aim_tilt = _UnitGameObject.GetComponentInChildren<AimTilt>().transform;
                aim_tilt.LookAt(targetPosition2d);
                //aim_tilt.eulerAngles = new Vector3(aim_tilt.eulerAngles.x, 0, 0);

                _UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation = Quaternion.RotateTowards(_UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation, aim_pan.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping);

                //_UnitGameObject.GetComponentInChildren<GunRotation>().transform.LookAt(targetPosition2d);
                _UnitGameObject.GetComponentInChildren<GunRotation>().transform.rotation = Quaternion.RotateTowards(_UnitGameObject.GetComponentInChildren<GunRotation>().transform.rotation, aim_tilt.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping);
            }
            else
            {

                //Transform aim_tilt = _UnitGameObject.GetComponentInChildren<AimTilt>().transform;
                //aim_tilt.LookAt(targetPosition2d);
                //aim_tilt.eulerAngles = new Vector3(aim_tilt.eulerAngles.x, 0, 0);
                //_UnitGameObject.GetComponentInChildren<TurretRotation>().transform.LookAt(targetPosition2d);
                _UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation = Quaternion.RotateTowards(_UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation, aim_pan.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping * 2);
            }
        }
    }
    /*
    public void Targeting(GameObject possibleTarget, string strCollider)
    {
        //UnityEngine.Debug.Log(string.Format("Targeting Triggered {0}", _UnitGameObject.transform.position));
        if (possibleTarget.GetComponent<UnitController>() != null && _CurTarget == null)
        {
            if (possibleTarget.GetComponent<UnitController>().ThisUnit._CurTeam != _CurTeam && possibleTarget.GetComponent<UnitController>().ThisUnit._IsShootable && !possibleTarget.GetComponent<UnitController>().ThisUnit._IsDead)
            {
                _CurTarget = possibleTarget;
            }
        }
    }
    /*
    public virtual GameObject Shoot(GameObject curTargetGameObject, string strCollider)
    {
        
            //Debug.Log(string.Format("Shoot Triggered {0}", _UnitGameObject.transform.position));
        if (curTargetGameObject.GetComponent<UnitController>() != null && _CurTarget != null && _CanShoot && !_IsDead)
        {
            if (_CurTarget.GetComponent<UnitController>() != null && _CurTarget.GetComponent<UnitController>().ThisUnit._UnitType != UType.PlayerPlane && (_Weapons == WeaponsType.Guns || _Weapons == WeaponsType.GunsAndMissiles))
            {
                if (_ShotOriginTransform1 != null && _NextGunShot <= Time.time)
                {
                    _NextGunShot = Time.time + _GunFireRate;
                    GameObject theshot = Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().gunShot, _ShotOriginTransform1.position, _ShotOriginTransform1.rotation) as GameObject;
                    _NextGunShot = Time.time + _GunFireRate;
                    _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().shotFiredAudioSource.Play();
                    if (theshot != null && theshot.GetComponent<UnitController>() != null)
                    {
                        theshot.GetComponent<UnitController>().curTeam = _CurTeam;
                        theshot.GetComponent<UnitController>().dealDamage = _GunAttackDamage;
                        theshot.GetComponent<UnitController>().gunRange = _GunRange;
                    }
                }
            }
            else if (_CurTarget.GetComponent<UnitController>().ThisUnit._UnitType != UType.PlayerPlane && (_Weapons == WeaponsType.Missiles || _Weapons == WeaponsType.GunsAndMissiles))
            {
                
            }
        }


        return curTargetGameObject;
    }
    /*
    public virtual GameObject Move(GameObject curClosestGameObject, Transform curUnitTransform)
    {
        //UnityEngine.Debug.Log("Running Move Function");
        if (_CanMove && !_IsDead && _UnitProgram != ProgramType.StandGround)
        {
            //UnityEngine.Debug.Log("First If Statement, Can Move");
            //if (curClosestGameObject.GetComponent<UnitController>() = null && curClosestGameObject.GetComponent<UnitController>().ThisUnit._CurTeam != _CurTeam && !curClosestGameObject.GetComponent<UnitController>().ThisUnit._IsDead)
            //{
            var distance = 4000f;
            switch (_UnitProgram)
            {
                case ProgramType.Guard:
                    //UnityEngine.Debug.Log(string.Format("Guard Triggered {0}", _UnitGameObject.transform.position));
                    if (_CurTarget != null && _CurTarget.GetComponent<UnitController>().ThisUnit._IsShootable && !_CurTarget.GetComponent<UnitController>().ThisUnit._IsDead)
                    {
                        distance = Vector3.Distance(_UnitGameObject.transform.position, _CurTarget.transform.position);
                        if (distance > _GunRange/1.25f)
                        {
                            _UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = _GunRange / 1.25f;
                            _UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(_CurTarget.transform.position);
                        }
                        else
                        {
                            _UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = _GunRange / 1.25f;
                            _UnitGameObject.GetComponent<NavMeshAgent>().Stop();
                        }
                    }
                    else if (_UnitGameObject.transform.position != _DropTransform.position)
                    {
                        _UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(_DropTransform.position);
                    }
                    else
                    {
                        _UnitGameObject.GetComponent<NavMeshAgent>().Stop();
                    }





                    break;
                case ProgramType.NearestBase:
                    //NearestBase

                    //UnityEngine.Debug.Log("Nearest Base Case");
                    //UnityEngine.Debug.Log(string.Format("FindingNearestBase Function Ran"));
                    {
                        GameObject tempClosestBase = null;
                        // Using a LINQ list to find the shortest distance
                        foreach (var smallBase in BaseStaticValues.SmallBaseArray.Where(smallBase => smallBase.GetComponent<UnitController>() != null && _CurTeam != null && smallBase.GetComponent<UnitController>().ThisUnit._CurTeam != _CurTeam).Where(smallBase => distance >= Vector3.Distance(smallBase.transform.position, _CurrentTransform.position)))
                        {
                            distance = Vector3.Distance(smallBase.transform.position, _CurrentTransform.position);
                            tempClosestBase = smallBase;
                            //UnityEngine.Debug.Log(string.Format("Closest Small Base {0}", smallBase));
                        }
                        // Using a LINQ list to find the shortest distance
                        foreach (var mainBase in BaseStaticValues.MainBaseArray.Where(mainBase => mainBase.GetComponent<UnitController>() != null && _CurTeam != null && mainBase.GetComponent<UnitController>().ThisUnit._CurTeam != _CurTeam).Where(mainBase => distance >= Vector3.Distance(mainBase.transform.position, _CurrentTransform.position)))
                        {
                            distance = Vector3.Distance(mainBase.transform.position, _CurrentTransform.position);
                            tempClosestBase = mainBase;
                            //UnityEngine.Debug.Log(string.Format("Closest Main Base {0}", mainBase));
                        }

                        if (tempClosestBase != null)
                        {
                            //UnityEngine.Debug.Log(string.Format("Closest Base Returned: {0}", tempClosestBase.transform.position));
                        }

                        curClosestGameObject = tempClosestBase;

                        if (curClosestGameObject != null)
                        {
                            distance = Vector3.Distance(_UnitGameObject.transform.position, curClosestGameObject.transform.position);
                            if (_UnitType == UType.Infantry && curClosestGameObject.GetComponent<UnitController>().ThisUnit._UnitType == UType.SmallBase)
                            {
                                _UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(curClosestGameObject.transform.position.x + 10.2f,
                                    curClosestGameObject.transform.position.y,
                                    curClosestGameObject.transform.position.z + 10.2f));
                            }
                            else
                            {
                                _UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = _GunRange / 2;
                                _UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(curClosestGameObject.transform.position);
                            }
                        }
                    }
                    break; //NearestBase
                case ProgramType.AttackMain:
                    //# AttackMain
                    distance = 4000f;
                    if (_CurTeam == "Player1")
                    {
                        curClosestGameObject = BaseStaticValues.MainBaseArray[2 - 1];
                        _UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
                        _UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(curClosestGameObject.transform.position);
                    }
                    else
                    {
                        curClosestGameObject = BaseStaticValues.MainBaseArray[1 - 1];
                        _UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
                        _UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(curClosestGameObject.transform.position);
                    }
                    break; //# AttackMain
                case ProgramType.Shot:
                    if (Vector3.Distance(_CurrentTransform.position, _DropTransform.position) < _GunRange)
                    {
                        _UnitGameObject.GetComponent<Rigidbody>().velocity = _CurrentTransform.forward*BaseStaticValues.Shot.Velocity*Time.deltaTime;
                    }
                    else
                    {
                        Destroy(_UnitGameObject);
                    }

                    break;
                case ProgramType.Missile:

                    break;
                case ProgramType.PlayerPlane:

                    break;
                case ProgramType.PlayerMech:

                    break;
                case ProgramType.CompPlane:

                    break;
                case ProgramType.CompMech:

                    break;
            }
            //}
        }
        return curClosestGameObject;
    }
    */
    
    public void Death()
    {
        if (_IsDead)
        {
            _CanMove = false;
            _CanShoot = false;
            _IsShootable = false;

            if (_UnitType == UType.PlayerPlane || _UnitType == UType.PlayerMech)
            {
                _IsDead = false;
                _UnitGameObject.SetActive(false);
                
                //! Have an Explosion Have camera Quickly Pan back to base (Or just have ship quickly Move back, because camera will follow)
                Respawn();
            }
            else
            {
                //! Have and Explosion and or a slow transition through the terrain
                if (_UnitType != UType.MainBase)
                {
                    Destroy(_UnitGameObject);
                }
            }
        }
    }

    // If unit dies will re-spawn at base
    public void Respawn()
    {
        Transform tempRespawnTransform = null;
        if (GameObject.FindGameObjectWithTag(_CurTeam + "SpawnPoint"))
        {
            tempRespawnTransform = GameObject.FindGameObjectWithTag(_CurTeam + "SpawnPoint").transform;

            if (_UnitType == UType.PlayerPlane)
            {
                _Life = BaseStaticValues.Player.MaxLife;
                _Energy = BaseStaticValues.Player.MaxEnergy;
                _Guns = BaseStaticValues.Player.MaxGuns;
                if (GameObject.FindGameObjectWithTag(_CurTeam + "SpawnPoint") && tempRespawnTransform)
                {
                    _UnitGameObject.transform.position = tempRespawnTransform.position;
                    _UnitGameObject.transform.rotation = tempRespawnTransform.rotation;
                }
                // Put Delay and something for re-spawn effect
                _UnitGameObject.SetActive(true);
                // Re-initialize PlayerValues
                _UnitGameObject.GetComponent<UnitController>().ThisUnit = new PlayerPlane(_CurTeam, _UnitGameObject);
            }
            else
            {
                // Put Delay and something for re-spawn effect
                // Create new PlayerPlane Unit at tempRespawnTransform
                Destroy(_UnitGameObject);
                _Life = BaseStaticValues.Player.MaxLife;
                _Energy = BaseStaticValues.Player.MaxEnergy;
                _Guns = BaseStaticValues.Player.MaxGuns;
                GameObject jetGameObject = (GameObject)Resources.Load("LatestPrefabVersions/Jet");
                jetGameObject.GetComponent<UnitController>().curTeam = "Player1";
                jetGameObject.GetComponent<UnitController>().unitType = "PlayerPlane";
                jetGameObject.GetComponent<UnitController>().curProgram = "PlayerPlane";
                if (GameObject.FindGameObjectWithTag(_CurTeam + "SpawnPoint") && tempRespawnTransform)
                {
                    Instantiate(jetGameObject, tempRespawnTransform.position, tempRespawnTransform.rotation);
                }
            }
            _CanMove = true;
            _CanShoot = true;
            _IsShootable = true;
        }
    }

    public virtual void SwitchPlayer(GameObject gameObject){}
    public virtual void dropCargo(){}
    public virtual void createCargo(string unit, string program) {}
    public virtual bool pickupCargo(GameObject Cargo)
    {
        return false;
    }
    // Might need to implement this in the UnitController instead of the unit Class
    // Run when you hit the button for Transform/DropOff and PickUp
    public void TransformPickUpDropOff(GameObject unitPickUp = null)
    {
        // Checks if it is a PLayer and it can Transform
        // If it can't Transform then, it can't drop off units
        if (_CanTransform && (_UnitType == UType.PlayerPlane || _UnitType == UType.PlayerMech))
        {
            // Tests if there is cargo(to drop-off) or a unit for pickup
            if (_Cargo != null || unitPickUp != null)
            {
                // Tests If your picking up after dropping off or vice-versa too soon
                // To prevent immediate pickup after drop off or vice-versa
                if (_NextPickUpAfterDropOff <= Time.time)
                {
                    // Test if there is a unit to pickup and you have enough space in your cargo-hold for it
                    if (unitPickUp != null && _CargoCapacity <= unitPickUp.GetComponent<UnitController>().ThisUnit._CargoSpaceOfUnit)
                    {
                        _NextPickUpAfterDropOff = Time.time + BaseStaticValues.Player.PickUpDropOffRate;
                        //! Pickup Unit and store in Cargo and Decrement CargoSpaceOfUnit
                        //! Need to save all attributes of the unit in the cargo bay
                    }
                    // If there is no unit you are trying to pickup and you have cargo
                    else if (_Cargo != null && unitPickUp == null)
                    {
                        _NextPickUpAfterDropOff = Time.time + BaseStaticValues.Player.PickUpDropOffRate;
                        //! DropOff unit and Increment CargoSpaceOfUnit
                        //! Need to set all the attributes of the unit to the new instantiation of the unit.
                    }
                }
            }
            // If there is no Cargo and there is no Unit to PickUP - TRANSFORM (More than meets the eye)
            else 
            {
                // Tests if your transforming too soon
                if (_NextTimeToTransform <= Time.time)
                {
                    // Tests which form the Player is currently in and Change to the opposite
                    if (_UnitType == UType.PlayerPlane)
                    {
                        _NextTimeToTransform = Time.time + BaseStaticValues.Player.TransformRate;
                        //! Change to PlayerMech
                        //! Pass all the (Life, Energy, Guns, and _NextTimeToTransform ) of Plane to Mech
                        Destroy(_UnitGameObject);
                    }
                    else
                    {
                        _NextTimeToTransform = Time.time + BaseStaticValues.Player.TransformRate;
                        //! Change to PlayerPlane
                        //! Pass all the (Life, Energy, Guns, and _NextTimeToTransform ) of Mech to Plane
                        Destroy(_UnitGameObject);
                    }
                }
            }
        }
    }

    public void RegenUnitOrderPickUp()
    {
        // If Currently Over base YouCan't Transfrom and Your Currently Regenerating
        if (!_CanTransform)
        {
            //! Regenerate Life, Guns, Energy
            //! Pickup Unit that is Ordered
            
        }
    }

    /// <summary>
    /// Bases the capture.
    /// </summary>
    /// <param name="otherGameObject">The other game object.</param>
    public void BaseCapture(GameObject otherGameObject)
    {
        // Tests if Current Unit is a SmallBase
        if (otherGameObject != null && _UnitType == UType.SmallBase)
        {
            // Tests if the unit that entered the base is on Player1's Team 
            if (otherGameObject.GetComponent<UnitController>().ThisUnit._CurTeam == "Player1")
            {
                // Tests if the # of units in the base is less than 4
                if (_Player1UnitCapture < 4)
                {
                    // Removes the infantry unit that entered the base
                    DestroyObject(otherGameObject);
                    // Increments the _Player1UnitCapture
                    _Player1UnitCapture += 1;

                    // Switch is used to change the color of the Spheres that indicate the # of units for Player1 are in the base
                    switch (_Player1UnitCapture)
                    {
                        case 1:
                            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere1>().ColorCaptured("Player1");
                            break;
                        case 2:
                            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere2>().ColorCaptured("Player1");
                            break;
                        case 3:
                            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere3>().ColorCaptured("Player1");
                            break;
                        case 4:
                            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere4>().ColorCaptured("Player1");
                            break;
                    }
                    
                    // Tests if Player2 has any units in the base
                    if (_Player2UnitCapture > 0)
                    {
                        // Changes the Spheres for Player 2 back to a Neutral color to show how many units are needed to recapture/prevent capture
                        switch (_Player2UnitCapture)
                        {
                            case 1:
                                _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere1>().ColorCaptured("Neutral");
                                break;
                            case 2:
                                _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere2>().ColorCaptured("Neutral");
                                break;
                            case 3:
                                _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere3>().ColorCaptured("Neutral");
                                break;
                            case 4:
                                _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere4>().ColorCaptured("Neutral");
                                break;
                        }
                        // Decrements _PLayer2UnitCapture
                        _Player2UnitCapture -= 1;
                    }
                }
            }
            else // Since the Unit isn't for Player1 then it figures it must be Player2's Infantry Unit
            {
                // Tests if the # of units in the base is less than 4
                if (_Player2UnitCapture < 4)
                {
                    // Removes the infantry unit that entered the base
                    DestroyObject(otherGameObject);
                    // Increments the _Player2UnitCapture
                    _Player2UnitCapture += 1;
                    // Switch is used to change the color of the Spheres that indicate the # of units for Player2 are in the base
                    switch (_Player2UnitCapture)
                    {
                        case 1:
                            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere1>().ColorCaptured("Player2");
                            break;
                        case 2:
                            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere2>().ColorCaptured("Player2");
                            break;
                        case 3:
                            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere3>().ColorCaptured("Player2");
                            break;
                        case 4:
                            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere4>().ColorCaptured("Player2");
                            break;
                    }
                    // Tests if Player1 has any units in the base
                    if (_Player1UnitCapture > 0)
                    {
                        // Changes the Spheres for Player1 back to a Neutral color to show how many units are needed to recapture/prevent capture
                        switch (_Player1UnitCapture)
                        {
                            case 1:
                                _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere1>().ColorCaptured("Neutral");
                                break;
                            case 2:
                                _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere2>().ColorCaptured("Neutral");
                                break;
                            case 3:
                                _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere3>().ColorCaptured("Neutral");
                                break;
                            case 4:
                                _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere4>().ColorCaptured("Neutral");
                                break;
                        }
                        // Decrements _Player1UnitCapture
                        _Player1UnitCapture -= 1;
                    }
                }
            }
            // When _Player1UnitCapture = 4 then switch team to Player1
            if (_Player1UnitCapture == 4)
            {
                UnityEngine.Debug.Log("Building Captured for Player1");
                _CurTeam = "Player1";
                foreach (var mapBeacon in _MiniMapBeacon)
                {
                    mapBeacon.ColorCaptured("Player1");
                }
                foreach (var theLights in _AreaLightsArray)
                {
                    theLights.ColorCaptured("Player1");
                }
            }

            // When _Player2UnitCapture = 4 then switch team to Player2
            if (_Player2UnitCapture == 4)
            {
                UnityEngine.Debug.Log("Building Captured for Player2");
                _CurTeam = "Player2";
                foreach (var mapBeacon in _MiniMapBeacon)
                {
                    mapBeacon.ColorCaptured("Player2");
                }
                foreach (var theLights in _AreaLightsArray)
                {
                    theLights.ColorCaptured("Player2");
                }
            }
        }
    }
    public abstract GameObject _UnitGameObject { get; set; }


}

// Infantry movement class
public sealed class Infantry : Unit
{
    public Infantry()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = BaseStaticValues.Infantry.MaxLife;
        _Energy = BaseStaticValues.Infantry.MaxEnergy;
        _Guns = BaseStaticValues.Infantry.MaxGuns;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public Infantry
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject = null,
        int life = BaseStaticValues.Infantry.MaxLife,
        float energy = BaseStaticValues.Infantry.MaxEnergy,
        int guns = BaseStaticValues.Infantry.MaxGuns,
        UType unitType = UType.Infantry
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _CanMove = true;
        _IsDead = false;
        _Life = life;
        _Energy = energy;
        _Guns = guns;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            }
        }
        if (_CurTeam == "Player2")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get { return BaseStaticValues.Infantry.GunRange; } set { } }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get { return BaseStaticValues.Infantry.LineOfSight; } set { } }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.Infantry.Weapons; } set { } }
    public override int _GunAttackDamage { get { return BaseStaticValues.Infantry.GunDamage; } set { } }
    public override int _CargoSpaceOfUnit { get { return BaseStaticValues.Infantry.CargoSpace; } set { } }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get{ return BaseStaticValues.Infantry.GunFireRate; } set { } }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get { return _UnitGameObject.GetComponentsInChildren<GunBarrelEnd>(); } set { } }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class Jeep : Unit
{
    public Jeep()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = BaseStaticValues.Jeep.MaxLife;
        _Energy = BaseStaticValues.Jeep.MaxEnergy;
        _Guns = BaseStaticValues.Jeep.MaxGuns;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public Jeep
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject = null,
        int life = BaseStaticValues.Jeep.MaxLife,
        float energy = BaseStaticValues.Jeep.MaxEnergy,
        int guns = BaseStaticValues.Jeep.MaxGuns,
        UType unitType = UType.Jeep
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Guns = guns;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            }
        }
        if (_CurTeam == "Player2")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get { return BaseStaticValues.Jeep.GunRange; } set { } }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get { return BaseStaticValues.Jeep.LineOfSight; } set { } }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.Jeep.Weapons; } set { } }
    public override int _GunAttackDamage { get { return BaseStaticValues.Jeep.GunDamage; } set { } }
    public override int _CargoSpaceOfUnit { get { return BaseStaticValues.Jeep.CargoSpace; } set { } }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get { return BaseStaticValues.Jeep.GunFireRate; } set { } }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get { return _UnitGameObject.GetComponentsInChildren<GunBarrelEnd>(); } set { } }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override Object[] _Cargo { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

// Tank Unit Class
public sealed class Tank : Unit
{
    
    public Tank()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = BaseStaticValues.Tank.MaxLife;
        _Energy = BaseStaticValues.Tank.MaxEnergy;
        _Guns = BaseStaticValues.Tank.MaxGuns;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public Tank
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject = null,
        int life = BaseStaticValues.Tank.MaxLife,
        float energy = BaseStaticValues.Tank.MaxEnergy,
        int guns = BaseStaticValues.Tank.MaxGuns,
        UType unitType = UType.Tank
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Guns = guns;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            }
        }
        if (_CurTeam == "Player2")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get { return BaseStaticValues.Tank.GunRange; } set { } }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get { return BaseStaticValues.Tank.LineOfSight; } set { } }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.Tank.Weapons; } set { } }
    public override int _GunAttackDamage { get { return BaseStaticValues.Tank.GunDamage; } set { } }
    public override int _CargoSpaceOfUnit { get { return BaseStaticValues.Tank.CargoSpace; } set { } }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get { return BaseStaticValues.Tank.GunFireRate; } set { } }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get { return _UnitGameObject.GetComponentsInChildren<GunBarrelEnd>(); } set { } }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class SAM : Unit
{
    public SAM()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = BaseStaticValues.SAM.MaxLife;
        _Energy = BaseStaticValues.SAM.MaxEnergy;
        _Missiles = BaseStaticValues.SAM.MaxMissiles;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public SAM
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject = null,
        int life = BaseStaticValues.SAM.MaxLife,
        float energy = BaseStaticValues.SAM.MaxEnergy,
        int missiles = BaseStaticValues.SAM.MaxMissiles,
        UType unitType = UType.SAM
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = missiles;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            }
        }
        if (_CurTeam == "Player2")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get; set; }
    public override float _MissileRange { get { return BaseStaticValues.Missile.Range; } set { } }
    public override float _GuardRange { get { return BaseStaticValues.SAM.LineOfSight; } set { } }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.SAM.Weapons; } set { } }
    public override int _GunAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get { return BaseStaticValues.SAM.CargoSpace; } set { } }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get; set; }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get; set; }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class Turret : Unit
{
    public Turret()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = BaseStaticValues.Turret.MaxLife;
        _Energy = BaseStaticValues.Turret.MaxEnergy;
        _Guns = BaseStaticValues.Turret.MaxGuns;
        _Missiles = BaseStaticValues.Turret.MaxMissiles;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public Turret
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject = null,
        int life = BaseStaticValues.Turret.MaxLife,
        float energy = BaseStaticValues.Turret.MaxEnergy,
        int guns = BaseStaticValues.Turret.MaxGuns,
        int missiles = BaseStaticValues.Turret.MaxMissiles,
        UType unitType = UType.Turret
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = missiles;
        _Guns = guns;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            }
        }
        if (_CurTeam == "Player2")
        {
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get { return BaseStaticValues.Turret.GunRange; } set { } }
    public override float _MissileRange { get { return BaseStaticValues.Missile.Range; } set { } }
    public override float _GuardRange { get { return BaseStaticValues.Turret.LineOfSight; } set { } }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.Turret.Weapons; } set { } }
    public override int _GunAttackDamage { get { return BaseStaticValues.Turret.GunDamage; } set { } }
    public override int _CargoSpaceOfUnit { get { return BaseStaticValues.Turret.CargoSpace; } set { } }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get { return BaseStaticValues.Turret.GunFireRate; } set { } }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get { return _UnitGameObject.GetComponentsInChildren<GunBarrelEnd>(); } set { } }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class SmallBase : Unit
{
    
    public SmallBase()
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = true;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public SmallBase
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject, 
        UType unitType = UType.SmallBase
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = true;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _AreaLightsArray = _UnitGameObject.GetComponentsInChildren<AreaLightColor>();
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            _Player1UnitCapture = 4;
            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere1>().ColorCaptured("Player1");
            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere2>().ColorCaptured("Player1");
            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere3>().ColorCaptured("Player1");
            _UnitGameObject.GetComponentInChildren<Player1UnitCapture>().GetComponentInChildren<Sphere4>().ColorCaptured("Player1");
            foreach (var theLights in _AreaLightsArray)
            {
                theLights.ColorCaptured("Player1");
            }
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            };
        }

        if (_CurTeam == "Player2")
        {
            _Player2UnitCapture = 4;
            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere1>().ColorCaptured("Player2");
            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere2>().ColorCaptured("Player2");
            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere3>().ColorCaptured("Player2");
            _UnitGameObject.GetComponentInChildren<Player2UnitCapture>().GetComponentInChildren<Sphere4>().ColorCaptured("Player2");
            foreach (var theLights in _AreaLightsArray)
            {
                theLights.ColorCaptured("Player2");
            }
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get; set; }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }     
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }     
    public override WeaponsType _Weapons { get; set; }
    public override int _GunAttackDamage { get; set; }     
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get; set; }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get; set; }
    public override Transform _ShotOriginTransform1 { get; set; }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class MainBase : Unit
{
    
    public MainBase()
    {
        _IsShootable = true;
        _CanShoot = false;
        _IsCapturable = false;
        _Life = BaseStaticValues.MainBase.MaxLife;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public MainBase
        (
        string curTeam, 
        ProgramType unitProgram, 
        GameObject unitGameObject = null, 
        int life = BaseStaticValues.MainBase.MaxLife, 
        UType unitType = UType.MainBase
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = false;
        _IsCapturable = false;
        _Life = life;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        if (_UnitGameObject)
        {
            _AreaLightsArray = _UnitGameObject.GetComponentsInChildren<AreaLightColor>();
            _MiniMapBeacon = _UnitGameObject.GetComponentsInChildren<MiniMapBeacon>();
        }
        if (_CurTeam == "Player1")
        {
            foreach (var theLights in _AreaLightsArray)
            {
                theLights.ColorCaptured("Player1");
            }
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player1");
            }
        }

        if (_CurTeam == "Player2")
        {
            foreach (var theLights in _AreaLightsArray)
            {
                theLights.ColorCaptured("Player2");
            }
            foreach (var mapBeacon in _MiniMapBeacon)
            {
                mapBeacon.ColorCaptured("Player2");
            }
        }
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life 
    { 
        get { if (_CurTeam == "Player1") { return (int)GameObject.FindGameObjectWithTag("Player1BaseHealth").GetComponent<Slider>().value; }
            return (int)GameObject.FindGameObjectWithTag("Player2BaseHealth").GetComponent<Slider>().value;
        }
        set { if (_CurTeam == "Player1") { GameObject.FindGameObjectWithTag("Player1BaseHealth").GetComponent<Slider>().value = value; return; }
            GameObject.FindGameObjectWithTag("Player2BaseHealth").GetComponent<Slider>().value = value;
        }
    }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get; set; }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get; set; }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get; set; }
    public override Transform _ShotOriginTransform1 { get; set; }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class Shot : Unit
{
    
    public Shot()
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = false;
        _GunAttackDamage = 0;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public Shot
        (
        string curTeam, 
        GameObject unitGameObject,
        int damage = 3,
        ProgramType unitProgram = ProgramType.Shot, 
        UType unitType = UType.Shot)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = false;
        _Damage = damage;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        _DropPosition = unitGameObject.transform.position;
        _DropRotation = unitGameObject.transform.rotation;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get; set; }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get; set; }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get; set; }
    public override Transform _ShotOriginTransform1 { get; set; }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class Missile : Unit
{

    public Missile()
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = false;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public Missile
        (
        string curTeam,
        GameObject unitGameObject = null,
        ProgramType unitProgram = ProgramType.Missile,
        UType unitType = UType.Missile)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = false;
        _CanMove = false;
        _IsDead = false;
        _UnitGameObject = unitGameObject;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override float _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override float _GunRange { get; set; }
    public override float _MissileRange { get { return BaseStaticValues.Missile.Range; } set { } }
    public override float _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoCapacity { get; set; }
    public override int _Damage { get { return BaseStaticValues.Missile.Damage; } set { } }
    public override float _GunFireRate { get; set; }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get; set; }
    public override Transform _ShotOriginTransform1 { get; set; }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public class UnitProgram
{
    public UnitProgram(GameObject obj, string program)
    {
        _GameObject = obj;
        _Program = program;
    }
    public GameObject _GameObject
    {
        get;
        set;
    }
    public string _Program
    {
        get;
        set;
    }
}

public sealed class PlayerPlane : Unit
{
    
    public PlayerPlane()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
        _CargoCapacity = 1;
        _startHeight = 35;
        _cargoUsed = 0;
        _mech = (GameObject)Resources.Load("LatestPrefabVersions/Mech");
        _humvee = (GameObject)Resources.Load("LatestPrefabVersions/Jeep");
        _infantry = (GameObject)Resources.Load("LatestPrefabVersions/Infantry");
        _turret = (GameObject)Resources.Load("LatestPrefabVersions/Turret");
        _menuController = GameObject.FindWithTag("MenuController").GetComponent<MenuController>();
        _CurTeam = "Player1";
    }

    public PlayerPlane(
        string curTeam,
        GameObject unitGameObject,
        ProgramType unitProgram = ProgramType.PlayerPlane,
        UType unitType = UType.PlayerPlane
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        _CargoCapacity = 1;
        _startHeight = 35;
        _cargoUsed = 0;
        _mech = (GameObject)Resources.Load("LatestPrefabVersions/Mech");
        _humvee = (GameObject)Resources.Load("LatestPrefabVersions/Jeep");
        _infantry = (GameObject)Resources.Load("LatestPrefabVersions/Infantry");
        _turret = (GameObject)Resources.Load("LatestPrefabVersions/Turret");
        _menuController = GameObject.FindWithTag("MenuController").GetComponent<MenuController>();
        _CurTeam = "Player1";
    }


    private int _startHeight;
    private int _cargoUsed;

    private GameObject _mech;
    private GameObject _humvee;
    private GameObject _infantry;
    private GameObject _turret;
    private MenuController _menuController;

    public List<UnitProgram> _cargo = new List<UnitProgram>();
    //private List<GameObject> _cargo = new List<GameObject>();
    private float _nextFire;
    AudioSource _playerAudio;

    private GunBarrelEnd[] _shotingOrigins;

    public string CurrentTeam;

    private static Dictionary<UType, string> UtypeString = new Dictionary<UType, string>
    {
        {UType.Infantry, "Infantry"},
        {UType.Jeep, "Humvee"},
        {UType.Turret, "Turret"},
    };

    public override void SwitchPlayer(GameObject gameObject)
    {
        var location = new Vector3(_UnitGameObject.transform.position.x, 25.0f, _UnitGameObject.transform.position.z);
        Instantiate(_mech, location, _UnitGameObject.transform.rotation);
        DestroyImmediate(_UnitGameObject);
    }
    
     public override void createCargo(string unit, string program)
    {
        if (_cargoUsed < 3)
        {
            switch (unit)
            {
                case "Humvee":
                    _cargo.Add(new UnitProgram(_humvee, program));
                    _cargoUsed++;
                    break;
                case "Infantry":
                    _cargo.Add(new UnitProgram(_infantry, program));
                    _cargoUsed++;
                    break;
                case "Turret":
                    _cargo.Add(new UnitProgram(_turret, program));
                    _cargoUsed++;
                    break;
                default:
                    break;
            }
        }
        else
        {
            //string display = "not enough room";
        }

        Debug.Log(_cargo.Last()._GameObject + " " + _cargo.Last()._Program + " into cargo");
    }

     public override void dropCargo()
     {
         Debug.Log("dwassup");
         if (_cargo.Count > 0)
         {
             var key = _cargo.First()._GameObject;

             var x = _UnitGameObject.transform.position.x;
             var y = 27.0f;
             var z = _UnitGameObject.transform.position.z;

             var instantiation = new Vector3(x, y, z);
             //var movement = new Vector3(0, 90, 0);
             var rot = new Quaternion(0, 0, 0, 0);
             //var targetRotation = Quaternion.LookRotation(movement, Vector3.up);


             key.GetComponent<UnitController>().curTeam = _CurTeam;
             

             
             // newUnit = (GameObject) Instantiate(_cargo.Keys.First(), instantiation, rot);

             

             switch (_cargo.First()._Program)
             {
                 case "Attack Main":
                     key.GetComponent<UnitController>().curProgram = "Attack Main";
                     break;
                 case "Guard":
                     key.GetComponent<UnitController>().curProgram = "Guard";
                     break;
                 case "Stand Ground":
                     key.GetComponent<UnitController>().curProgram = "Stand Ground";
                     break;
                 case "Attack Nearest Object":
                     key.GetComponent<UnitController>().curProgram = "Nearest Base";
                     break;
                 default:
                     key.GetComponent<UnitController>().curProgram = "Stand Ground";
                     break;

             }

             GameObject newUnit = (GameObject)Instantiate(key, instantiation, rot);

             _cargoUsed--;

             _cargo.Remove(_cargo.First());

         }
     }

     public override bool pickupCargo(GameObject Cargo)
     {
         Debug.Log("pwassup");
         if (UtypeString.ContainsValue(Cargo.tag))
         {
             var ptype = Cargo.GetComponent(_UnitProgram.ToString());
             createCargo(Cargo.tag, ptype.ToString());
             Destroy(Cargo);
             return true;
         }
         else
         {
             return false;
         }
     }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life
    {
        get { if (_CurTeam == "Player1") { return BaseStaticValues.Player1.Life; } return BaseStaticValues.Player2.Life; }
        set 
        {
            if (_CurTeam == "Player1")
            {
                BaseStaticValues.Player1.Life = value;
                if (GameObject.FindGameObjectWithTag("Player1Health") && GameObject.FindGameObjectWithTag("Player1Health").GetComponent<Slider>() != null)
                {
                    GameObject.FindGameObjectWithTag("Player1Health").GetComponent<Slider>().value = value;
                }
            } 
            BaseStaticValues.Player2.Life = value;
            if (GameObject.FindGameObjectWithTag("Player2Health") && GameObject.FindGameObjectWithTag("Player2Health").GetComponent<Slider>() != null)
            {
                GameObject.FindGameObjectWithTag("Player2Health").GetComponent<Slider>().value = value;
            }
        }
    }
    public override float _Energy
    {
        get { if (_CurTeam == "Player1") { return BaseStaticValues.Player1.Energy; } return BaseStaticValues.Player2.Energy; }
        set
        {
            if (_CurTeam == "Player1")
            {
                BaseStaticValues.Player1.Energy = value;
                if (GameObject.FindGameObjectWithTag("Player1Energy") && GameObject.FindGameObjectWithTag("Player1Energy").GetComponent<Slider>() != null)
                {
                    GameObject.FindGameObjectWithTag("Player1Energy").GetComponent<Slider>().value = value;
                }
            } 
            BaseStaticValues.Player2.Energy = value; 
            if (GameObject.FindGameObjectWithTag("Player2Energy") && GameObject.FindGameObjectWithTag("Player2Energy").GetComponent<Slider>() != null)
            {
                GameObject.FindGameObjectWithTag("Player2Energy").GetComponent<Slider>().value = value;
            }
        }
    }
    public override int _Guns
    {
        get { if (_CurTeam == "Player1") { return BaseStaticValues.Player1.Guns; } return BaseStaticValues.Player2.Guns; }
        set
        {
            if (_CurTeam == "Player1")
            {
                BaseStaticValues.Player1.Guns = value;
                if (GameObject.FindGameObjectWithTag("Player1Guns") && GameObject.FindGameObjectWithTag("Player1Guns").GetComponent<Slider>() != null)
                {
                    GameObject.FindGameObjectWithTag("Player1Guns").GetComponent<Slider>().value = value;
                }
            } 
            BaseStaticValues.Player2.Guns = value; 
            if (GameObject.FindGameObjectWithTag("Player2Guns") && GameObject.FindGameObjectWithTag("Player2Guns").GetComponent<Slider>() != null)
            {
                GameObject.FindGameObjectWithTag("Player2Guns").GetComponent<Slider>().value = value;
            }
        }
    }
    public override int _Missiles { get; set; }
    public override float _GunRange { get { return BaseStaticValues.Player.GunRange; } set { } }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.Player.Weapons; } set { } }
    public override int _GunAttackDamage { get { return BaseStaticValues.Player.GunDamage; } set { } }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoCapacity { get { return BaseStaticValues.Player.MaxCargoCapacity; } set { } }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get { return BaseStaticValues.Player.FireRate; } set { } }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get { return _UnitGameObject.GetComponentsInChildren<GunBarrelEnd>(); } set { } }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class PlayerMech : Unit
{
    
    public PlayerMech()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = null;
    }

    public PlayerMech(
        string curTeam, 
        GameObject unitGameObject,
        ProgramType unitProgram = ProgramType.PlayerMech,
        UType unitType = UType.PlayerMech
        )
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _CanMove = true;
        _IsDead = false;
        _UnitGameObject = unitGameObject;
        
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life
    {
        get { if (_CurTeam == "Player1") { return BaseStaticValues.Player1.Life; } return BaseStaticValues.Player2.Life; }
        set
        {
            if (_CurTeam == "Player1")
            {
                Debug.Log(string.Format("Damage Value: {0}", value));
                BaseStaticValues.Player1.Life += value;
                if (GameObject.FindGameObjectWithTag("Player1Health") && GameObject.FindGameObjectWithTag("Player1Health").GetComponent<Slider>() != null)
                {
                    GameObject.FindGameObjectWithTag("Player1Health").GetComponent<Slider>().value += value;
                }
            }
            BaseStaticValues.Player2.Life = value;
            if (GameObject.FindGameObjectWithTag("Player2Health") && GameObject.FindGameObjectWithTag("Player2Health").GetComponent<Slider>() != null)
            {
                GameObject.FindGameObjectWithTag("Player2Health").GetComponent<Slider>().value += value;
            }
        }
    }
    public override float _Energy
    {
        get { if (_CurTeam == "Player1") { return BaseStaticValues.Player1.Energy; } return BaseStaticValues.Player2.Energy; }
        set
        {
            if (_CurTeam == "Player1")
            {
                BaseStaticValues.Player1.Energy += value;
                if (GameObject.FindGameObjectWithTag("Player1Energy") && GameObject.FindGameObjectWithTag("Player1Energy").GetComponent<Slider>() != null)
                {
                    GameObject.FindGameObjectWithTag("Player1Energy").GetComponent<Slider>().value += value;
                }
            }
            BaseStaticValues.Player2.Energy = value;
            if (GameObject.FindGameObjectWithTag("Player2Energy") && GameObject.FindGameObjectWithTag("Player2Energy").GetComponent<Slider>() != null)
            {
                GameObject.FindGameObjectWithTag("Player2Energy").GetComponent<Slider>().value += value;
            }
        }
    }
    public override int _Guns
    {
        get { if (_CurTeam == "Player1") { return BaseStaticValues.Player1.Guns; } return BaseStaticValues.Player2.Guns; }
        set
        {
            if (_CurTeam == "Player1")
            {
                BaseStaticValues.Player1.Guns = value;
                if (GameObject.FindGameObjectWithTag("Player1Guns") && GameObject.FindGameObjectWithTag("Player1Guns").GetComponent<Slider>() != null)
                {
                    GameObject.FindGameObjectWithTag("Player1Guns").GetComponent<Slider>().value = value;
                }
            }
            BaseStaticValues.Player2.Guns = value;
            if (GameObject.FindGameObjectWithTag("Player2Guns") && GameObject.FindGameObjectWithTag("Player2Guns").GetComponent<Slider>() != null)
            {
                GameObject.FindGameObjectWithTag("Player2Guns").GetComponent<Slider>().value = value;
            }
        }
    }
    public override int _Missiles { get; set; }
    public override float _GunRange { get { return BaseStaticValues.Player.GunRange; } set { } }
    public override float _MissileRange { get; set; }
    public override float _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _Player1UnitCapture { get; set; }
    public override int _Player2UnitCapture { get; set; }
    public override WeaponsType _Weapons { get { return BaseStaticValues.Player.Weapons; } set { } }
    public override int _GunAttackDamage { get { return BaseStaticValues.Player.GunDamage; } set { } }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoCapacity { get { return BaseStaticValues.Player.MaxCargoCapacity; } set { } }
    public override int _Damage { get; set; }
    public override float _GunFireRate { get { return BaseStaticValues.Player.FireRate; } set { } }
    public override Transform _CurrentTransform { get { return _UnitGameObject.transform; } set { } }
    public override Vector3 _DropPosition { get; set; }
    public override Quaternion _DropRotation { get; set; }
    public override GameObject _CurTarget { get; set; }
    public override GameObject _CurDestination { get; set; }
    public override AreaLightColor[] _AreaLightsArray { get; set; }
    public override MiniMapBeacon[] _MiniMapBeacon { get; set; }
    public override Transform _TargetedTransformOffset { get; set; }
    public override Transform _TargetTransform { get; set; }
    public override GunBarrelEnd[] _ShotOrigins { get { return _UnitGameObject.GetComponentsInChildren<GunBarrelEnd>(); } set { } }
    public override Transform _ShotOriginTransform1 { get { return _UnitGameObject.GetComponentInChildren<GunBarrelEnd>().transform; } set { } }
    public override Transform _ShotOriginTransform2 { get; set; }
    public override bool _CanTransform { get; set; }
    public override float _NextTimeToTransform { get; set; }
    public override float _NextPickUpAfterDropOff { get; set; }
    public override float _NextGunShot { get; set; }
    public override float _NextMissileShot { get; set; }
    public override Object[] _Cargo { get; set; }
    public override GameObject _UnitGameObject { get; set; }
}


public class GlobalVariables : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
