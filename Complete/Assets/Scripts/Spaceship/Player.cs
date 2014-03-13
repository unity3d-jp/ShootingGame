using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Spaceship spaceship;
	private Vector2[] startingPosition = new Vector2[] {
				new Vector2 (0, -3),
				new Vector2 (0, -2)
			};

	void Awake ()
	{
		spaceship = GetComponent<Spaceship> ();
	}

	IEnumerator Start ()
	{
		while (true) {
			spaceship.Shot (transform);
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		spaceship.Move (new Vector2 (x, y).normalized);

		Clamp ();
	}

	void Clamp ()
	{
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, -4, 4);
		pos.y = Mathf.Clamp (pos.y, -3, 3);
		transform.position = pos;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		spaceship.Explode ();
		Manager.Instance.GameOver ();
	}

	IEnumerator DoInvincible ()
	{
		float time = 0f;
		while (time < 0.5f) {
			time += Time.deltaTime;
			transform.position = Vector2.Lerp (startingPosition [0], startingPosition [1], time * 2);
			yield return new WaitForEndOfFrame ();
		}
	}
}