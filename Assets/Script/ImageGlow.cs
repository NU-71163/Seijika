using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image; // UI Image �R���|�[�l���g
    private Color originalColor; // ���̐F

    public Color glowColor = Color.yellow; // �J�[�\�������������Ƃ��̐F

    void Start()
    {
        // Image �R���|�[�l���g���擾
        image = GetComponent<Image>();
        if (image != null)
        {
            originalColor = image.color; // ���̐F��ۑ�
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // �J�[�\�������������Ƃ��ɐF��ς���
        if (image != null)
        {
            image.color = glowColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // �J�[�\�����O�ꂽ�Ƃ��Ɍ��̐F�ɖ߂�
        if (image != null)
        {
            image.color = originalColor;
        }
    }
}
