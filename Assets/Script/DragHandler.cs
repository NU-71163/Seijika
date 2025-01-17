using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour
{
    public static bool boxFlag;
    private Vector3 originalPosition; // ���̈ʒu���L������

    void OnMouseDrag()
    {
        //�h���b�O���͋z������ł͂���
        boxFlag = true;
        //�ȉ��l�s�̓h���b�O�������ɃI�u�W�F�N�g�𓮂����R�[�h
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        this.transform.position = worldPosition;
    }

    void OnMouseUp()
    {
        boxFlag = false;

        // �h���b�v��ɑΉ�����R���C�_�[�ɐG��Ă��Ȃ��ꍇ�͌��̈ʒu�ɖ߂�
        if (!IsOverlappingWithDropArea())
        {
            this.transform.position = originalPosition;
        }
    }

    // �h���b�v�\�G���A�ɓ����Ă��邩���肷��
    private bool IsOverlappingWithDropArea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<DropHandler>() != null)
            {
                return true; // �h���b�v�G���A�ɐG��Ă���
            }
        }

        return false; // �h���b�v�G���A�ɐG��Ă��Ȃ�
    }

    public void Return()
    {
        this.transform.position = originalPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
