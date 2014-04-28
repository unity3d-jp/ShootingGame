using UnityEngine;

public class Explosion : MonoBehaviour
{
	void OnAnimationFinish ()
	{
		Destroy (gameObject);
	}
}