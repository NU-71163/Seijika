using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector3 originalPosition;
    private Canvas canvas;

    // ドラッグ開始時の処理
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position; // 元の位置を記録
        transform.SetAsLastSibling();
    }

    // ドラッグ中の処理
    public void OnDrag(PointerEventData eventData)
    {
        // マウスカーソルの位置に合わせて移動（Canvasの描画モードに対応）
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
