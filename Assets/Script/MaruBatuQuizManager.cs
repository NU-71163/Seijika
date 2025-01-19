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
        questions.Add(new Question("18歳以下に10万円の給付を行います。", true));
        questions.Add(new Question("最低賃金を100円に引き下げます。", false));
        questions.Add(new Question("核兵器のない世界を目指します。", true));
        questions.Add(new Question("2050年カーボンニュートラル実現に向けて、２兆円を国民から搾取します。", false));
        questions.Add(new Question("晩期の憲法改正を目指します", false));
        questions.Add(new Question("刑事責任を問われた議員の歳費支給停止を行います。", true));
        questions.Add(new Question("LGBTの差別加速や同性婚を認めないようにします。", false));
        questions.Add(new Question("大企業や富裕層に応分の負担を求める税制へと改革していきます。", true));
        questions.Add(new Question("ジェンダー平等を実現します。", true));
        questions.Add(new Question("年収1000万円程度未満を対象に、給料10%減を行います。", false));
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
            questionText.text = "投票終了！";
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
