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
        // アニメーションの長さを取得
        float animationLength = animator3.GetCurrentAnimatorStateInfo(0).length;

        // アニメーションが終了するまで待つ
        yield return new WaitForSeconds(animationLength);

        // 座標を固定（例: (0, 0, 0)）
        transform.position = new Vector3(0, 0, 0);

        // Animatorを無効化してアニメーションを止める
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
