using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{
	public GameObject[] waves;
	private int currentWave;

	IEnumerator Start ()
	{

		if (waves.Length == 0) {
			yield break;
		}

		while (true) {

			while (!Manager.Instance.IsPlaying()) {
				yield return new WaitForEndOfFrame ();
			}

			GameObject g = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);

			g.transform.parent = transform;

			while (g.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			Destroy (g);

			if (waves.Length <= ++currentWave) {
				currentWave = 0;
			}

		}
	}
}