using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSeikai : MonoBehaviour
{
    public Animator animator;

    // アニメーション再生関数
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName); // 指定されたアニメーションを再生
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
