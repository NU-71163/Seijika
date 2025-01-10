using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image; // UI Image コンポーネント
    private Color originalColor; // 元の色

    public Color glowColor = Color.yellow; // カーソルが当たったときの色

    void Start()
    {
        // Image コンポーネントを取得
        image = GetComponent<Image>();
        if (image != null)
        {
            originalColor = image.color; // 元の色を保存
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // カーソルが当たったときに色を変える
        if (image != null)
        {
            image.color = glowColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // カーソルが外れたときに元の色に戻す
        if (image != null)
        {
            image.color = originalColor;
        }
    }
}
