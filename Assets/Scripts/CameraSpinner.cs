using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 30f;
    public int spins = 1;
    private bool isSpinning = false; 
    private float totalRotation = 0f; 

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            transform.RotateAround(Vector3.zero, Vector3.up, rotationThisFrame);
            totalRotation += rotationThisFrame;

            if (totalRotation >= 360f * spins)
            {
                isSpinning = false;
                totalRotation = 0f;
                // transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void TriggerSpin()
    {
        if (!isSpinning)
        {
            isSpinning = true; 
        }
    }
}
