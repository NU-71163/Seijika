using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{
    public Text resultText;
    private int x; // �X�R�A

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EvaluateScore()
    {
        x = ResultDisplay.Goukei;
        if (x >= 0 && x <= 40) 
        {
            DisplayRandomMessage(new string[] { "�\�[�E�����Ƃ̑��ɂ��A���{�̏���ł�50%�ɂȂ����B", "���Z����́u�\�[�Z�[�W�~�N�X�v���Ă��āA���s����͗ǂ��]���𓾂Ă������A������肪���o���c�������E�����B" });
        }
        else if (x >= 41 && x <= 80)
        {
            DisplayRandomMessage(new string[] { "�\�[�E�����Ƃ͊撣�������A���{�̏���ł�15%�ɂȂ����B", "���Z����́u�\�[�Z�[�W�~�N�X�v���Ă������A���{�̌i�C�͈����Ȃ��Ă��܂����B" });
        }
        else if (x >= 81 && x <= 100)
        {
            DisplayRandomMessage(new string[] { "�\�[�E�����Ƃ̊���ɂ��A���{�̏���ł�3%�ɂȂ����B", "���Z����́u�\�[�Z�[�W�~�N�X�v���Ă������Ƃɂ��A���{�̌i�C���ǂ��Ȃ����B" });
        }
    }

    void DisplayRandomMessage(string[] messages)
    {
        string message = messages[Random.Range(0, messages.Length)];
        resultText.text = message;
        Debug.Log($"�\������郁�b�Z�[�W: {message}");
        StartCoroutine(ChangeSceneAfterDelay(100f));
    }

    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("�^�C�g��"); // SceneC�Ɉړ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
