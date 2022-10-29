using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ResalutTexts : MonoBehaviour
{
    [Header("時間制限のテクストUI")]
    [SerializeField] Text _timeText;
    [SerializeField] Text _timeText2;

    [Header("スタートカウント用のテクストUI")]
    [SerializeField] Text _enemyText;
    [SerializeField] Text _enemyText2;

    void Update()
    {
        _timeText.text = GameManager._countTime.ToString("00.0");
        _enemyText.text = "${ GameManager._enemy.ToString()}体";

        _timeText2.text = GameManager._countTime.ToString("00.0");
        _enemyText2.text = "${ GameManager._enemy.ToString()}体";


    }

}
