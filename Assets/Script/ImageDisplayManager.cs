using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplayManager : MonoBehaviour
{
    public Image displayImage; // �\������Image�I�u�W�F�N�g

    public void ShowImage(Image clickedImage)
    {
        // �N���b�N���ꂽ�摜�̃X�v���C�g��\��Image�ɐݒ�
        displayImage.sprite = clickedImage.sprite;

        // �\��Image��L���ɂ���
        displayImage.gameObject.SetActive(true);
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
