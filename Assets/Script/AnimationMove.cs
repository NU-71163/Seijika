using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMove : MonoBehaviour
{
    public Animator animator1; // Animator�R���|�[�l���g�ւ̎Q��
    public Animator animator2;
    public TextDisplay2 display2;

    // �A�j���[�V�����Đ��֐�
    public void PlayAnimation1(string animationName)
    {
        animator1.Play(animationName); // �w�肳�ꂽ�A�j���[�V�������Đ�
        StartCoroutine(FixPosition1());
    }

    public void PlayAnimation2(string animationName)
    {
        animator2.Play(animationName);
        StartCoroutine(FixPosition2());
    }

    void EndAnimation()
    {
        if (display2 != null)
        {
            display2.OnAnimationEnd();
        }
    }

    IEnumerator FixPosition1()
    {
        // �A�j���[�V�����̒������擾
        float animationLength = animator1.GetCurrentAnimatorStateInfo(0).length;

        // �A�j���[�V�������I������܂ő҂�
        yield return new WaitForSeconds(animationLength);

        // ���W���Œ�i��: (0, 0, 0)�j
        transform.position = new Vector3(0, 0, 0);

        // Animator�𖳌������ăA�j���[�V�������~�߂�
        animator1.enabled = false;
    }

    IEnumerator FixPosition2()
    {
        // �A�j���[�V�����̒������擾
        float animationLength = animator2.GetCurrentAnimatorStateInfo(0).length;

        // �A�j���[�V�������I������܂ő҂�
        yield return new WaitForSeconds(animationLength);

        // ���W���Œ�i��: (0, 0, 0)�j
        transform.position = new Vector3(0, 0, 0);

        // Animator�𖳌������ăA�j���[�V�������~�߂�
        animator2.enabled = false;
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
