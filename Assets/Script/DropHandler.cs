using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // ドロップされたオブジェクトを取得
        GameObject droppedObject = eventData.pointerDrag;

        // ドロップされたオブジェクトをImageAの子要素に設定
        if (droppedObject != null)
        {
            droppedObject.transform.SetParent(transform);
            droppedObject.transform.position = transform.position;
        }
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
