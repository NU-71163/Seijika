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
    private TextAsset csvFile;  // CSV�t�@�C��
    private List<string[]> csvData = new List<string[]>();  // CSV�t�@�C���̒��g�����郊�X�g
    int index; //���ԍ�
    public int correct; //����
    bool AnswerFlag;    //�𓚔���
    float timelimit = 10f; //��������
    float nowtimer = 0f;   //�o�ߎ���
    public Text ProblemLog;  //��蕶
    public Text ProblemNum;  //���ԍ�
    public Text[] ChoiceLog;    //�I��������
    public Text time;    //�c�莞�ԕ\��
    public Button[] ChoiceBtns;   //�I����
    private List<int> numbers = new List<int> { 1, 2, 3, 4 };   //�I�����ԍ�
    private List<int> Problem = new List<int> { }; //��������
    public Slider TimeSlider;   //�c�莞�ԃQ�[�W
    public resultQuiz animationController1; // �X�N���v�g�ւ̎Q��
    public QuizSeikai animationController2;
    public QuizHuseikai animationController3;

    void Start()
    {
        //CSV���[�h
        csvFile = Resources.Load("Seijika") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
        }

        //CSV�̖������X�g�ɂ����
        Problem = new List<int>(csvData.Count);
        for (int i = 0; i < csvData.Count; i++)
        {
            Problem.Add(i);
        }
        Shuffle(Problem);  //�����V���b�t��
        Debug.Log("Problem: " + string.Join(", ", Problem.Select(x => x.ToString())));


        TimeSlider.value = 1f;  //�������ԃQ�[�W

        // �ŏ��̖���\��
        ShowNextQuestion();
    }

    void Update()
    {
        //���Ԑ���
        nowtimer += Time.deltaTime; // �^�C�}�[
        float t = nowtimer / timelimit;// �X���C�_�[�̒l�[���K��
        TimeSlider.value = Mathf.Lerp(1f, 0f, t);
        float TimeLimit = 10f - nowtimer; //�c�莞��
        TimeLimit = Mathf.Max(TimeLimit, 0f);

        string LimitLog = TimeLimit.ToString("F0");
        time.text = LimitLog + "�b";
        time.color = (TimeLimit > 5.5f) ? Color.black : Color.red;// 5.5�b�ȏ�͗΁A5.5�b�����͐�

        // �^�C���I�[�o�[
        if (nowtimer >= timelimit)
        {
            nowtimer = 0f;     //�^�C�}�[��0�b�ɖ߂�
            AnswerFlag = false;
            StartCoroutine(NextQuestion());
        }
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1.5f);  // �҂�

        ShowNextQuestion();
    }

    void ShowNextQuestion()
    {
        string No = (index + 1).ToString(); //���ԍ�
        ProblemNum.text = "��" + No + "��";

        // ���ƑI������\��
        if (Problem.Count > index)
        {
            if (index < 10) //10��A���ŏo��A0����n�߂Ă��邩�疢��
            {
                Quiz();
            }
            else
            {
                Time.timeScale = 0;
                Debug.Log("���I��");
            }
        }
        else if (Problem.Count == index)
        {
            Debug.Log("�I��!!!!");
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

            // ���łɃC�x���g���ǉ�����Ă���ꍇ�͈�U�������Ă���ǉ�
            ChoiceBtns[i].onClick.RemoveAllListeners();
            ChoiceBtns[i].onClick.AddListener(() => OnButtonClick(randomcol));
        }

        // �^�C�}�[�����Z�b�g
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
         // ���̖���\��
         StartCoroutine(NextQuestion());
     }


        void AnswerCheck()
        {
            ResetTimer();
            if (AnswerFlag == true)//����
            {
                correct += 1;   //����
                animationController2.PlayAnimation("Seikai");
            }
            else if(AnswerFlag == false)
            {
                animationController3.PlayAnimation("Huseikai");
            }
            index += 1;//���̖���

            //�����̊���
            float Rate = correct / (float)index * 100;
            string Ratenum = Rate.ToString("F0");
            string correctNum = correct.ToString();
        }

        void ResetTimer()
        {
            nowtimer = 0f;
            Time.timeScale = 1.0f;
        }

        // Fisher-Yates�V���b�t��
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
        SceneManager.LoadScene("����");
    }
}