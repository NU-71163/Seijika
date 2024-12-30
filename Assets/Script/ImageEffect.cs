using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 defaultScale;    // 初期サイズ
    private Outline outline;        // 枠線エフェクト
    public Text hoverText;

    // Start is called before the first frame update
    void Start()
    {
        // 初期サイズを記憶
        defaultScale = transform.localScale;

        // Outlineコンポーネントを取得
        outline = GetComponent<Outline>();

        // 枠線の初期設定
        if (outline != null)
        {
            outline.effectColor = Color.clear; // 初期状態では枠を透明にする
        }

        // Textを非表示に設定
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false);
        }
    }

    // マウスカーソルが画像に入った時
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 画像を拡大する
        transform.localScale = defaultScale * 1.2f;

        // 枠線の色を変更する
        if (outline != null)
        {
            outline.effectColor = Color.yellow; // 黄色の枠に変更
        }

        // Textを表示する
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(true);
        }
    }

    // マウスカーソルが画像から離れた時
    public void OnPointerExit(PointerEventData eventData)
    {
        // 画像のサイズを元に戻す
        transform.localScale = defaultScale;

        // 枠線の色を元に戻す
        if (outline != null)
        {
            outline.effectColor = Color.clear; // 枠を透明に戻す
        }

        // Textを非表示にする
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
