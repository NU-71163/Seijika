using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayName : MonoBehaviour
{
    public string[] texts;
    public AudioClip[] audioClips; // �Đ�����I�[�f�B�I�̔z��
    AudioSource audioSource; // AudioSource �R���|�[�l���g
    int textNumber = 0; // ���݂̃e�L�X�g�ԍ�
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        this.GetComponent<Text>().text = texts[textNumber];

        if (textNumber != texts.Length - 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                textNumber++;

                // �������Đ��i�z��͈͓̔��Łj
                if (textNumber < audioClips.Length)
                {
                    audioSource.clip = audioClips[textNumber];
                    audioSource.Play();
                }
            }
        }
    }
}