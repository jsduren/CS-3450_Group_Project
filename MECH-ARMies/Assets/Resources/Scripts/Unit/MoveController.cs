using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveController : MonoBehaviour
{
    private float shotDeleteTime = 0;
    private float shotTimeOffset = .5f;
    public GameObject moveClosestBase;
    
	
    // Use this for initialization
    void Start ()
	{
        if (GetComponent<UnitController>() != null && rigidbody != null && GetComponent<UnitController>().ThisUnit._UnitType == UType.Shot)
        {
            rigidbody.velocity = transform.forward * BaseStaticValues.Shot.Velocity;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<UnitController>() != null && GetComponent<UnitController>().ThisUnit._CanMove && !GetComponent<UnitController>().ThisUnit._IsDead)
        {
            
           // Debug.Log(string.Format("UnitController !Null: {0}", gameObject.GetComponent<UnitController>() != null));
         //   Debug.Log(string.Format("UnitController.ThisUnit !Null: {0}", gameObject.GetComponent<UnitController>().ThisUnit != null));
          //  Debug.Log(string.Format("MoveController Execution"));
            //UnityEngine.Debug.Log("First If Statement, Can Move");
            //if (curClosestGameObject.GetComponent<UnitController>() = null && curClosestGameObject.GetComponent<UnitController>().ThisUnit._CurTeam != _CurTeam && !curClosestGameObject.GetComponent<UnitController>().ThisUnit._IsDead)
            //{
            var distance = 4000f;
            switch (gameObject.GetComponent<UnitController>().ThisUnit._UnitProgram)
            {
                case ProgramType.StandGround:
                    //Do Nothing
                    break;
                case ProgramType.Guard:
                    //UnityEngine.Debug.Log(string.Format("Guard Triggered {0}", _UnitGameObject.transform.position));
                    if (gameObject.GetComponent<UnitController>().ThisUnit._CurTarget != null && gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>().ThisUnit._IsShootable && !gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>().ThisUnit._IsDead)
                    {
                        distance = Vector3.Distance(gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.transform.position,gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.transform.position);
                        if (distance > gameObject.GetComponent<UnitController>().ThisUnit._GunRange / 1.25f)
                        {
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = gameObject.GetComponent<UnitController>().ThisUnit._GunRange / 1.25f;
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.transform.position);
                        }
                        else
                        {
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = gameObject.GetComponent<UnitController>().ThisUnit._GunRange / 1.25f;
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().Stop();
                        }
                    }
                    else if (gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.transform.position != gameObject.GetComponent<UnitController>().ThisUnit._DropPosition)
                    {
                        gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(gameObject.GetComponent<UnitController>().ThisUnit._DropPosition);
                    }
                    else
                    {
                        gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().Stop();
                    }

                    break;
                case ProgramType.NearestBase:
                    //NearestBase

                    //UnityEngine.Debug.Log("Nearest Base Case");
                    //UnityEngine.Debug.Log(string.Format("FindingNearestBase Function Ran"));
                    {
                        GameObject tempClosestBase = null;
                        // Using a LINQ list to find the shortest distance
                        foreach (var smallBase in BaseStaticValues.SmallBaseArray.Where(smallBase => smallBase != null && smallBase.GetComponent<UnitController>() != null && gameObject.GetComponent<UnitController>().ThisUnit._CurTeam != null && smallBase.GetComponent<UnitController>().ThisUnit._CurTeam != gameObject.GetComponent<UnitController>().ThisUnit._CurTeam).Where(smallBase => distance >= Vector3.Distance(smallBase.transform.position, gameObject.GetComponent<UnitController>().ThisUnit._CurrentTransform.position)))
                        {
                            
                            distance = Vector3.Distance(smallBase.transform.position, gameObject.GetComponent<UnitController>().ThisUnit._CurrentTransform.position);
                            tempClosestBase = smallBase;
                            //UnityEngine.Debug.Log(string.Format("Closest Small Base {0}", smallBase));
                        }
                        // Using a LINQ list to find the shortest distance
                        foreach (var mainBase in BaseStaticValues.MainBaseArray.Where(mainBase => mainBase != null && mainBase.GetComponent<UnitController>() != null && gameObject.GetComponent<UnitController>().ThisUnit._CurTeam != null && mainBase.GetComponent<UnitController>().ThisUnit._CurTeam != gameObject.GetComponent<UnitController>().ThisUnit._CurTeam).Where(mainBase => distance >= Vector3.Distance(mainBase.transform.position, gameObject.GetComponent<UnitController>().ThisUnit._CurrentTransform.position)))
                        {
                            distance = Vector3.Distance(mainBase.transform.position, gameObject.GetComponent<UnitController>().ThisUnit._CurrentTransform.position);
                            tempClosestBase = mainBase;
                            //UnityEngine.Debug.Log(string.Format("Closest Main Base {0}", mainBase));
                        }

                        if (tempClosestBase != null)
                        {
                            //UnityEngine.Debug.Log(string.Format("Closest Base Returned: {0}", tempClosestBase.transform.position));
                        }

                        
                        moveClosestBase = tempClosestBase;

                        Debug.Log(string.Format("Closest Base Returned: {0}", moveClosestBase.transform.position));

                        if (tempClosestBase != null)
                        {
                            distance = Vector3.Distance(gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.transform.position, moveClosestBase.transform.position);
                            if (gameObject.GetComponent<UnitController>().ThisUnit._UnitType == UType.Infantry && moveClosestBase.GetComponent<UnitController>().ThisUnit._UnitType == UType.SmallBase)
                            {
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(moveClosestBase.transform.position.x,
                                    moveClosestBase.transform.position.y,
                                    moveClosestBase.transform.position.z));
                            }
                            else
                            {
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = gameObject.GetComponent<UnitController>().ThisUnit._GunRange / 2;
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(moveClosestBase.transform.position);
                            }
                        }
                    }
                    break; //NearestBase
                case ProgramType.AttackMain:
                    //# AttackMain
                    distance = 4000f;
                    if (moveClosestBase && gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>())
                    {
                        if (gameObject.GetComponent<UnitController>().ThisUnit._CurTeam == "Player1")
                        {
                            if (BaseStaticValues.MainBaseArray[2 - 1] != null)
                            {
                                moveClosestBase = BaseStaticValues.MainBaseArray[2 - 1];
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(moveClosestBase.transform.position);
                            }
                        }
                        else
                        {
                            if (BaseStaticValues.MainBaseArray[1 - 1] != null)
                            {
                                moveClosestBase = BaseStaticValues.MainBaseArray[1 - 1];
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
                                gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.GetComponent<NavMeshAgent>().SetDestination(moveClosestBase.transform.position);
                            }
                        }
                    }
                    break; //# AttackMain
                case ProgramType.Shot:
                    
                    if (gameObject && Vector3.Distance(transform.position, GetComponent<UnitController>().ThisUnit._DropPosition) >= GetComponent<UnitController>().ThisUnit._GunRange)
                    {
                        if (gameObject != null)
                        {
                            Destroy(gameObject);
                        }
                    }

                    if (gameObject && rigidbody.velocity != transform.forward * BaseStaticValues.Shot.Velocity && shotDeleteTime >= Time.time)
                    {
                        if (gameObject)
                        {
                            Destroy(gameObject);
                        }
                    }
                    break;
                case ProgramType.Missile:

                    break;
                case ProgramType.PlayerPlane:
                    //Debug.Log(string.Format("PlayerPlane Move: x:{0}, z:{1}", Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
                    var x = Input.GetAxis("Horizontal");
                    var z = Input.GetAxis("Vertical");
                    if (GameObject.FindWithTag("MenuController").GetComponent<MenuController>().IsVisible)
                    {
                        x = 0;
                        z = 0;
                    }
                    var movement = new Vector3(x, 0.0f, z);
                    if (movement.magnitude <= 0)
                    {
                        
                        //this executes if the player is not pressing any buttons
                        if (
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.rigidbody.velocity.magnitude > 0.1f)
                        {
                            //this slows down the jet slowly
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.rigidbody.velocity *= 0.1f;
                        }
                        else
                        {
                            rigidbody.freezeRotation = true;
                            gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.rigidbody.velocity *= 0;
                            
                        }
                    }
                    else
                    {
                       // Debug.Log(string.Format("movement.magnitude <= 0:{0} x:{1}, z:{2}", movement.magnitude, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
                        
                        gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.rigidbody.velocity = movement * BaseStaticValues.Player.Speed;
                        var targetRotation = Quaternion.LookRotation(movement, Vector3.up);
                        var newRotation = Quaternion.Lerp(gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.rigidbody.rotation, targetRotation, 15f * Time.deltaTime);
                        gameObject.GetComponent<UnitController>().ThisUnit._UnitGameObject.rigidbody.rotation = newRotation;
                    }
                    break;
                case ProgramType.PlayerMech:

                    break;
                case ProgramType.CompPlane:

                    break;
                case ProgramType.CompMech:

                    break;
            }
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (gameObject && GetComponent<UnitController>() != null && GetComponent<UnitController>().ThisUnit._UnitType == UType.Shot)
        {
            shotDeleteTime = Time.time + shotTimeOffset;
            rigidbody.velocity = transform.forward * 0;
        }
    }

}
