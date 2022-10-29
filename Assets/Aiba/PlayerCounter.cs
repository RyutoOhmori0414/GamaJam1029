using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    /// <summary>�c�@�Ƃ��ĕ\������X�v���C�g</summary>
    [SerializeField] Sprite m_playerUiSprite = null;
    /// <summary>�c�@�Ƃ��ĕ\������X�v���C�g�̃T�C�Y</summary>
    [SerializeField] Vector2 m_spriteSize = new Vector2(50f, 50f);
    /// <summary>�c�@�\��������p�l��</summary>
    [SerializeField] RectTransform m_playerCounterPanel = null;
    void Start()
    {
        
    }


    /// <summary>Hp�����炵�Ĝ͎c�@���ւ炷</summary>
    public void DeathPlayer(int _playerHp)
    {

        // �q�I�u�W�F�N�g�����ׂč폜����
        foreach (Transform t in m_playerCounterPanel.transform)
        {
            Destroy(t.gameObject);
        }

        // �c�@�������X�v���C�g���p�l���̎q�I�u�W�F�N�g�Ƃ��Đ�������
        for (int i = 0; i < _playerHp; i++)
        {
            // Image �����
            GameObject go = new GameObject();
            Image image = go.AddComponent<Image>();
            // Sprite ���A�T�C������
            image.sprite = m_playerUiSprite;
            // �T�C�Y��ς���
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.sizeDelta = m_spriteSize;
            // �p�l���̎q�I�u�W�F�N�g�ɂ���
            go.transform.SetParent(m_playerCounterPanel.transform);
        }

    }
}
