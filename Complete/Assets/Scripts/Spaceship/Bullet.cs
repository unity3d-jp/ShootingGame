using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int speed = 5;
	public bool isPositive;

	void Start ()
	{
		Destroy (gameObject, 5);

		Vector2 direction = transform.up.normalized;
	
		if (isPositive == false) {
			direction *= -1;
		}
		
		rigidbody2D.velocity = direction * speed;
	}
}
