using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultQuiz : MonoBehaviour
{
    public Text Result;
    private int currentScore;
    public Animator animator; // Animator�R���|�[�l���g�ւ̎Q��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // �A�j���[�V�����Đ��֐�
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName); // �w�肳�ꂽ�A�j���[�V�������Đ�
    }

    // Update is called once per frame
    void Update()
    {
        Quizs quizScript = GameObject.Find("����c����(panel)").GetComponent<Quizs>();
        currentScore = quizScript.correct;

        Result.text = currentScore + " �� / 10 �⒆";
    }
}
