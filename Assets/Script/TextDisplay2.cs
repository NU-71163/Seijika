using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDisplay2 : MonoBehaviour
{
    public string[] texts;//Unity��œ��͂���string�̔z��
    int textNumber;//���Ԗڂ�texts[]��\�������邩
    string displayText;//�\��������string
    int textCharNumber;//�������ڂ�displayText�ɒǉ����邩
    int displayTextSpeed; //�S�̂̃t���[�����[�g�𗎂Ƃ��ϐ�
    bool click;//�N���b�N����
    bool textStop; //�e�L�X�g�\�����n�߂邩

    public bool isAnimationFinished = false; // �A�j���[�V�����I���t���O
    public Animator animator; // Animator�R���|�[�l���g
    public AnimationMove animationController5;

    void Start()
    {
        isAnimationFinished = false; // ������Ԃ̓A�j���[�V����������
    }

    void Update()
    {
        // �A�j���[�V�������I������܂ŃN���b�N�s��
        if (!isAnimationFinished)
        {
            return; // �A�j���[�V�������I���܂ŏ������~
        }

        if (textStop == false) //�e�L�X�g��\��������if��
        {
            displayTextSpeed++;
            if (displayTextSpeed % 20 == 0)//20��Ɉ��v���O���������s����if��
            {

                if (textCharNumber != texts[textNumber].Length)//����text[textNumber]�̕�����̕������Ō�̕�������Ȃ����
                {
                    displayText = displayText + texts[textNumber][textCharNumber];//displayText�ɕ�����ǉ����Ă���
                    textCharNumber = textCharNumber + 1;//���̕����ɂ���
                }
                else//����text[textNumber]�̕�����̕������Ō�̕�����������
                {
                    if (textNumber != texts.Length - 1)//����texts[]���Ō�̃Z���t����Ȃ��Ƃ���
                    {
                        if (click == true)//�N���b�N���ꂽ����
                        {
                            displayText = "";//�\�������镶���������
                            textCharNumber = 0;//�����̔ԍ����ŏ��ɂ���
                            textNumber = textNumber + 1;//���̃Z���t�ɂ���
                        }
                    }
                    else //����texts[]���Ō�̃Z���t�ɂȂ�����
                    {
                        if (click == true) //�N���b�N���ꂽ����
                        {
                            SceneManager.LoadScene("���[���b�g");
                            displayText = ""; //�\�������镶���������
                            textCharNumber = 0; //�����̔ԍ����ŏ��ɂ���
                            textStop = true; //�Z���t�\�����~�߂�
                        }
                    }
                }

                this.GetComponent<Text>().text = displayText;//��ʏ��displayText��\��
                click = false;//�N���b�N���ꂽ���������
            }
            if (Input.GetMouseButton(0))//�}�E�X���N���b�N������
            {
                click = true; //�N���b�N���ꂽ����ɂ���
            }
        }
    }

    // �A�j���[�V�����I�����ɌĂяo�����֐�
    public void OnAnimationEnd()
    {
        isAnimationFinished = true; // �A�j���[�V�����I����ʒm
    }
}