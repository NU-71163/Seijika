using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMove : MonoBehaviour
{
    public Animator animator1; // Animatorコンポーネントへの参照
    public Animator animator2;
    public TextDisplay2 display2;

    // アニメーション再生関数
    public void PlayAnimation1(string animationName)
    {
        animator1.Play(animationName); // 指定されたアニメーションを再生
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
        // アニメーションの長さを取得
        float animationLength = animator1.GetCurrentAnimatorStateInfo(0).length;

        // アニメーションが終了するまで待つ
        yield return new WaitForSeconds(animationLength);

        // 座標を固定（例: (0, 0, 0)）
        transform.position = new Vector3(0, 0, 0);

        // Animatorを無効化してアニメーションを止める
        animator1.enabled = false;
    }

    IEnumerator FixPosition2()
    {
        // アニメーションの長さを取得
        float animationLength = animator2.GetCurrentAnimatorStateInfo(0).length;

        // アニメーションが終了するまで待つ
        yield return new WaitForSeconds(animationLength);

        // 座標を固定（例: (0, 0, 0)）
        transform.position = new Vector3(0, 0, 0);

        // Animatorを無効化してアニメーションを止める
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
