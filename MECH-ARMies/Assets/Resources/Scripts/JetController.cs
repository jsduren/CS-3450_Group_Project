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
    //private float transformRate = .25f;
    private float shootSoundVolume = 1;
    private int startHeight = 35;

    private int cargoUsed = 0;
    private GameObject mech;
    private GameObject humvee;
    private GameObject infantry;
    private GameObject turret;

    private AudioClip shotsFired;
    private GameObject shot;
    private Transform shootingOrigin1;
    private Transform shootingOrigin2;
    private List<GameObject> cargo = new List<GameObject>();
    private float nextFire;
    AudioSource playerAudio;

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
        shootingOrigin1 = gameObject.transform;
        shootingOrigin2 = gameObject.transform;

        playerAudio = GetComponent<AudioSource>();

        var newPosition = new Vector3(transform.position.x, startHeight, transform.position.z);
        gameObject.transform.position = newPosition;

        currentTeam = "Team1";
    }

    void Update()
    {
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

    void SwitchPlayer()
    {
        Vector3 location = new Vector3(transform.position.x, 25.0f, transform.position.z);
        Instantiate(mech, location, transform.rotation);
        DestroyImmediate(gameObject);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var movement = new Vector3(x, 0.0f, z);
        if (movement.magnitude <= 0)
        {
            if (rigidbody.velocity.magnitude > 0.1f)
            {
                rigidbody.velocity *= 0.1f;
            }
            else rigidbody.velocity *= 0;
            return;
        }

        rigidbody.velocity = movement * speed;
        var targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        var newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 15f * Time.deltaTime);
        rigidbody.rotation = newRotation;
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
            GameObject unit = cargoUnits.Last();

            float x = transform.position.x;
            float y = 27.0f;
            float z = transform.position.z;

            Vector3 instantiation = new Vector3(x, y, z);
            Vector3 movement = new Vector3(0, 90, 0);
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

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
        GameObject cargo = other.gameObject;

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

