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
            DisplayRandomMessage(new string[] { "すごい！", "頑張ったね！" });
        }
        else if (x >= 41 && x <= 80)
        {
            DisplayRandomMessage(new string[] { "まぁまぁだね", "普通だ" });
        }
        else if (x >= 81 && x <= 100)
        {
            DisplayRandomMessage(new string[] { "ひどいね", "最悪" });
        }
    }

    void DisplayRandomMessage(string[] messages)
    {
        string message = messages[Random.Range(0, messages.Length)];
        resultText.text = message;
        Debug.Log($"表示されるメッセージ: {message}");
        StartCoroutine(ChangeSceneAfterDelay(10f));
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
