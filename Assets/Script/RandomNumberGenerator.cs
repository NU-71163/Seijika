using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RandomNumberGenerator : MonoBehaviour, IPointerClickHandler
{
    public int seijikaNumber;
    public AnimationMove animationController5;
    public ImageDisplayManager displayManager;

    // �N���b�N���ꂽ�Ƃ��Ɏ��s����鏈��
    public void OnPointerClick(PointerEventData eventData)
    {
        // 1����100�܂ł̃����_���Ȑ����𐶐�
        seijikaNumber = Random.Range(1, 6);
        animationController5.PlayAnimation2("seijikakettei");
        displayManager.ShowImage(this.GetComponent<UnityEngine.UI.Image>());
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
