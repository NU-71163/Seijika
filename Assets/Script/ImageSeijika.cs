using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSeijika : MonoBehaviour
{
    public Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        // 保存されたスプライト名を取得
        string spriteName = PlayerPrefs.GetString("SelectedSprite", "");

        if (!string.IsNullOrEmpty(spriteName))
        {
            // Resourcesフォルダからスプライトをロード
            Sprite loadedSprite = Resources.Load<Sprite>(spriteName);

            if (loadedSprite != null)
            {
                displayImage.sprite = loadedSprite; // スプライトを設定
            }
            else
            {
                Debug.LogError("スプライトが見つかりません: " + spriteName);
            }
        }
        else
        {
            Debug.LogError("PlayerPrefsにスプライト名が保存されていません。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
