using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 defaultScale;    // �����T�C�Y
    private Outline outline;        // �g���G�t�F�N�g
    public Text hoverText;

    // Start is called before the first frame update
    void Start()
    {
        // �����T�C�Y���L��
        defaultScale = transform.localScale;

        // Outline�R���|�[�l���g���擾
        outline = GetComponent<Outline>();

        // �g���̏����ݒ�
        if (outline != null)
        {
            outline.effectColor = Color.clear; // ������Ԃł͘g�𓧖��ɂ���
        }

        // Text���\���ɐݒ�
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false);
        }
    }

    // �}�E�X�J�[�\�����摜�ɓ�������
    public void OnPointerEnter(PointerEventData eventData)
    {
        // �摜���g�傷��
        transform.localScale = defaultScale * 1.2f;

        // �g���̐F��ύX����
        if (outline != null)
        {
            outline.effectColor = Color.yellow; // ���F�̘g�ɕύX
        }

        // Text��\������
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(true);
        }
    }

    // �}�E�X�J�[�\�����摜���痣�ꂽ��
    public void OnPointerExit(PointerEventData eventData)
    {
        // �摜�̃T�C�Y�����ɖ߂�
        transform.localScale = defaultScale;

        // �g���̐F�����ɖ߂�
        if (outline != null)
        {
            outline.effectColor = Color.clear; // �g�𓧖��ɖ߂�
        }

        // Text���\���ɂ���
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
