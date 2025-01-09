using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector3 originalPosition;
    private Canvas canvas;

    // �h���b�O�J�n���̏���
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position; // ���̈ʒu���L�^
        transform.SetAsLastSibling();
    }

    // �h���b�O���̏���
    public void OnDrag(PointerEventData eventData)
    {
        // �}�E�X�J�[�\���̈ʒu�ɍ��킹�Ĉړ��iCanvas�̕`�惂�[�h�ɑΉ��j
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint);

        transform.position = Input.mousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
