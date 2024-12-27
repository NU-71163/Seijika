using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultQuiz : MonoBehaviour
{
    public Text Result;
    private int currentScore;
    public Animator animator; // Animatorコンポーネントへの参照

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // アニメーション再生関数
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName); // 指定されたアニメーションを再生
    }

    // Update is called once per frame
    void Update()
    {
        Quizs quizScript = GameObject.Find("国会議事堂(panel)").GetComponent<Quizs>();
        currentScore = quizScript.correct;

        Result.text = currentScore + " 問 / 10 問中";
    }
}
