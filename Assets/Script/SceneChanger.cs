using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 遷移先のシーン名
    public string targetScene;

    // クリックされたときに呼び出される関数
    public void OnImageClick()
    {
        // シーンをロード
        SceneManager.LoadScene(targetScene);
    }
}
