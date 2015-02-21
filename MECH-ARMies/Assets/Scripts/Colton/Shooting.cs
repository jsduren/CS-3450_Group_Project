using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private float speed = 250.0f;
    
    void Start ()
    {
        rigidbody.velocity = (transform.forward) * speed;
    }
}
