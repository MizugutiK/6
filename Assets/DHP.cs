﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHP : MonoBehaviour
{
    public int points;         	 //　ゴールに入れるボールの数
    GameObject gameCtrl;	//　GameObject型の変数gameCtrlを用意します
    GM script;		//　GoalManager型の変数　scriptを用意します
    S scriptShooting;	//　Shootingスクリプト型の変数scriptShootingを用意します
    public ParticleSystem explosion;　//ParticleSystem型の変数explosionを用意します

    private void Start()
    {
        gameCtrl = GameObject.Find("GC");	　　　//　”GameController”という名前のobjectをsceneから探して入れます
        script = gameCtrl.GetComponent<GM>();                 //　GameControllerオブジェクトのGoalManagerスクリプトを格納します
        scriptShooting = gameCtrl.GetComponent<S>();  //　GameControllerオブジェクトのShootingスクリプトを格納します
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")	　　　　　　　　　 //　もし、当たった相手のＴａｇはPlayerならば・・ 
        {
            points -= 1;				　　　　 //　pointから1を引いて、その値をポインｔにまた戻します 
            explosion.transform.position = other.transform.position;    //　explosionのポジションにplayerのポジションを入れます            　　
            explosion.Play();			　　　　 //　explosionエフェクトを再生します

            if (points <= 0)				//　もしpointsの値が０以下ならば
            {
                Destroy(this.gameObject);       //　このゲームオブジェクトを破壊します         
            }
            else return;
        }
    }
}