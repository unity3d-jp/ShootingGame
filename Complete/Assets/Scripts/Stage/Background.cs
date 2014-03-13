using UnityEngine;

public class Background : MonoBehaviour
{
	public float speed = 0.1f;

	void Update ()
	{
		Vector2 offset = new Vector2 (0, Mathf.Repeat (Time.time * speed, 1));
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}