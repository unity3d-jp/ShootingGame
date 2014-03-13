using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	private Animator animator;
	private Spaceship spaceship;

	void Awake ()
	{
		spaceship = GetComponent<Spaceship> ();
		animator = GetComponent<Animator> ();
	}

	void Start ()
	{
		spaceship.Move (transform.up * -1);

		if (spaceship.canShot) {
			StartCoroutine (Shot ());
		}
	}

	IEnumerator Shot ()
	{
		Transform[] shotPositions = GetComponentsInChildren<Transform> ();
		
		while (true) {
			
			foreach (Transform shotPosition in shotPositions) {
				
				if (transform == shotPosition)
					continue;
				
				spaceship.Shot (shotPosition);
			}
			
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		int layer = LayerMask.NameToLayer ("PlayerBullet");
		if (c.gameObject.layer == layer) {
			Destroy (c.gameObject);
			OnDamage ();
		}
	}

	void OnDamage ()
	{
		animator.SetTrigger ("Damage");

		if (--spaceship.hp <= 0) {
			spaceship.Explode ();
		}
				
	}
}
