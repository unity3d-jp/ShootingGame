using UnityEngine;

public class Title : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.X)) {
			Manager.Instance.GameStart ();
		}
	}
}