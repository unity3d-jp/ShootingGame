# スクリプト

このファイルはハンズオンでコピペするために用意しています。

いきなり全部コピペしても動かないぞ！


## コピペする場所

Hoge.csを例とすると:

```
using UnityEngine;
using System.Collections;

public class Hoge : MonoBehaviour
{
	// この中にコピペしていきます！
}
```


目次

* [Spaceship.cs](#spaceship)
* [Player.cs](#player)
* [Enemy.cs](#enemy)
* [Explosion.cs](#explosion)
* [Bullet.cs](#bullet)
* [Rotate.cs](#rotate)
* [Emitter.cs](#emitter)
* [DestroyArea.cs](#destroyarea)
* [Title.cs](#title)
* [Manager.cs](#manager)
* [Background.cs](#background)


## [Spaceship.cs](id:spaceship)

### ヒットポイント（HP）を持たせるコード

```
public int hp;
```

### 移動するコード

```
public float speed;

public void Move (Vector2 direction)
{
	rigidbody2D.velocity = direction * speed;	// 速度と向きを設定する
}
```


### 弾を撃つコード

```
public GameObject bullet;
public float shotDelay;
public bool canShot;

public void Shot (Transform origin)
{
	Instantiate (bullet, origin.position, origin.rotation);	// プレイヤーの位置に弾を作成する
}
```


### 爆発するコード

```
public GameObject explosion;

public void Explode ()
{
	GameObject go = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
	go.transform.localScale = transform.localScale;	// 爆発の大きさを機体と同じ大きさにする
	Destroy (gameObject);
}
```


## [Player.cs](id:player)

### Spaceshipコンポーネントを取得するコード

```
Spaceship spaceship;

void Awake ()
{
	spaceship = GetComponent<Spaceship> ();
}
```

### 弾を撃つコード

```
IEnumerator Start ()
{
	while (true) {
		spaceship.Shot (transform);
		yield return new WaitForSeconds (spaceship.shotDelay);	// shotDelay秒待つ
	}
}
```

### 移動と移動範囲を制限するコード

```
void Update ()
{
	float x = Input.GetAxisRaw ("Horizontal");
	float y = Input.GetAxisRaw ("Vertical");

	spaceship.Move (new Vector2 (x, y).normalized);

	Clamp ();	// 移動制限
}

void Clamp ()
{
	Vector3 pos = transform.position;
	pos.x = Mathf.Clamp (pos.x, -4, 4);	//X軸は-4~4まで移動できる
	pos.y = Mathf.Clamp (pos.y, -3, 3);	//Y軸は-3~3まで移動できる
	transform.position = pos;
}
```

### 爆発するコード

```
void OnTriggerEnter2D (Collider2D c)
{
	spaceship.Explode ();
}
```


### 0.5秒かけてスタート位置からゴール位置へ移動するコード

```
Vector2[] startingPosition = new [] {
			new Vector2 (0, -3),	// スタート位置
			new Vector2 (0, -2)		// ゴール位置
		};

IEnumerator DoInvincible ()
{
	float time = 0f;
	while (time < 0.5f) {	// 0.5秒の間実行される
		time += Time.deltaTime;
		transform.position = Vector2.Lerp (startingPosition [0], startingPosition [1], time * 2);	// スタート位置からゴール位置へ移動する
		yield return new WaitForEndOfFrame ();
	}
}
```


### <span style='color:red'>追加コード！</span> ゲームオーバーのコード

OnTriggerEnter2Dメソッドに`Manager.Instance.GameOver ();`を追加しましょう

```
void OnTriggerEnter2D (Collider2D c)
{
	spaceship.Explode ();
	Manager.Instance.GameOver ();	// <- これをここの位置にコピペ
}
```

## [Enemy.cs](id:enemy)

### AnimatorとSpaceshipコンポーネントを取得するコード

```
private Animator animator;
private Spaceship spaceship;

void Awake ()
{
	spaceship = GetComponent<Spaceship> ();
	animator = GetComponent<Animator> ();
}
```


### 移動するコード

```
void Start ()
{
	spaceship.Move (transform.up * -1);	// 下方向に移動する
}
```

### <span style='color:red'>追加コード！</span>　弾を撃つコード

```
void Start ()
{
	spaceship.Move (transform.up * -1);

	if (spaceship.canShot) {		// <- これをここの位置にコピペ
		StartCoroutine (Shot ());	// <- これをここの位置にコピペ
	}								// <- これをここの位置にコピペ
}

IEnumerator Shot ()
{
	Transform[] shotPositions = GetComponentsInChildren<Transform> ();
		
	while (true) {
			
		foreach (Transform shotPosition in shotPositions) {
				
			if (transform == shotPosition)	// 取得したTransformに自分自身も含まれてしまっているのでここでチェックして省く
				continue;
				
			spaceship.Shot (shotPosition);
		}
			
		yield return new WaitForSeconds (spaceship.shotDelay);
	}
}
```

### ダメージ → 爆発するコード

```
void OnTriggerEnter2D (Collider2D c)
{
	int layer = LayerMask.NameToLayer ("PlayerBullet");	
	if (c.gameObject.layer == layer) {	// レイヤー名が「PlayerBullet」のゲームオブジェクトのみダメージを受ける
		Destroy (c.gameObject);			// 弾を削除
		OnDamage ();
	}
}

void OnDamage ()
{
	animator.SetTrigger ("Damage");		// AnimatorへDamageトリガーをセット

	if (--spaceship.hp <= 0) {			// HPが0になったら爆発
		spaceship.Explode ();
	}			
}
```

## [Explosion.cs](id:explosion)

### 爆発後、削除するコード

```
public void Destroy ()	// 爆発アニメーションが終わった後に呼び出されるメソッド（AnimationEvent）
{
	Destroy (gameObject);
}
```

## [Bullet.cs](id:bullet)

### 移動するコード

```
public int speed = 5;
public bool isPositive;

void Start ()
{
	Vector2 direction = transform.up.normalized;

	if (isPositive == false) {
		direction *= -1;		// 逆方向に移動させる
	}
	
	rigidbody2D.velocity = direction * speed;
}
```

### <span style='color:red'>追加コード！</span> 5秒後に破棄するコード

```
void Start ()
{
	Destroy (gameObject, 5); // <- これをここの位置にコピペ

	Vector2 direction = transform.up.normalized;
	
	if (isPositive == false) {
		direction *= -1;
	}
		
	rigidbody2D.velocity = direction * speed;
}
```

## [Rotate.cs](id:rotate)


### 回転するコード

```
void Update ()
{
	transform.Rotate (Vector3.forward);
}
```

## [Emitter.cs](id:emitter)

### 敵を出すコード

```
public GameObject[] waves;
private int currentWave;

IEnumerator Start ()
{

	if (waves.Length == 0) {
		yield break;
	}

	while (true) {

		GameObject g = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);

		g.transform.parent = transform;				// WaveをEmitterの子要素にする

		while (g.transform.childCount != 0) {		// Waveの敵がいなくなるまで待機
			yield return new WaitForEndOfFrame ();
		}

		Destroy (g);

		if (waves.Length <= ++currentWave) {	// 全てのWaveが終わったら最初に戻る（ループ）
			currentWave = 0;
		}

	}
}
```

### <span style='color:red'>追加コード！</span> タイトルを表示している間は敵を出さないコード

```
IEnumerator Start ()
{

	if (waves.Length == 0) {
		yield break;
	}

	while (true) {

		while (!Manager.Instance.IsPlaying()) {		// <- これをここの位置にコピペ
			yield return new WaitForEndOfFrame ();	// <- これをここの位置にコピペ
		}											// <- これをここの位置にコピペ

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
```


## [DestroyArea.cs](id:destroyarea)

### 弾や敵を削除するコード

```
void OnTriggerEnter2D (Collider2D c)
{
	Destroy (c.gameObject);
}
```

## [Title.cs](id:title)

```
void Update ()
{
	if (Input.GetKeyDown (KeyCode.X)) {	// キーボードのXが押されたらtrueを返す
		Manager.Instance.GameStart ();
	}
}
```

## [Manager.cs](id:manager)

### ゲームスタート / ゲームオーバーを管理するコード


```
public GameObject playerPrefab;
public GameObject title;

private GameObject player;

public void GameStart () 
{
	title.SetActive (false);							// タイトル非表示
	player = (GameObject)Instantiate (playerPrefab); 	// プレイヤー作成
}

public void GameOver ()
{
	title.SetActive (true);		// タイトル表示
	Destroy (player);			// プレイヤー削除
}

public bool IsPlaying ()
{
	return title.activeSelf == false;	// タイトルが出ていない間はゲームプレイ中と判断する
}
```

## [Background.cs](id:background)

### 背景を動かすコード

```
public float speed = 0.1f;

void Update ()
{
	Vector2 offset = new Vector2 (0, Mathf.Repeat (Time.time * speed, 1));	// Yの値は0~1の間をループする
	renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);			// テクスチャを少しずつずらしてゆく
}
```