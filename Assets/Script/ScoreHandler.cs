using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{
    public Text resultText;
    private int x; // スコア

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EvaluateScore()
    {
        x = ResultDisplay.Goukei;
        if (x >= 0 && x <= 40) 
        {
            DisplayRandomMessage(new string[] { "ソー・政治家の堕落により、日本の消費税が50%になった。", "金融政策の「ソーセージミクス」を提案して、実行直後は良い評価を得ていたが、裏金問題が発覚し議員を辞職した。" });
        }
        else if (x >= 41 && x <= 80)
        {
            DisplayRandomMessage(new string[] { "ソー・政治家は頑張ったが、日本の消費税が15%になった。", "金融政策の「ソーセージミクス」を提案したが、日本の景気は悪くなってしまった。" });
        }
        else if (x >= 81 && x <= 100)
        {
            DisplayRandomMessage(new string[] { "ソー・政治家の活躍により、日本の消費税が3%になった。", "金融政策の「ソーセージミクス」を提案したことにより、日本の景気が良くなった。" });
        }
    }

    void DisplayRandomMessage(string[] messages)
    {
        string message = messages[Random.Range(0, messages.Length)];
        resultText.text = message;
        Debug.Log($"表示されるメッセージ: {message}");
        StartCoroutine(ChangeSceneAfterDelay(100f));
    }

    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("タイトル"); // SceneCに移動
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
