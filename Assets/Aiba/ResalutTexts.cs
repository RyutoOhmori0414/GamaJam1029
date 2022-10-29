using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ResalutTexts : MonoBehaviour
{
    [Header("CLEARテクストUI")]
    [SerializeField] Text _clearTimeText;
    [SerializeField] Text _clearEnemyText1;

    [Header("GameOverのテクストUI")]
    [SerializeField] Text _gameOverTimeText2;
    [SerializeField] Text _gameOverEnemyText2;

    GameManager _gm;
    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (FindObjectOfType<GameManager>()._clerPanel.activeSelf)
        {
            _clearTimeText.text = _gm._countTime.ToString();
            _clearEnemyText1.text = _gm._enemy.ToString()+"体";
        }
        if (FindObjectOfType<GameManager>()._gameOerPanel.activeSelf)
        {
            _gameOverTimeText2.text = _gm._countTime.ToString();
            _gameOverEnemyText2.text = _gm._enemy.ToString() + "体";
        }





    }

}
