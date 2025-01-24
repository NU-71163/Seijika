using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RouletteController : MonoBehaviour
{
    public RectTransform rouletteImage; // ���[���b�g��Image
    public float spinSpeed = 300f;      // ��]���x
    public bool isSpinning = false;    // ��]�����ǂ���
    private float deceleration;   // ������
    private float currentSpeed = 0f;   // ���݂̉�]���x

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, false);
    }

    // Update is called once per frame
    void Update()
    {
        // ��]����
        if (isSpinning)
        {
            // ��]���x������
            currentSpeed -= deceleration * Time.deltaTime;

            // ��]���x��0�ȉ��ɂȂ������~
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                isSpinning = false;
                DetermineResult(); // ���ʔ���
            }

            // ���[���b�g����]������
            rouletteImage.Rotate(0, 0, currentSpeed * Time.deltaTime);
        }
    }

    // �{�^�����������Ƃ��ɌĂ΂��֐�
    public void StartSpin()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            currentSpeed = spinSpeed; // ������]���x�ݒ�
            deceleration = Random.Range(10f, 20f);
        }
    }

    // ���ʔ���
    private void DetermineResult()
    {
        // �ŏI�I�Ȋp�x���擾 (0�`360�x)
        float angle = rouletteImage.eulerAngles.z;

        // 120�x���Ƃɕ����Č��ʔ��� (3����)
        if (angle >= 0 && angle < 120)
        {
            Debug.Log("���ʁF��");
            SceneManager.LoadScene("�~�j�Q�[���P");
        }
        else if (angle >= 120 && angle < 240)
        {
            Debug.Log("���ʁF��");
            SceneManager.LoadScene("�~�j�Q�[���Q");
        }
        else
        {
            Debug.Log("���ʁF��");
            SceneManager.LoadScene("�~�j�Q�[���R");
        }
    }
}
