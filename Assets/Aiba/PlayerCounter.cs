using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    /// <summary>残機として表示するスプライト</summary>
    [SerializeField] Sprite m_playerUiSprite = null;
    /// <summary>残機として表示するスプライトのサイズ</summary>
    [SerializeField] Vector2 m_spriteSize = new Vector2(50f, 50f);
    /// <summary>残機表示をするパネル</summary>
    [SerializeField] RectTransform m_playerCounterPanel = null;
    void Start()
    {
        
    }


    /// <summary>Hpを減らして慙残機をへらす</summary>
    public void DeathPlayer(int _playerHp)
    {

        // 子オブジェクトをすべて削除する
        foreach (Transform t in m_playerCounterPanel.transform)
        {
            Destroy(t.gameObject);
        }

        // 残機数だけスプライトをパネルの子オブジェクトとして生成する
        for (int i = 0; i < _playerHp; i++)
        {
            // Image を作る
            GameObject go = new GameObject();
            Image image = go.AddComponent<Image>();
            // Sprite をアサインする
            image.sprite = m_playerUiSprite;
            // サイズを変える
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.sizeDelta = m_spriteSize;
            // パネルの子オブジェクトにする
            go.transform.SetParent(m_playerCounterPanel.transform);
        }

    }
}
