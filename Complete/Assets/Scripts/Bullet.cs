using UnityEngine;

public class Bullet : MonoBehaviour
{
	// 弾の移動スピード
	public int speed = 10;

	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime = 1;

	// 攻撃力
	public int power = 1;

	void Start ()
	{
		// ローカル座標のY軸方向に移動する
		rigidbody2D.velocity = transform.up.normalized * speed;
		
		// lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}
}