using System;
using UnityEngine;

public class DemoPaddle : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody rb;
    public string inputAxis;
    public float speedIncrement = 1.5f;
    
    public AudioSource boom;
    public AudioSource bam;
    public AudioSource fast;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveVertical  = Input.GetAxis(inputAxis);// * speed;
       
		float newZ = transform.position.z + moveVertical * speed * Time.deltaTime;

    	// ensure paddle doesn't go beyond the top & bottom walls
    	newZ = Mathf.Clamp(newZ, -20.4f, 20.4f);

    	// Apply new position
    	transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        
    }

    private void OnCollisionEnter(Collision other)
    {
	    
	    // // Debug.Log("hit");
	    // var paddleBounds = GetComponent<BoxCollider>().bounds;
	    // float maxPaddleHeight = paddleBounds.max.z;
	    // float minPaddleHeight = paddleBounds.min.z;
     //
	    // // Get the percentage height of where it hit the paddle (0 to 1) and then remap to -1 to 1 so we have symmetry
	    // float pctHeight = (other.transform.position.z - minPaddleHeight) / (maxPaddleHeight - minPaddleHeight);
	    // float bounceDirection = (pctHeight - 0.5f) / 0.5f;
	    // // Debug.Log($"pct {pctHeight} + bounceDir {bounceDirection}");
     //
	    // // flip the velocity and rotation direction
	    // Vector3 currentVelocity = other.relativeVelocity;
	    // float newSign = currentVelocity.x > 0 ? -1f: 1f;
	    // float newRotSign = newSign < 0f ? 1f: -1f;
     //
	    // // Change the velocity between -60 to 60 degrees based on where it hit the paddle
	    // float newSpeed = currentVelocity.magnitude * speedIncrement;
	    // Vector3 newVelocity = new Vector3(newSign, 0f, 0f) * newSpeed;
	    // newVelocity = Quaternion.Euler(0f, newRotSign * 60f * bounceDirection, 0f) * newVelocity;
	    // other.rigidbody.velocity = newVelocity;
	    
	 //    rb = collision.rigidbody;
	 //    
	 //    BoxCollider bc = GetComponent<BoxCollider>();
	 //    Bounds bounds = bc.bounds;
	 //    float max = bounds.max.x;
	 //    float min = bounds.min.x;
	 //    float whereBallHits = collision.transform.position.x;
  //    
	 //    float angleBallHits = 1 - ((whereBallHits - min) / (max - min));
	 //    float newTrajectory = (angleBallHits - 0.5f) * 2 * 60;
  //    
	 //    Quaternion rotate = Quaternion.Euler(0f, 0f, newTrajectory);
	 //    Vector3 newDirection = rotate * Vector3.up; 
	 //    
		// rb.AddForce(newDirection * 300, ForceMode.Force);
  
		// AudioSource boom = GetComponent<AudioSource>();
		// boom.Play();
		
		rb = other.rigidbody;
	    
		BoxCollider bc = GetComponent<BoxCollider>();
		Bounds bounds = bc.bounds;
		float max = bounds.max.x;
		float min = bounds.min.x;
		float whereBallHits = other.transform.position.x;
  
		float angleBallHits = 1 - ((whereBallHits - min) / (max - min));
		Debug.Log(angleBallHits);
		float newTrajectory = (angleBallHits - 0.5f) * 2 * 60;
  
		Quaternion rotate = Quaternion.Euler(0f, 0f, newTrajectory);
		Vector3 newDirection = rotate * Vector3.up; 
	    
		// rb.AddForce(newDirection * 300, ForceMode.Force);

		// AudioSource boom = GetComponent<AudioSource>();
		// boom.Play();
    }

    public void PlayHitSound(float speed)
    {
	    // AudioSource boom;
	    // AudioSource bam;
	    // AudioSource fast;

	    if (speed < 65f)
	    {
		    boom.Play();
	    }else if (speed < 130f)
	    {
		    bam.Play();
	    }else
	    {
		   fast.Play(); 
	    }

    }
}
