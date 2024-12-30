using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMove : MonoBehaviour
{
    public Animator animator; // Animator�R���|�[�l���g�ւ̎Q��

    // �A�j���[�V�����Đ��֐�
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName); // �w�肳�ꂽ�A�j���[�V�������Đ�
        StartCoroutine(FixPosition());
    }

    IEnumerator FixPosition()
    {
        // �A�j���[�V�����̒������擾
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // �A�j���[�V�������I������܂ő҂�
        yield return new WaitForSeconds(animationLength);

        // ���W���Œ�i��: (0, 0, 0)�j
        transform.position = new Vector3(0, 0, 0);

        // Animator�𖳌������ăA�j���[�V�������~�߂�
        animator.enabled = false;
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
