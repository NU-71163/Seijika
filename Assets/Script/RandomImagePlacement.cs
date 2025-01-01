using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImagePlacement : MonoBehaviour
{
    public List<Image> images;         // �ݒ肷��5����Image
    public Transform parentTransform;  // �e�I�u�W�F�N�g��Transform (�z�u����ꏊ)

    // Start is called before the first frame update
    void Start()
    {
        // �z�u�������_��������
        ShuffleAndPlaceImages();
    }

    // Image���V���b�t�����Ĕz�u���郁�\�b�h
    void ShuffleAndPlaceImages()
    {
        // �z�u�ꏊ�̃��X�g���쐬
        List<Vector3> positions = new List<Vector3>();

        // �����ʒu���L�^
        foreach (Image img in images)
        {
            positions.Add(img.transform.position); // �eImage�̈ʒu��ۑ�
        }

        // �V���b�t������
        for (int i = 0; i < positions.Count; i++)
        {
            int randomIndex = Random.Range(0, positions.Count);
            Vector3 temp = positions[i];
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        // �����_���������ʒu��Image��z�u
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.position = positions[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
