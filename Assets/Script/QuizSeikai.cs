using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSeikai : MonoBehaviour
{
    public Animator animator;

    // �A�j���[�V�����Đ��֐�
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName); // �w�肳�ꂽ�A�j���[�V�������Đ�
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
