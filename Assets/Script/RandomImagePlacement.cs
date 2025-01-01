using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImagePlacement : MonoBehaviour
{
    public List<Image> images;         // 設定する5枚のImage
    public Transform parentTransform;  // 親オブジェクトのTransform (配置する場所)

    // Start is called before the first frame update
    void Start()
    {
        // 配置をランダム化する
        ShuffleAndPlaceImages();
    }

    // Imageをシャッフルして配置するメソッド
    void ShuffleAndPlaceImages()
    {
        // 配置場所のリストを作成
        List<Vector3> positions = new List<Vector3>();

        // 初期位置を記録
        foreach (Image img in images)
        {
            positions.Add(img.transform.position); // 各Imageの位置を保存
        }

        // シャッフル処理
        for (int i = 0; i < positions.Count; i++)
        {
            int randomIndex = Random.Range(0, positions.Count);
            Vector3 temp = positions[i];
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        // ランダム化した位置にImageを配置
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.position = positions[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
