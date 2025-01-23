using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropHandler : MonoBehaviour
{
    public Sprite[] spritePool; // 5����Sprite���i�[����z��
    public Sprite currentRequiredSprite; // ���ݗv�����Ă���Sprite
    public int points = 0;
    public static int ResultNumber3;

    public SpriteRenderer spriteRenderer;
    private DragHandler[] dragHandlers;

    private int requestCount = 0; // ���݂̗v����
    private const int maxRequests = 10; // �ő�̗v����

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, false);
        ResultNumber3 = 0;
        dragHandlers = FindObjectsOfType<DragHandler>();
        SetRandomRequiredSprite();
    }

    void SetRandomRequiredSprite()
    {
        if (requestCount >= maxRequests)
        {            
            ResultNumber3 = points * 2;
            SceneManager.LoadScene("����");
            return; // 10��ɒB�����牽�����Ȃ�
        }

        if (spritePool.Length == 0)
        {
            Debug.LogError("SpritePool����ł��I");
            return;
        }

        // �����_���ŗv������Sprite��I��
        int randomIndex = Random.Range(0, spritePool.Length);
        currentRequiredSprite = spritePool[randomIndex];

        // �f�o�b�O�p���b�Z�[�W
        Debug.Log($"�v�����ꂽSprite: {currentRequiredSprite.name}");

        // �K�v�Ȃ�v�����ꂽSprite��UI��GameObject�ɔ��f
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = currentRequiredSprite;
        }

        requestCount++;
        StartCoroutine(ReturnAfterDelay());
    }

    IEnumerator ReturnAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 1�b�ҋ@

        foreach (DragHandler dragHandler in dragHandlers)
        {
            dragHandler.Return();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // �h���b�O���ĂȂ�����
        if (DragHandler.boxFlag == false)
        {
            // �z�����ށi�ʒu�����킹��j
            other.transform.position = this.transform.position;

            // �z�����ݏI�������t���O���
            DragHandler.boxFlag = true;

            // �h���b�v���ꂽ�I�u�W�F�N�g��Sprite���m�F
            SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
            if (otherSpriteRenderer != null)
            {
                if (otherSpriteRenderer.sprite == currentRequiredSprite)
                {
                    // �v�����ꂽSprite���������ꍇ�A�|�C���g���Z
                    points += 1;
                    Debug.Log($"�����I���݂̃|�C���g: {points}");

                    // ���̗v�����Z�b�g
                    SetRandomRequiredSprite();
                }
                else
                {
                    // �Ԉ����Sprite�̏ꍇ�A�|�C���g���_
                    points -= 1;
                    Debug.Log($"�s�����I���݂̃|�C���g: {points}");
                }
            }
            else
            {
                Debug.Log("�h���b�v���ꂽ�I�u�W�F�N�g��SpriteRenderer������܂���");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
