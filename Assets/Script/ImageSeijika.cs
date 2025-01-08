using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSeijika : MonoBehaviour
{
    public Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        // �ۑ����ꂽ�X�v���C�g�����擾
        string spriteName = PlayerPrefs.GetString("SelectedSprite", "");

        if (!string.IsNullOrEmpty(spriteName))
        {
            // Resources�t�H���_����X�v���C�g�����[�h
            Sprite loadedSprite = Resources.Load<Sprite>(spriteName);

            if (loadedSprite != null)
            {
                displayImage.sprite = loadedSprite; // �X�v���C�g��ݒ�
            }
            else
            {
                Debug.LogError("�X�v���C�g��������܂���: " + spriteName);
            }
        }
        else
        {
            Debug.LogError("PlayerPrefs�ɃX�v���C�g�����ۑ�����Ă��܂���B");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
