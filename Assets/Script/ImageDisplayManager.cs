using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplayManager : MonoBehaviour
{
    public Image displayImage; // 表示するImageオブジェクト

    public void ShowImage(Image clickedImage)
    {
        // クリックされた画像のスプライトを表示Imageに設定
        displayImage.sprite = clickedImage.sprite;

        // スプライト名を保存
        PlayerPrefs.SetString("SelectedSprite", clickedImage.sprite.name);
        PlayerPrefs.Save(); // データを保存

        // 表示Imageを有効にする
        displayImage.gameObject.SetActive(true);
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
