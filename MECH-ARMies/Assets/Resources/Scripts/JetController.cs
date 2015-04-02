using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JetController : MonoBehaviour
{
    private const int cargoCapacity = 1;
    private float speed = 60;
    private float fireRate = 0.25f;
    private float shootSoundVolume = 1;
    private int startHeight = 35;

    private int cargoUsed = 0;
    private GameObject mech;
    private GameObject humvee;
    private GameObject infantry;
    private GameObject turret;
    private MenuController menuController;

    private AudioClip shotsFired;
    private GameObject shot;
    private Transform shootingOrigin1;
    private Transform shootingOrigin2;
    private List<GameObject> cargo = new List<GameObject>();
    private float nextFire;
    AudioSource playerAudio;

    private Component[] shotingOrigins;

    public string currentTeam;

    private static Dictionary<UType, string> UtypeString = new Dictionary<UType, string>
    {
        {UType.Infantry, "Infantry"},
        {UType.Jeep, "Humvee"},
        {UType.Turret, "Turret"},
    };


    void Start()
    {
        mech = (GameObject)Resources.Load("Prefabs/Mech");
        humvee = (GameObject)Resources.Load("Prefabs/Humvee");
        infantry = (GameObject)Resources.Load("Prefabs/Infantry");
        turret = (GameObject)Resources.Load("Prefabs/Turret");
        shotsFired = (AudioClip)Resources.Load("Audio/UnitShotsFired");
        shot = (GameObject)Resources.Load("Prefabs/Shot1");
        menuController = GameObject.FindWithTag("MenuController").GetComponent<MenuController>();

        shotingOrigins = gameObject.GetComponentsInChildren(typeof (Collider));

        shootingOrigin1 = shotingOrigins[2].transform;
        shootingOrigin2 = shotingOrigins[3].transform;

        playerAudio = GetComponent<AudioSource>();

        var newPosition = new Vector3(transform.position.x, startHeight, transform.position.z);
        gameObject.transform.position = newPosition;

        currentTeam = "Team1";
    }

    void Update()
    {
        if (!menuController.IsVisible)
        {
            //Get out of this block if the menu is visible

            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                playerAudio.clip = shotsFired;
                playerAudio.volume = shootSoundVolume;
                playerAudio.Play();
                Instantiate(shot, shootingOrigin1.position, shootingOrigin1.rotation);
                Instantiate(shot, shootingOrigin2.position, shootingOrigin2.rotation);

            }

            if (Input.GetButtonDown("Change"))
            {
                SwitchPlayer();
            }

            if (Input.GetButtonDown("CargoDrop"))
            {
                if (cargoUsed == 1)
                    dropCargo(cargo);
            }
        }
        Move();
    }

    void SwitchPlayer()
    {
        var location = new Vector3(transform.position.x, 25.0f, transform.position.z);
        Instantiate(mech, location, transform.rotation);
        DestroyImmediate(gameObject);
    }

    void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        if (menuController.IsVisible)
        {
            x = 0;
            z = 0;
        }
        var movement = new Vector3(x, 0.0f, z);
        if (movement.magnitude <= 0)
        {
            //this executes if the player is not pressing any buttons
            if (rigidbody.velocity.magnitude > 0.1f)
            {
                //this slows down the jet slowly
                rigidbody.velocity *= 0.1f;
            }
            else rigidbody.velocity *= 0;
        }
        else
        {
            rigidbody.velocity = movement*speed;
            var targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            var newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 15f*Time.deltaTime);
            rigidbody.rotation = newRotation;
        }
    }

    public void createCargo(string unit)
    {
        if (cargoUsed < cargoCapacity)
        {
            switch (unit)
            {
                case "Humvee":
                    cargo.Add(humvee);
                    cargoUsed++;
                    break;
                case "Infantry":
                    cargo.Add(infantry);
                    cargoUsed++;
                    break;
                case "Turret":
                    cargo.Add(turret);
                    cargoUsed++;
                    break;
                default:
                    break;
            }
        }
        else
        {
            //string display = "not enough room";
        }
    }

    void dropCargo(List<GameObject> cargoUnits)
    {
        if (cargoUnits.Count > 0)
        {
            var unit = cargoUnits.Last();

            var x = transform.position.x;
            var y = 27.0f;
            var z = transform.position.z;

            var instantiation = new Vector3(x, y, z);
            var movement = new Vector3(0, 90, 0);
            var targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            Instantiate(unit, movement, transform.rotation);

            if (unit == turret)
            {
                Instantiate(unit, instantiation, targetRotation);
                cargoUsed--;
            }
            else
            {
                Instantiate(unit, instantiation, transform.rotation);
                cargoUsed--;
            }

            cargoUnits.Remove(unit);

        }
    }

    void OnTriggerStay(Collider other)
    {
        var cargo = other.gameObject;

        if (Input.GetButtonDown("CargoMove"))
        {
            if (UtypeString.ContainsValue(cargo.tag))
            {
                createCargo(cargo.tag);
                Destroy(cargo);
            }
        }

    }
}

