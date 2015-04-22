using UnityEngine;
using System.Collections;

public class RemoveShots : MonoBehaviour 

{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}

