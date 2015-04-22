using UnityEngine;
using System.Collections;

public class Respwan : MonoBehaviour
{

    public GameObject Player;
    private Vector3 location = new Vector3(105, 25, 105);

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Player.transform.position = location;
        }
    }
}
