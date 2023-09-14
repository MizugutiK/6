using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GM1 : MonoBehaviour
{
    public Text gameText;			//　Text型の変数goalTextを用意します	

    void Start()
    {
        gameText = GameObject.Find("game").GetComponent<Text>();　//　”Goal”という名のObjectを探して、そのTextコンポネントを入れます
        gameText.gameObject.SetActive(false);	　　　　　//　その入れたTextのgameObjectをfalseにして表示を止めておきます
    }

    public void gameFlag()			//　他のクラスからアクセス可能なpublicのGaolFlag()というメソッドをつくりました　
    {
        gameText.gameObject.SetActive(true);		//　SetActiveをtrueにするだけのメソッドです	
        return;     				//　戻ります（書かなくても動きますが・・）
    }
}