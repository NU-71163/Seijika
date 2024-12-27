using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class Quizs : MonoBehaviour
{
    private TextAsset csvFile;  // CSVファイル
    private List<string[]> csvData = new List<string[]>();  // CSVファイルの中身を入れるリスト
    int index; //問題番号
    public int correct; //正解数
    bool AnswerFlag;    //解答判定
    float timelimit = 10f; //制限時間
    float nowtimer = 0f;   //経過時間
    public Text ProblemLog;  //問題文
    public Text ProblemNum;  //問題番号
    public Text[] ChoiceLog;    //選択肢文字
    public Text time;    //残り時間表示
    public Button[] ChoiceBtns;   //選択肢
    private List<int> numbers = new List<int> { 1, 2, 3, 4 };   //選択肢番号
    private List<int> Problem = new List<int> { }; //未正解問題
    public Slider TimeSlider;   //残り時間ゲージ
    public resultQuiz animationController1; // スクリプトへの参照
    public QuizSeikai animationController2;
    public QuizHuseikai animationController3;

    void Start()
    {
        //CSVロード
        csvFile = Resources.Load("Seijika") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
        }

        //CSVの問題をリストにいれる
        Problem = new List<int>(csvData.Count);
        for (int i = 0; i < csvData.Count; i++)
        {
            Problem.Add(i);
        }
        Shuffle(Problem);  //問題をシャッフル
        Debug.Log("Problem: " + string.Join(", ", Problem.Select(x => x.ToString())));


        TimeSlider.value = 1f;  //制限時間ゲージ

        // 最初の問題を表示
        ShowNextQuestion();
    }

    void Update()
    {
        //時間制御
        nowtimer += Time.deltaTime; // タイマー
        float t = nowtimer / timelimit;// スライダーの値ー正規化
        TimeSlider.value = Mathf.Lerp(1f, 0f, t);
        float TimeLimit = 10f - nowtimer; //残り時間
        TimeLimit = Mathf.Max(TimeLimit, 0f);

        string LimitLog = TimeLimit.ToString("F0");
        time.text = LimitLog + "秒";
        time.color = (TimeLimit > 5.5f) ? Color.black : Color.red;// 5.5秒以上は緑、5.5秒未満は赤

        // タイムオーバー
        if (nowtimer >= timelimit)
        {
            nowtimer = 0f;     //タイマーを0秒に戻す
            AnswerFlag = false;
            StartCoroutine(NextQuestion());
        }
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1.5f);  // 待つ

        ShowNextQuestion();
    }

    void ShowNextQuestion()
    {
        string No = (index + 1).ToString(); //問題番号
        ProblemNum.text = "第" + No + "問";

        // 問題と選択肢を表示
        if (Problem.Count > index)
        {
            if (index < 10) //10問連続で出題、0から始めているから未満
            {
                Quiz();
            }
            else
            {
                Time.timeScale = 0;
                Debug.Log("問題終了");
            }
        }
        else if (Problem.Count == index)
        {
            Debug.Log("終了!!!!");
            animationController1.PlayAnimation("ResultQuizAnimation");
            Invoke("LoadSceneResult", 5.0f);
        }
    }
    void Quiz()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            int randomrow = Problem[index];
            int randomcol = numbers[i];
            ProblemLog.text = csvData[randomrow][0];
            ChoiceLog[i].text = csvData[randomrow][randomcol];

            // すでにイベントが追加されている場合は一旦解除してから追加
            ChoiceBtns[i].onClick.RemoveAllListeners();
            ChoiceBtns[i].onClick.AddListener(() => OnButtonClick(randomcol));
        }

        // タイマーをリセット
        ResetTimer();
        Shuffle(numbers);
    }


     void OnButtonClick(int selectedAnswer)
        {
         if (selectedAnswer == 1)
         {
             AnswerFlag = true;
         }
         else
         {
             AnswerFlag = false;
         }

         AnswerCheck();
         // 次の問題を表示
         StartCoroutine(NextQuestion());
     }


        void AnswerCheck()
        {
            ResetTimer();
            if (AnswerFlag == true)//正解
            {
                correct += 1;   //正解数
                animationController2.PlayAnimation("Seikai");
            }
            else if(AnswerFlag == false)
            {
                animationController3.PlayAnimation("Huseikai");
            }
            index += 1;//次の問題へ

            //正解の割合
            float Rate = correct / (float)index * 100;
            string Ratenum = Rate.ToString("F0");
            string correctNum = correct.ToString();
        }

        void ResetTimer()
        {
            nowtimer = 0f;
            Time.timeScale = 1.0f;
        }

        // Fisher-Yatesシャッフル
        void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

    void LoadSceneResult()
    {
        SceneManager.LoadScene("結果");
    }
}