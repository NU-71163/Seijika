using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Text resultText;
    public static int Goukei;
    public AnimationMove1 animationController6;
    public ScoreHandler scoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, false);
        if (Quizs.ResultNumber1 >= 1)
        {
            Goukei = RandomNumberGenerator.seijikaNumber * Quizs.ResultNumber1;
        }
        if(MaruBatuQuizManager.ResultNumber2 >= 1)
        {
            Goukei = RandomNumberGenerator.seijikaNumber * MaruBatuQuizManager.ResultNumber2;
        }
        if (DropHandler.ResultNumber3 >= 1)
        {
            Goukei = RandomNumberGenerator.seijikaNumber * DropHandler.ResultNumber3;
        }
        Wei();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0は左クリック
        {
            // アニメーション再生
            animationController6.PlayAnimation3("Saisyu");
        }
        
        if (Quizs.ResultNumber1 >= 1)
        {
            resultText.text = RandomNumberGenerator.seijikaNumber + "点 × " + Quizs.ResultNumber1 + "点 = " + Goukei + "点";
        }
        if (MaruBatuQuizManager.ResultNumber2 >= 1)
        {
            resultText.text = RandomNumberGenerator.seijikaNumber + "点 × " + MaruBatuQuizManager.ResultNumber2 + "点 = " + Goukei + "点";
        }
        if (DropHandler.ResultNumber3 >= 1)
        {
            resultText.text = RandomNumberGenerator.seijikaNumber + "点 × " + DropHandler.ResultNumber3 + "点 = " + Goukei + "点";
        }
    }

    public void Wei()
    {
        scoreHandler.EvaluateScore();
    }
}
