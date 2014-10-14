# Completeカンペ

## Unityの起動

ShootingGameフォルダの中の**Completeプロジェクト**を開こう。


## Unityエディターの設定

手順通りに説明していきます。

手順||　
:---:|:---|:---
1|レイアウト| 2 by 3 
2|Projectブラウザ| One Column Layout
3|ビルドターゲット| WebPlayer
4|スクリーンサイズ | 600 x 450
5|2Dモード | オン

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-03-13%2013.41.25.png)

<div style="page-break-before: always;"></div>

## プロジェクト

1. ここには「ファイル」としてPCに保存されているものが表示されている
2. 実際に右クリックして「ファインダー / エクスプローラー」を見せる
	* 普段自分が扱っているようなファイルだということを意識させる
	* これらのファイルをUnity上で扱いやすくしたものをアセットという
3. Unityに戻って「Textures」フォルダの**▶**をクリックして展開する
	* 展開したままで次に進む


## インスペクター

1. Projectプラウザのアセットをマウスカーソルでポチポチする
	* 右の部分がアセットをクリックするごとに切り替わっていくことを確認
	* ここはUnity上で使う全ての「もの」の情報を閲覧し、**設定**を行える場所
	* 例えばTexturesフォルダの中のアセットをクリックするとテクスチャの設定情報を見ることが出来る
	
	
		![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-03-07%2014.11.05.png)
	
<div style="page-break-before: always;"></div>

## <span style='color:red'>ここで説明のためにPrefabをインスタンス化</span>

1. 「Prefabs」フォルダの**▶**をクリックして展開する
2. **Backgrounds**を左上のウィンドウにドラッグ＆ドロップ
	* まだシーンウィンドウの説明をしていないので「左上のウィンドウ」と呼ぶ
3. 左上と左下に背景のテクスチャが表示されたら終了
	* ゲームビューには位置の関係で出ないかも

## 「シーン」と「ヒエラルキー」と「ゲーム」

1. 少なくとも今左上に背景のテクスチャが表示されているはず、ここがシーンビューと呼ばれるもの
2. **シーンビュー**は、ゲームの世界を構築するために私達が操作できる領域です。
3. そして左下の**ゲームビュー**と呼ばれる部分は、実際にゲームとしてプレイした時に表示される画面のことを指します。

### ゲームビューに背景を映す

1. シーンビューに映っている背景を、ゲームビュー全体に映るように調整してみましょう。
	* UnityのシーンビューとProjectプラウザの間にある**ヒエラルキービュー**を使って調整を行います
2. 青色の文字「Backgrounds」をクリックしてください。
3. そうするとインスペクターに情報が表示されるので**Transform**の情報を以下のように変更します。
	* 同じ環境であればPositionをいじるだけです。
	* 稀にScaleとかをいじっている人がいるので確認して下さい。

	Transform | value
	:--- | :---
	Position| **( 0, 0, 0 )**
	Rotation| **( 0, 0, 0 )**
	Scale | **( 1, 1, 1 )**

4. ゲームビューの中心に背景が映るようになりました。ですが画面いっぱいに背景が映っていません。
	* 稀にカメラの位置を変更していて正しく表示されない人がいます。

5. ヒエラルキーのMain Cameraをクリックしてください。これからカメラの設定を変更します。
	* インスペクターに表示されているCameraコンポーネントの**Projection**を「Perspective」から「Orthographic」へ変更します。
	* そして「Size」を３に変更してください。
	
	![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-03-07%2015.49.23.png)
	
	* カメラいっぱいに背景が表示されたはずです。
	* もし表示されない場合は「Prefabs」の中にMainCameraがあるので使用してください。

### ゲームの再生

1. 上にある再生ボタンをクリックしてゲームを再生します。
2. 背景が動いていますか？
	* 動いていない場合、何かがおかしいです。コンソールを確認して下さい。もしかしたらUnityバージョン違いやスクリプトのコンパイルエラーがあるかも？
3. 背景は３つのテクスチャでてきており、それぞれ動くスピードが違います。このスピードを変更してみましょう。
	* 「Backgrounds」**▶**をクリックして展開します。
	* 「Back」を選択してインスペクターを見てください。
	* **Background (Script)**のSpeedの文字にマウスカーソルを合わせ右にドラッグします。
	* すると背景の動きが早くなりました。
4. ゲームの再生を止めて、再度ゲームを再生します。
	* 背景の動くスピードが元に戻りました。（戻ってない人は停止中にパラメータを弄った人）
	* ゲーム再生中に変更したゲームオブジェクトのパラメータは元に戻ります。
		* アセットのパラメーター変更は戻りません。よって、背景の動きはマテリアルのオフセットを変更しているので戻りません。
	* もし、ゲーム再生中にパラメーター調整をした時はゲームを停止する前にコンポーネントの上で右クリックして「Copy Component」でコピーしましょう。
	
	
### Prefabを置いてゲームを完成させる

1. ここから一気にゲームを完成させます。用意しているPrefabをシーンに配置していきましょう。配置する時はPrefabをシーンビューへではなくヒエラルキービューへとドラッグ＆ドロップします。そうすることでPrefabに設定されているTransform情報を使用して配置されます。

	配置するPrefab |説明 | 位置（Position）
	:--- |:---
	Backgrounds|背景|  **( 0, 0, 0 )**
	BGM|BGM|  **( 0, 0, 0 )**
	DestroyArea|敵と弾が削除される範囲|  **( 0, 0, 0 )**
	Emitter|敵を放出する| <span style='color:red'> **( 0, 3.5, 0 )** </span>
	Manager|ゲームスタートの管理|  **( 0, 0, 0 )**
	Title|タイトル|  **( 0, 0, 0 )**
	Score GUI|スコア|  **( 0, 0, 0 )**

