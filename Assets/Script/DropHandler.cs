using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // �h���b�v���ꂽ�I�u�W�F�N�g���擾
        GameObject droppedObject = eventData.pointerDrag;

        // �h���b�v���ꂽ�I�u�W�F�N�g��ImageA�̎q�v�f�ɐݒ�
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
