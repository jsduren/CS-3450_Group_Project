using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public GameObject Ship;
    public GameObject Mech;


	public float setVolume;
	public AudioClip shotsFired;
    public GameObject shot;
    public Transform shootingOrigin1;
    public Transform shootingOrigin2;
    private float fireRate = 0.25f;
    private float tranformRate = .25f;

    private string activeobject = "ship";

    private bool transformed = false;

    private float nextFire;
    private float nextTransform;

	AudioSource playerAudio;

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

        if (Input.GetButton("Change")  && Time.time > nextTransform && transformed == false)
        {
            nextTransform = Time.time + tranformRate;

            if (activeobject == "ship")
            {
                if (!transformed)
                {
                    transformed = true;
                    Vector3 location = new Vector3(transform.position.x, 25.0f, transform.position.z);
                    Instantiate(Mech, location, Ship.transform.rotation);
                    DestroyImmediate(Ship);
                    activeobject = "mech";
                }

            }
            else
            {
                if (!transformed)
                {
                    transformed = true;
                    Vector3 location = new Vector3(transform.position.x, 34.5f, transform.position.z);
                    Instantiate(Ship, location, Mech.transform.rotation);
                    DestroyImmediate(Mech);
                    activeobject = "ship";
                }

            }
        }

        transformed = false;
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

    //void SwitchPlayer()
    //{
    //    if (activeobject == "ship")
    //    {
    //        Vector3 location = new Vector3(transform.position.x, 25.0f, transform.position.z);
    //        Instantiate(Mech, location, Ship.transform.rotation);
    //        DestroyImmediate(Ship);
    //        activeobject = "mech";
    //        transformed = false;
    //    }
    //    else
    //    {
    //        Vector3 location = new Vector3(transform.position.x, 34.5f, transform.position.z);
    //        Instantiate(Ship, location, Mech.transform.rotation);
    //        DestroyImmediate(Mech);
    //        activeobject = "ship";
    //        transformed = false;
    //    }
    //}

    //void Turning(Vector3 m,  float x, float z)
    //{
        
    //    Quaternion targetRotation = Quaternion.LookRotation(m, Vector3.up);
    //    Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, 15f * Time.deltaTime);

    //    rigidbody.MoveRotation(newRotation);
    //}

 

}
