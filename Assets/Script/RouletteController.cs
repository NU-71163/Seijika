using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RouletteController : MonoBehaviour
{
    public RectTransform rouletteImage; // ルーレットのImage
    public float spinSpeed = 300f;      // 回転速度
    public bool isSpinning = false;    // 回転中かどうか
    private float deceleration;   // 減速率
    private float currentSpeed = 0f;   // 現在の回転速度

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, false);
    }

    // Update is called once per frame
    void Update()
    {
        // 回転処理
        if (isSpinning)
        {
            // 回転速度を減速
            currentSpeed -= deceleration * Time.deltaTime;

            // 回転速度が0以下になったら停止
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                isSpinning = false;
                DetermineResult(); // 結果判定
            }

            // ルーレットを回転させる
            rouletteImage.Rotate(0, 0, currentSpeed * Time.deltaTime);
        }
    }

    // ボタンを押したときに呼ばれる関数
    public void StartSpin()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            currentSpeed = spinSpeed; // 初期回転速度設定
            deceleration = Random.Range(10f, 20f);
        }
    }

    // 結果判定
    private void DetermineResult()
    {
        // 最終的な角度を取得 (0～360度)
        float angle = rouletteImage.eulerAngles.z;

        // 120度ごとに分けて結果判定 (3分割)
        if (angle >= 0 && angle < 120)
        {
            Debug.Log("結果：赤");
            SceneManager.LoadScene("ミニゲーム１");
        }
        else if (angle >= 120 && angle < 240)
        {
            Debug.Log("結果：青");
            SceneManager.LoadScene("ミニゲーム２");
        }
        else
        {
            Debug.Log("結果：緑");
            SceneManager.LoadScene("ミニゲーム３");
        }
    }
}
