using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaruBatuQuizManager : MonoBehaviour
{
    // UI要素
    public Text questionText;   // 問題文表示用
    public Text resultText;     // 結果表示用
    public int Score;
    public static int ResultNumber2;

    // 問題リスト
    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex = 0; // 現在の問題番号

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, false);
        // 問題の初期化
        LoadQuestions();
        DisplayQuestion();
        ResultNumber2 = 0;
    }

    // 問題の設定
    void LoadQuestions()
    {
        questions.Add(new Question("地球は丸い？", true));
        questions.Add(new Question("太陽は地球の周りを回っている？", false));
        questions.Add(new Question("水は100℃で沸騰する？", true));
    }

    // 現在の問題を表示
    void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            resultText.text = ""; // 結果をクリア
            questionText.text = questions[currentQuestionIndex].question;
        }
        else
        {
            questionText.text = "クイズ終了！";
            resultText.text = "";
            ResultNumber2 += Score * 2;
            Invoke("LoadSceneResult", 3.0f);
        }
    }

    // 〇ボタン
    public void OnTrueButtonClicked()
    {
        CheckAnswer(true);
    }

    // ✕ボタン
    public void OnFalseButtonClicked()
    {
        CheckAnswer(false);
    }

    // 回答を確認
    void CheckAnswer(bool playerAnswer)
    {
        if (currentQuestionIndex < questions.Count)
        {
            bool correctAnswer = questions[currentQuestionIndex].answer;

            // 判定
            if (playerAnswer == correctAnswer)
            {
                Score += 1;
                resultText.text = "正解！！";
                resultText.color = Color.red;
            }
            else
            {
                resultText.text = "不正解！";
                resultText.color = Color.blue;
            }

            // 次の問題へ
            currentQuestionIndex++;
            Invoke("DisplayQuestion", 1.5f); // 1.5秒後に次の問題
        }
    }

    // 問題クラス
    [System.Serializable]
    public class Question
    {
        public string question;  // 問題文
        public bool answer;      // 正解 (true:〇, false:✕)

        public Question(string q, bool a)
        {
            question = q;
            answer = a;
        }
    }

    void LoadSceneResult()
    {
        SceneManager.LoadScene("結果");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
