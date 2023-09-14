using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS : MonoBehaviour
{

    GameObject gameCtrl;		//　GameObject型の変数　gameCtrlを用意します、このオブジェクトにGoalManagerクラスが入れられています
    GM1 script;      //　GoalManagert型の変数　scriptを用意します　各クラス（スクリプト）はその型として変数を作ることができます
  

    private void Start()         //　Start()時に、各変数に本体を呼び込みます
    {
        gameCtrl = GameObject.Find("GC"); 	//　変数gameCtrlに　GameControllerオブジェクトを見つけてきて入れます
        script = gameCtrl.GetComponent<GM1>();   //　変数scriptに　gameCtrlに入れられたGameControllerにあるGameManagerスクリプトを入れます
    }


    void Update()
    {
        transform.Translate(-0.05f, 0, 0);  //　位置を書き換えて表示するtransform.translate()関数でｘ方向に0.05fずらします　      
        if (transform.position.x < -23.0f)  //　x軸の位置が-10fより小さくなったら・・
        {
    
            script.gameFlag();       //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します
        }

    }
}       

    
