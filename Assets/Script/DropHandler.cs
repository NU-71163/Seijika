using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropHandler : MonoBehaviour
{
    public Sprite[] spritePool; // 5枚のSpriteを格納する配列
    public Sprite currentRequiredSprite; // 現在要求しているSprite
    public int points = 0;
    public static int ResultNumber3;

    public SpriteRenderer spriteRenderer;
    private DragHandler[] dragHandlers;

    private int requestCount = 0; // 現在の要求回数
    private const int maxRequests = 10; // 最大の要求回数

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
            SceneManager.LoadScene("結果");
            return; // 10回に達したら何もしない
        }

        if (spritePool.Length == 0)
        {
            Debug.LogError("SpritePoolが空です！");
            return;
        }

        // ランダムで要求するSpriteを選択
        int randomIndex = Random.Range(0, spritePool.Length);
        currentRequiredSprite = spritePool[randomIndex];

        // デバッグ用メッセージ
        Debug.Log($"要求されたSprite: {currentRequiredSprite.name}");

        // 必要なら要求されたSpriteをUIやGameObjectに反映
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = currentRequiredSprite;
        }

        requestCount++;
        StartCoroutine(ReturnAfterDelay());
    }

    IEnumerator ReturnAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 1秒待機

        foreach (DragHandler dragHandler in dragHandlers)
        {
            dragHandler.Return();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // ドラッグしてない時は
        if (DragHandler.boxFlag == false)
        {
            // 吸い込む（位置を合わせる）
            other.transform.position = this.transform.position;

            // 吸い込み終わったらフラグ解放
            DragHandler.boxFlag = true;

            // ドロップされたオブジェクトのSpriteを確認
            SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
            if (otherSpriteRenderer != null)
            {
                if (otherSpriteRenderer.sprite == currentRequiredSprite)
                {
                    // 要求されたSpriteが正しい場合、ポイント加算
                    points += 1;
                    Debug.Log($"正解！現在のポイント: {points}");

                    // 次の要求をセット
                    SetRandomRequiredSprite();
                }
                else
                {
                    // 間違ったSpriteの場合、ポイント減点
                    points -= 1;
                    Debug.Log($"不正解！現在のポイント: {points}");
                }
            }
            else
            {
                Debug.Log("ドロップされたオブジェクトにSpriteRendererがありません");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
