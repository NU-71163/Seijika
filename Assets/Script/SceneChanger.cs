using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // �J�ڐ�̃V�[����
    public string targetScene;

    // �N���b�N���ꂽ�Ƃ��ɌĂяo�����֐�
    public void OnImageClick()
    {
        // �V�[�������[�h
        SceneManager.LoadScene(targetScene);
    }
}
