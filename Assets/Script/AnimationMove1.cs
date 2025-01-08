using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMove1 : MonoBehaviour
{
    public Animator animator3;

    public void PlayAnimation3(string animationName)
    {
        animator3.Play(animationName);
        StartCoroutine(FixPosition3());
    }

    IEnumerator FixPosition3()
    {
        // �A�j���[�V�����̒������擾
        float animationLength = animator3.GetCurrentAnimatorStateInfo(0).length;

        // �A�j���[�V�������I������܂ő҂�
        yield return new WaitForSeconds(animationLength);

        // ���W���Œ�i��: (0, 0, 0)�j
        transform.position = new Vector3(0, 0, 0);

        // Animator�𖳌������ăA�j���[�V�������~�߂�
        animator3.enabled = false;
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
