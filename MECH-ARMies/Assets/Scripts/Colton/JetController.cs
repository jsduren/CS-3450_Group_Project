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
    private int cargoUsed = 0;
    public float speed;

    public GameObject mech;
    public GameObject humvee;
    public GameObject infantry;
    public GameObject turret;

    public float setVolume;
	public AudioClip shotsFired;
    public GameObject shot;
    public Transform shootingOrigin1;
    public Transform shootingOrigin2;

    private List<GameObject> cargo = new List<GameObject>(); 
   
    private float fireRate = 0.25f;
    private float tranformRate = .25f;

    private float nextFire;
    private float nextTransform;

	AudioSource playerAudio;

    private static Dictionary<UType, string> UtypeString = new Dictionary<UType, string>
    {
        {UType.Infantry, "Infantry"},
        {UType.Jeep, "Humvee"},
        {UType.Turret, "Turret"},
    };

	void Start()
	{
		playerAudio = GetComponent<AudioSource> ();
	}

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
			playerAudio.clip = shotsFired;
			playerAudio.volume = setVolume;
			playerAudio.Play();
            Instantiate(shot, shootingOrigin1.position, shootingOrigin1.rotation);
            Instantiate(shot, shootingOrigin2.position, shootingOrigin2.rotation);

        }

        if (Input.GetButtonDown("Change") && Time.time > nextTransform)
        {

            SwitchPlayer();
        }

        if (Input.GetButtonDown("CargoDrop"))
        {
            if(cargoUsed == 1)
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
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Move(moveX, moveZ);

    }

    void Move(float x, float z)
    {
      
        
        Vector3 movement = new Vector3(x, 0.0f, z);
        rigidbody.velocity = movement * speed;
        //Turning(movement, x, z);
        //rigidbody.rotation = Quaternion.Euler(z * tilt, 0.0f, x * -tilt);
        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 15f * Time.deltaTime);
        rigidbody.rotation = newRotation;
        //rigidbody.MoveRotation(newRotation);
        
    }



    //void Turning(Vector3 m,  float x, float z)
    //{
        
    //    Quaternion targetRotation = Quaternion.LookRotation(m, Vector3.up);
    //    Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 15f * Time.deltaTime);

    //    rigidbody.MoveRotation(newRotation);
    //}

    public void createCargo(string unit)
    {
        if(cargoUsed < cargoCapacity)
        {
            switch (unit)
            {
                case "Humvee":
                    cargo.Add(humvee);
                    cargoUsed++;
                    break;
                case "Infantry":
                    cargo.Add(infantry);
                    cargoUsed ++;
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
            string display = "not enough room";
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
            Vector3 movement = new Vector3(0,90,0);
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            Instantiate(unit, movement, transform.rotation);

            if (unit == turret)
            {
                Instantiate(unit, movement, targetRotation);
                cargoUsed--;
            }
            else
            {
                Instantiate(unit, instantiation, transform.rotation);
                cargoUsed --;
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

