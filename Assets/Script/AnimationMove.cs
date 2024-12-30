using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMove : MonoBehaviour
{
    public Animator animator; // Animatorコンポーネントへの参照

    // アニメーション再生関数
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName); // 指定されたアニメーションを再生
        StartCoroutine(FixPosition());
    }

    IEnumerator FixPosition()
    {
        // アニメーションの長さを取得
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // アニメーションが終了するまで待つ
        yield return new WaitForSeconds(animationLength);

        // 座標を固定（例: (0, 0, 0)）
        transform.position = new Vector3(0, 0, 0);

        // Animatorを無効化してアニメーションを止める
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