2. ヒエラルキービューから**Manager**ゲームオブジェクトを選択しインスペクターを表示します。そして**Title**にTitleゲームオブジェクトを格納しましょう。

	![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-03-07%2017.17.13.png)
	
3. ゲームの完成！
	* さて、これでゲームが完成しました。ゲームを再生してみましょう。
	* Xを押すとゲームが開始され、左・真ん中・右に敵が現れます。
	* 3体とも倒すと再度敵が現れます。
	
### 新しくWaveのPrefabを作る	

1. 少しだけゲームを面白くしたいと思います。自分で新たなWaveを作成しましょう。
2. Waveのプレハブを複製します。
	* プロジェクトビューのWaveのプレハブを選択し上部メニューの「Edit」から「Duplicate」を選択します。
	* または、cmd(⌘) + D
	* 「Wave 1」というPrefabが作成されました

### Waveの追加

1. シーンビューの適当な位置にドラッグ＆ドロップしましょう。この時に背景と重なってはダメです。この後の操作がしづらいため。

	![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-03-07%2017.49.22.png)
	
2. シーンビューに表示されたら敵（Enemy）を1機選択します。
3. 敵をDuplicateしてどんどん配置していきましょう。
4. Enemyを選択するとインスペクターに情報が表示されます。そこにはHPや移動スピードを変更してみましょう。
	* ゲームを再生しながら確認すると調整がやりやすいです。パラメーターが戻ってしまうのに注意！
5. 今作ったWaveをPrefabに反映しましょう。「Wave 1」を選択してインスペクター上部の「Apply」を押してください。
6. Applyを押したらシーン上にあるゲームオブジェクトを削除します。
7. シーン上のEmmiterを選択し、今作成したWaveを追加しましょう。
	* **Waves**の**▶**をクリックして展開します。
	* **Size**を1から2へ変更します。
	* **Element 1**の部分に先程の**Wave 1**のプレハブを格納しましょう。
	
		![](https://dl.dropboxusercontent.com/u/153254465/screenshot/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202014-03-07%2018.17.40.png)
		
<div style="page-break-before: always;"></div>

### 自分だけのゲーム完成！

1. オリジナルのWaveが追加され、自分だけのシューティングゲームが出来ました。
2. 「File -> Save Scene」またはcmd(⌘) + S でシーンをアセットとして保存しましょう！

<div style='text-align:center; font-size:50px'>休憩！</div>


### [応用編] Waveを作成

#### 特定のタイミングで無敵になるエネミー

1. 複製してアニメーターコントローラーのEnemy(Invincible)を作成
1. Enemy AnimatorControllerに**「Invincible Layer」**を作成。
2. *Animations/Enemy*に**Invincible**アニメーションを作成
3. 下記のようにInvincible LayerのWeightを1、**Dummyステート（デフォルト）**相互にTransitionを作成
	![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2014.01.34.png)
4. Dummy -> Invincibleは**Exit Timeを3**に
	![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2014.08.05.png)
5. Invincible -> Dummyは**Exit Timeを2**に
	![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2014.08.10.png)

6. 特定のエネミーだけ無敵にしたい場合
	
* スクリプトを書く

```cs
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	// 略 //
	
	// 無敵になる間隔
	public float invincibleTimeInterval;

	void DoInvincible ()
	{
		spaceship.GetAnimator ().SetTrigger ("Invincible");
	}

	IEnumerator Start ()
	{
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
	
		// 無敵にするメソッドを実行する
		// +2は無敵になっている時間。正確にはAnimator.GetNextAnimatorStateInfoでInvincibleアニメーション時間を取得する
		if (invincibleTimeInterval != 0)
			InvokeRepeating ("DoInvincible", invincibleTimeInterval, invincibleTimeInterval + 2);
```
	
* Invincibleトリガーを作成する。Dummy -> InvincibleのTransitionで、ConditionsをInvincibleトリガーのみにする
	* ![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2014.41.05.png)
* 適当なEnemyの「Invincible Time Interval」を0より大きく設定する
		![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2015.13.38.png)

#### 一定時間特定の場所に居続けるエネミー

* Enemyアニメーションコントローラーで作業してもいいがフラグ管理が面倒なので、複製して「Enemy (Standby)」を作成する。
* Standby Layerを作成
	![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2017.44.08.png)

* Standbyアニメーションを作成
	* 下に移動 -> 待機 -> 上に移動
		![](https://dl.dropboxusercontent.com/u/153254465/screenshot2/ss%202014-10-14%2017.46.33.png)
		
### [応用] モバイル対応

#### 背景を画面に合わせる
* *Background/Front*、*Background/Middle*、*Background/Back*のScale.xを9に、DestroyAreaのBoxCollider.Size.xを9に変更します。（iOSの画面に合わせるため）

#### スタート方法変更

* 画面をタップしたらゲームスタートにする
* **Manager.cs**を変更

```cs
void Update ()
{
	// ゲーム中ではなく、タップして離した状態でゲームを開始する。
	if (IsPlaying () == false && Input.GetTouch(0).phase == TouchPhase.Ended) {
		GameStart ();
	}
}
```

* Unity Remoteで確認



#### インプット対応
* AssetStoreのSmapleAssetsから「Cross Platform Input」をインポート
* Prefabから「Mobile Single Stick Control Rig」を選択し、Jumpボタンを削除
* Player.csを開き、Input.GetAxisRawを**CrossPlatformInput.GetAxisRaw**に変更
