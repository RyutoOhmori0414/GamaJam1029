using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ResalutTexts : MonoBehaviour
{
    [Header("���Ԑ����̃e�N�X�gUI")]
    [SerializeField] Text _timeText;
    [SerializeField] Text _timeText2;

    [Header("�X�^�[�g�J�E���g�p�̃e�N�X�gUI")]
    [SerializeField] Text _enemyText;
    [SerializeField] Text _enemyText2;

    void Update()
    {
        _timeText.text = GameManager._countTime.ToString("00.0");
        _enemyText.text = "${ GameManager._enemy.ToString()}��";

        _timeText2.text = GameManager._countTime.ToString("00.0");
        _enemyText2.text = "${ GameManager._enemy.ToString()}��";


    }

}
