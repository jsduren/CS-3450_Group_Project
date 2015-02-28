using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JetController : MonoBehaviour
{
    public float speed;

    public GameObject mech;
    
	public float setVolume;
	public AudioClip shotsFired;
    public GameObject shot;
    public Transform shootingOrigin1;
    public Transform shootingOrigin2;
   
    private float fireRate = 0.25f;
    private float tranformRate = .25f;

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

        if (Input.GetButtonDown("Change") && Time.time > nextTransform)
        {

               SwitchPlayer();

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

 

}
