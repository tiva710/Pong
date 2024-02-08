using UnityEngine;

public class DemoPaddle : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody rb;
    public string inputAxis;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis(inputAxis);// * speed;
       
		float newZ = transform.position.z + moveVertical * speed * Time.deltaTime;

    	// ensure paddle doesn't go beyond the top & bottom walls
    	newZ = Mathf.Clamp(newZ, -20.4f, 20.4f);

    	// Apply new position
    	transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
	    rb = collision.rigidbody;
	    
	    BoxCollider bc = GetComponent<BoxCollider>();
	    Bounds bounds = bc.bounds;
	    float max = bounds.max.x;
	    float min = bounds.min.x;
	    float whereBallHits = collision.transform.position.x;
  
	    float angleBallHits = 1 - ((whereBallHits - min) / (max - min));
	    float newTrajectory = (angleBallHits - 0.5f) * 2 * 60;
  
	    Quaternion rotate = Quaternion.Euler(0f, 0f, newTrajectory);
	    Vector3 newDirection = rotate * Vector3.up; 
	    
		// rb.AddForce(newDirection * 300, ForceMode.Force);

		AudioSource boom = GetComponent<AudioSource>();
		boom.Play();
    }
}
