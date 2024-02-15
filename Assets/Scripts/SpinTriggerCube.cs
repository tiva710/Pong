using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTriggerCube : MonoBehaviour
{
    // Start is called before the first frame update
    private CameraSpinner cameraSpinner; 
    void Start()
    {
        cameraSpinner = Camera.main.GetComponent<CameraSpinner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            cameraSpinner.TriggerSpin();
            Destroy(gameObject);
        }
    }
}
