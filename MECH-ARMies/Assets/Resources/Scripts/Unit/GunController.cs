using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1"))
	    {
            Shoot();
	    }

	}

    public void Shoot()
    {
        if (gameObject.GetComponent<UnitController>().ThisUnit._UnitType == UType.PlayerPlane || gameObject.GetComponent<UnitController>().ThisUnit._UnitType == UType.PlayerMech)
        {
            if (gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins != null && gameObject.GetComponent<UnitController>().ThisUnit._NextGunShot <= Time.time)
            {
                gameObject.GetComponent<UnitController>().ThisUnit._NextGunShot = Time.time + BaseStaticValues.Player.FireRate;

                GameObject[] shots = new GameObject[gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins.Length];

                GameObject shot = (GameObject)Resources.Load("LatestPrefabVersions/Shot");
                shot.GetComponent<UnitController>().curTeam = gameObject.GetComponent<UnitController>().ThisUnit._CurTeam;
                shot.GetComponent<UnitController>().dealDamage = gameObject.GetComponent<UnitController>().ThisUnit._GunAttackDamage;
                shot.GetComponent<UnitController>().gunRange = gameObject.GetComponent<UnitController>().ThisUnit._GunRange;

                for (int i = 0; i < gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins.Length; i++)
                {
                    shots[i] =
                        Instantiate(shot,
                            gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins[i].transform.position,
                            gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins[i].transform.rotation) as GameObject;
                }

                gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins[0].shotFiredAudioSource.Play();

                //foreach (var theShot in shots)
                //{
                //    if (theShot != null && theShot.GetComponent<UnitController>() != null)
                //    {
                //        theShot.GetComponent<UnitController>().curTeam = gameObject.GetComponent<UnitController>().ThisUnit._CurTeam;
                //        theShot.GetComponent<UnitController>().dealDamage = gameObject.GetComponent<UnitController>().ThisUnit._GunAttackDamage;
                //        theShot.GetComponent<UnitController>().gunRange = gameObject.GetComponent<UnitController>().ThisUnit._GunRange;
                //    }
                //}
            }
        }
        else
        {
            //Debug.Log(string.Format("Shoot Triggered {0}", _UnitGameObject.transform.position));
            if (gameObject.GetComponent<UnitController>().ThisUnit != null && gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>() != null && gameObject.GetComponent<UnitController>().ThisUnit._CurTarget != null && gameObject.GetComponent<UnitController>().ThisUnit._CanShoot && !gameObject.GetComponent<UnitController>().ThisUnit._IsDead)
            {
                if (gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>() != null &&
                    gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>().ThisUnit._UnitType != UType.PlayerPlane &&
                    (gameObject.GetComponent<UnitController>().ThisUnit._Weapons == WeaponsType.Guns ||
                     gameObject.GetComponent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles))
                {
                    if (gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins != null && gameObject.GetComponent<UnitController>().ThisUnit._NextGunShot <= Time.time)
                    {
                        gameObject.GetComponent<UnitController>().ThisUnit._NextGunShot = Time.time + gameObject.GetComponent<UnitController>().ThisUnit._GunFireRate;

                        GameObject[] shots = new GameObject[gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins.Length];

                        GameObject shot = (GameObject)Resources.Load("LatestPrefabVersions/Shot");
                        shot.GetComponent<UnitController>().curTeam = gameObject.GetComponent<UnitController>().ThisUnit._CurTeam;
                        shot.GetComponent<UnitController>().dealDamage = gameObject.GetComponent<UnitController>().ThisUnit._GunAttackDamage;
                        shot.GetComponent<UnitController>().gunRange = gameObject.GetComponent<UnitController>().ThisUnit._GunRange;

                        for (int i = 0; i < gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins.Length; i++)
                        {
                            shots[i] = Instantiate(shot, gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins[i].transform.position, gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins[i].transform.rotation) as GameObject;
                        }

                        gameObject.GetComponent<UnitController>().ThisUnit._ShotOrigins[0].shotFiredAudioSource.Play();

                        //foreach (var theShot in shots)
                        //{
                        //    if (theShot != null && theShot.GetComponent<UnitController>() != null)
                        //    {
                        //        theShot.GetComponent<UnitController>().curTeam = gameObject.GetComponent<UnitController>().ThisUnit._CurTeam;
                        //        theShot.GetComponent<UnitController>().dealDamage = gameObject.GetComponent<UnitController>().ThisUnit._GunAttackDamage;
                        //        theShot.GetComponent<UnitController>().gunRange = gameObject.GetComponent<UnitController>().ThisUnit._GunRange;
                        //    }
                        //}
                    }
                }
                else if (gameObject.GetComponent<UnitController>().ThisUnit._CurTarget.GetComponent<UnitController>().ThisUnit._UnitType != UType.PlayerPlane &&
                         (gameObject.GetComponent<UnitController>().ThisUnit._Weapons == WeaponsType.Missiles ||
                          gameObject.GetComponent<UnitController>().ThisUnit._Weapons == WeaponsType.GunsAndMissiles))
                {

                }
            }
        }
    }

}
