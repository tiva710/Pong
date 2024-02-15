using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
            
            Destroy(gameObject);
        }
    }
}
