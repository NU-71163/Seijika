using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Text resultText;
    public int Goukei;
    public AnimationMove1 animationController6;

    // Start is called before the first frame update
    void Start()
    {
        if(Quizs.ResultNumber != null)
        {
            Goukei = RandomNumberGenerator.seijikaNumber * Quizs.ResultNumber;
        }
        if(MaruBatuQuizManager.ResultNumber != null)
        {
            Goukei = RandomNumberGenerator.seijikaNumber * MaruBatuQuizManager.ResultNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0は左クリック
        {
            // アニメーション再生
            animationController6.PlayAnimation3("Saisyu");
        }
        
        if (Quizs.ResultNumber != null)
        {
            resultText.text = RandomNumberGenerator.seijikaNumber + "点 × " + Quizs.ResultNumber + "点 = " + Goukei + "点";
        }
        if (MaruBatuQuizManager.ResultNumber != null)
        {
            resultText.text = RandomNumberGenerator.seijikaNumber + "点 × " + MaruBatuQuizManager.ResultNumber + "点 = " + Goukei + "点";
        }
    }
}
