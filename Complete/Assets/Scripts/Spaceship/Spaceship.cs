using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
	public int hp;
	public float speed;
	public bool canShot;
	public float shotDelay;
	public GameObject bullet;
	public GameObject explosion;

	public void Explode ()
	{
		GameObject go = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
		go.transform.localScale = transform.localScale;
		Destroy (gameObject);
	}

	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}

	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}
}