using UnityEngine;
using System.Collections;

public class Manager : Singleton<Manager>
{
	public GameObject playerPrefab;
	public GameObject title;

	private GameObject player;

	public void GameStart ()
	{
		title.SetActive (false);
		player = (GameObject)Instantiate (playerPrefab); 
	}

	public void GameOver ()
	{
		title.SetActive (true);
		Destroy (player);
	}

	public bool IsPlaying ()
	{
		return title.activeSelf == false;
	}
}
