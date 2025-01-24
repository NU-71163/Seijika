using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayName : MonoBehaviour
{
    public string[] texts;
    public AudioClip[] audioClips; // 再生するオーディオの配列
    AudioSource audioSource; // AudioSource コンポーネント
    int textNumber = 0; // 現在のテキスト番号
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

                // 音声を再生（配列の範囲内で）
                if (textNumber < audioClips.Length)
                {
                    audioSource.clip = audioClips[textNumber];
                    audioSource.Play();
                }
            }
        }
    }
}