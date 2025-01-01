using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RandomNumberGenerator : MonoBehaviour, IPointerClickHandler
{
    public int seijikaNumber;
    public AnimationMove animationController5;
    public ImageDisplayManager displayManager;

    // クリックされたときに実行される処理
    public void OnPointerClick(PointerEventData eventData)
    {
        // 1から100までのランダムな数字を生成
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
