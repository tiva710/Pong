using UnityEngine;

public class DemoBall : MonoBehaviour
{
	public float initialSpeed = 20f; 
	public float speedIncrement = 1.5f;
	private Rigidbody rb;
	public Vector3 startingPosition;

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(initialSpeed, 0f, 0f);
	    startingPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
			gameObject.transform.position.z);


    }


	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Paddle1") || collision.gameObject.CompareTag("Paddle2"))
		{
			float currentSpeed = rb.velocity.magnitude;
			
			Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
			rb.AddForce(newDirection * 100, ForceMode.Force);
			//Incrementing speed 
			currentSpeed *= (1 + speedIncrement);
			
			rb.velocity = newDirection * currentSpeed;

			//Change Balls color 
			Color randomColor = Random.ColorHSV();
			GetComponent<Renderer>().material.color = randomColor;
			Debug.Log(rb.velocity);
		}
		
	}
	void OnTriggerEnter(Collider collision)
	{

		if (collision.CompareTag("Goal1"))
		{
			FindObjectOfType<GameManager>().ScoreGoal("Left");
			ResetBall();
		}else if (collision.CompareTag("Goal2"))
		{
			FindObjectOfType<GameManager>().ScoreGoal("Right");
			ResetBall();
		}
	}

	void ResetBall()
	{
		transform.position = startingPosition;
		rb.velocity = Vector3.zero; 
		rb.AddForce(new Vector3(initialSpeed, 0, 0), ForceMode.VelocityChange);
	} 
}
