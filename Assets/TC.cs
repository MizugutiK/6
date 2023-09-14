using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TC : MonoBehaviour
{
	public Text timerText;

	public float totalTime;
	int seconds;
	GameObject gameCtrl;        //　GameObject型の変数　gameCtrlを用意します、このオブジェクトにGoalManagerクラスが入れられています
		GM script;      //　GoalManagert型の変数　scriptを用意します　各クラス（スクリプト）はその型として変数を作ることができます

		// Use this for initialization
		void Start()
		{

		gameCtrl = GameObject.Find("GC");   //　変数gameCtrlに　GameControllerオブジェクトを見つけてきて入れます
			script = gameCtrl.GetComponent<GM>();   //　変数scriptに　gameCtrlに入れられたGameControllerにあるGameManagerスクリプトを入れます
		}

		// Update is called once per frame
		void Update()
		{
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text = seconds.ToString();


		if (totalTime <= 0.0F)// 0.0秒以下になったらカウントダウンタイムを0.0で固定（止まったように見せる）
			{
				totalTime = 0.0F;
				script.GoalFlag();       //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します
			}
	
		}
	
	}

