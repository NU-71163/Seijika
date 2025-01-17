using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour
{
    public static bool boxFlag;
    private Vector3 originalPosition; // 元の位置を記憶する

    void OnMouseDrag()
    {
        //ドラッグ中は吸い込んではだめ
        boxFlag = true;
        //以下四行はドラッグした時にオブジェクトを動かすコード
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        this.transform.position = worldPosition;
    }

    void OnMouseUp()
    {
        boxFlag = false;

        // ドロップ先に対応するコライダーに触れていない場合は元の位置に戻す
        if (!IsOverlappingWithDropArea())
        {
            this.transform.position = originalPosition;
        }
    }

    // ドロップ可能エリアに入っているか判定する
    private bool IsOverlappingWithDropArea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<DropHandler>() != null)
            {
                return true; // ドロップエリアに触れている
            }
        }

        return false; // ドロップエリアに触れていない
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
