using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEditor;

public enum UType
{
    Infantry = 1,
    Jeep = 2,
    Tank = 3,
    SAM = 4,
    Turret = 5,
    SmallBase = 6,
    MainBase = 7,
    Shots = 8,
    PlayerPlane = 9,
    PlayerMech = 10
}

public enum WeaponsType
{
    Guns = 1,
    Missiles = 2,
    GunsAndMissiles = 3
}

public enum ProgramType
{
    StandGround = 1,
    Guard = 2,
    NearestBase = 3,
    AttackMain = 4,
    ShotFired = 5,
}

public abstract class Unit : Object
{
    protected Unit()
    {
        _CurTeam = "Neutral";
    }

    public Unit(string curTeam, ProgramType unitProgram, UType unitType)
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
    public abstract int _Energy { get; set; }
    public abstract int _Guns { get; set; }
    public abstract int _Missiles { get; set; }
    public abstract int _GunRange { get; set; }
    public abstract int _MissileRange { get; set; }
    public abstract int _GuardRange { get; set; }
    public abstract bool _CanMove { get; set; }
    public abstract bool _IsDead { get; set; }
    public abstract WeaponsType _Weapons { get; set; }
    public abstract int _GunAttackDamage { get; set; }
    public abstract int _MissileAttackDamage { get; set; }
    public abstract int _CargoSpaceOfUnit { get; set; }
    public abstract int _CargoSpace { get; set; }
    public abstract GameObject[] _Cargo { get; set; }

    public void TakeDamage(int damageAmount)
    {
        if (_IsShootable && !_IsDead)
        {
            _Life -= damageAmount;
            if (_Life <= 0)
            {
                _IsDead = true;
            }
        }
    }
    public void Shoot(GameObject curTargetGameObject)
    {
        if (_CanShoot && !_IsDead)
        {

        }
    }
    public void Move(GameObject curClosestGameObject)
    {
        if (_CanMove && !_IsDead)
        {

        }
    }

    public void Death()
    {
        if (_IsDead)
        {
            _CanMove = false;
            _CanShoot = false;
            _IsShootable = false;
        }
    }

    public void Respawn()
    {

    }
    public abstract GameObject _UnitGameObject { get; set; }

    
}

// Infantry movement class
public sealed class Infantry : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;
    
    public Infantry()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public Infantry(string curTeam, ProgramType unitProgram, UType unitType = UType.Infantry, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }
    
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class Jeep : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public Jeep()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public Jeep(string curTeam, ProgramType unitProgram, UType unitType = UType.Jeep, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }
    
    public override GameObject _UnitGameObject { get; set; }
}

// Tank Unit Class
public sealed class Tank : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public Tank()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public Tank(string curTeam, ProgramType unitProgram, UType unitType = UType.Tank, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }
    
    public override GameObject _UnitGameObject { get; set; }
}

public sealed class SAM : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public SAM()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public SAM(string curTeam, ProgramType unitProgram, UType unitType = UType.SAM, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }
    
    public override GameObject _UnitGameObject { get; set; }
}


public sealed class Turret : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public Turret()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public Turret(string curTeam, ProgramType unitProgram, UType unitType = UType.Turret, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }
    
    public override GameObject _UnitGameObject { get; set; }
}


public sealed class SmallBase : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public SmallBase()
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = true;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = true;
        _IsDead = false;
    }

    public SmallBase(string curTeam, ProgramType unitProgram, UType unitType = UType.SmallBase, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = true;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }

    public override GameObject _UnitGameObject { get; set; }
}


public sealed class MainBase : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public MainBase()
    {
        _IsShootable = true;
        _CanShoot = false;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public MainBase(string curTeam, ProgramType unitProgram, UType unitType = UType.MainBase, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = false;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }

    public override GameObject _UnitGameObject { get; set; }
}

public sealed class Shots : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public Shots()
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;
    }

    public Shots(string curTeam, ProgramType unitProgram = ProgramType.ShotFired, UType unitType = UType.Shots, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = false;
        _CanShoot = false;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = false;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }

    public override GameObject _UnitGameObject { get; set; }
}


public sealed class PlayerPlane : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public PlayerPlane()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = true;
        _IsDead = false;
    }

    public PlayerPlane(string curTeam, ProgramType unitProgram, UType unitType = UType.PlayerPlane, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = true;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }

    public override GameObject _UnitGameObject { get; set; }
}

public sealed class PlayerMech : Unit
{
    private const int MaxUnitLife = 300;
    private const int MaxUnitEnergy = 100;
    private const int MaxUnitGuns = 100;
    private const int MaxUnitMissiles = 0;
    private const int GunDamage = 8;
    private const int MissileDamage = 0;
    private const int CargoSpaceOfUnit = 1;
    private const int CargoSpace = 0;
    private const GameObject[] Cargo = null;
    private const WeaponsType Weapons = WeaponsType.Guns;

    public PlayerMech()
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = MaxUnitLife;
        _Energy = MaxUnitEnergy;
        _Missiles = MaxUnitMissiles;
        _Guns = MaxUnitGuns;
        _CargoSpaceOfUnit = CargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = Weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = true;
        _IsDead = false;
    }

    public PlayerMech(string curTeam, ProgramType unitProgram, UType unitType = UType.PlayerMech, int life = MaxUnitLife, int energy = MaxUnitEnergy,
        int guns = MaxUnitGuns, WeaponsType weapons = WeaponsType.Guns, int cargoSpaceOfUnit = CargoSpaceOfUnit)
        : base(curTeam, unitProgram, unitType)
    {
        _IsShootable = true;
        _CanShoot = true;
        _IsCapturable = false;
        _Life = life;
        _Energy = energy;
        _Missiles = MaxUnitMissiles;
        _Guns = guns;
        _CargoSpaceOfUnit = cargoSpaceOfUnit;
        _GunAttackDamage = GunDamage;
        _MissileAttackDamage = MissileDamage;
        _Weapons = weapons;
        _CargoSpace = CargoSpace;
        _Cargo = Cargo;
        _UnitGameObject = null;
        _CanMove = true;
        _IsDead = false;

    }

    public override bool _IsShootable { get; set; }
    public override bool _CanShoot { get; set; }
    public override bool _IsCapturable { get; set; }
    public override int _Life { get; set; }
    public override int _Energy { get; set; }
    public override int _Guns { get; set; }
    public override int _Missiles { get; set; }
    public override int _GunRange { get; set; }
    public override int _MissileRange { get; set; }
    public override int _GuardRange { get; set; }
    public override WeaponsType _Weapons { get; set; }
    public override bool _CanMove { get; set; }
    public override bool _IsDead { get; set; }
    public override int _GunAttackDamage { get; set; }
    public override int _MissileAttackDamage { get; set; }
    public override int _CargoSpaceOfUnit { get; set; }
    public override int _CargoSpace { get; set; }
    public override GameObject[] _Cargo { get; set; }
    
    public override GameObject _UnitGameObject { get; set; }
}


public class GlobalVariables : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
