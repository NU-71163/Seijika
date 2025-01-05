using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDisplay2 : MonoBehaviour
{
    public string[] texts;//Unity上で入力するstringの配列
    int textNumber;//何番目のtexts[]を表示させるか
    string displayText;//表示させるstring
    int textCharNumber;//何文字目をdisplayTextに追加するか
    int displayTextSpeed; //全体のフレームレートを落とす変数
    bool click;//クリック判定
    bool textStop; //テキスト表示を始めるか

    public bool isAnimationFinished = false; // アニメーション終了フラグ
    public Animator animator; // Animatorコンポーネント
    public AnimationMove animationController5;

    void Start()
    {
        isAnimationFinished = false; // 初期状態はアニメーション未完了
    }

    void Update()
    {
        // アニメーションが終了するまでクリック不可
        if (!isAnimationFinished)
        {
            return; // アニメーションが終わるまで処理を停止
        }

        if (textStop == false) //テキストを表示させるif文
        {
            displayTextSpeed++;
            if (displayTextSpeed % 20 == 0)//20回に一回プログラムを実行するif文
            {

                if (textCharNumber != texts[textNumber].Length)//もしtext[textNumber]の文字列の文字が最後の文字じゃなければ
                {
                    displayText = displayText + texts[textNumber][textCharNumber];//displayTextに文字を追加していく
                    textCharNumber = textCharNumber + 1;//次の文字にする
                }
                else//もしtext[textNumber]の文字列の文字が最後の文字だったら
                {
                    if (textNumber != texts.Length - 1)//もしtexts[]が最後のセリフじゃないときは
                    {
                        if (click == true)//クリックされた判定
                        {
                            displayText = "";//表示させる文字列を消す
                            textCharNumber = 0;//文字の番号を最初にする
                            textNumber = textNumber + 1;//次のセリフにする
                        }
                    }
                    else //もしtexts[]が最後のセリフになったら
                    {
                        if (click == true) //クリックされた判定
                        {
                            SceneManager.LoadScene("ルーレット");
                            displayText = ""; //表示させる文字列も消す
                            textCharNumber = 0; //文字の番号を最初にする
                            textStop = true; //セリフ表示を止める
                        }
                    }
                }

                this.GetComponent<Text>().text = displayText;//画面上にdisplayTextを表示
                click = false;//クリックされた判定を解除
            }
            if (Input.GetMouseButton(0))//マウスをクリックしたら
            {
                click = true; //クリックされた判定にする
            }
        }
    }

    // アニメーション終了時に呼び出される関数
    public void OnAnimationEnd()
    {
        isAnimationFinished = true; // アニメーション終了を通知
    }
}