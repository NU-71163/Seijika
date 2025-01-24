using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayName : MonoBehaviour
{
    public string[] texts;
    int textNumber;
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
    }

    void Update()
    {
        this.GetComponent<Text>().text = texts[textNumber];
        if (textNumber != texts.Length - 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                textNumber = textNumber + 1;
            }
        }
    }
}