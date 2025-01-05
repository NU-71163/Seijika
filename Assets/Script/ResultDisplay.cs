using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Text resultText;
    public int Goukei;

    // Start is called before the first frame update
    void Start()
    {
        Goukei = RandomNumberGenerator.seijikaNumber * Quizs.ResultNumber;
    }

    // Update is called once per frame
    void Update()
    {
        resultText.text = RandomNumberGenerator.seijikaNumber + "ì_ Å~ " + Quizs.ResultNumber + "ì_ = " + Goukei + "ì_";
    }
}
