using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
	public GameObject ballObj;          // 　生成したいPrefab
	private Vector3 clickPos;               // 　マウスのカーソル位置座標
	public float rapid;                                 //　ボールを出せるようになるまでの時間　float型の変数を用意します
	private float oriRapid;                         //　元のrapidに入れられていた値を格納しておく変数　 float型の変数を用意します

	public bool gameOn;                         //   ゲームが進行中か終わってるか、の2択のフラグ
	public float speed;                     //    飛ばす力の大きさの値です 
	public Transform canonPos;  //　 弾が出る場所の座標

	private void Start()
	{
		oriRapid = rapid;             //editorでrapidに入れた値をoriRapidに格納します
		gameOn = true;                //gameOnをtrueにします
	}
	void Update()
	{
		if (gameOn == true)
		{
			rapid -= 0.05f;                 //変数rapidから0.05を引きます
			if (rapid <= 0 == true)     //もしrapidの値が０以下になったら、マウスボタンを押した時に弾が出るようになります
			{
				if (Input.GetMouseButtonDown(0))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
				{
					clickPos = Input.mousePosition;          // Vector3型変数ｃlickPosに、マウスの現在位置座標を取得する
					clickPos.z = 10.0f;                                   //Z軸の値に適当な値を入れます
														  
					Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);// ScreenToWorldPoint(位置(Vector3))：　スクリーン座標をワールド座標に変換する
					
					GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
					//Instantiate オブジェクトを作る関数（ オブジェクト名(GameObject), 作る位置(Vector3), オブジェクトの角度(Quaternion)）
					
					Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
					//弾の飛ぶ方向ベクトルbulletDirに、弾の出るcanonPosの位置とマウスのクリックした位置を引き算した値に、
					//(1,1,0)をかけて（Scale）、Z軸の値を0にします、それをnormalizedで「単位ベクトル」に直します

					ball.GetComponent<Rigidbody2D>().AddForce(bulletDir * speed); //AddForceでrigidbodyを付けたballを飛ばします
					rapid = oriRapid;               //　 rapidに元の値を入れて戻します　
				}
			}
		}
		else return;
	}
}