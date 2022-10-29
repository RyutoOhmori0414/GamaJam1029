using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("���Ԑ����̃e�N�X�gUI")]
    [SerializeField] Text _timeText;

    [Header("�X�^�[�g�J�E���g�p�̃e�N�X�gUI")]
    [SerializeField] Text _StartCountText;

    [SerializeField] GameObject _clerPanel;
    [SerializeField] GameObject _gameOerPanel;

    [Header("��������")]
    [SerializeField] float _timeLimit = 60;
    private float _countTime = 0;

    [SerializeField] int _playerHp = 3;


    private bool _isGame = false;

    public bool IsGame { get => _isGame; set => _isGame = value; }
    void Start()
    {
        FindObjectOfType<PlayerCounter>().DeathPlayer(_playerHp);
       StartCoroutine(StartCount());
        _countTime = _timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        TimeTextChange();

        if(_playerHp<=0)
        {
            GameOver();
            _isGame = false;
        }
    }

    /// <summary>�Q�[���I�[�o�[���ɌĂ�</summary>
    public void GameOver()
    {
        _gameOerPanel.SetActive(true);
    }

    /// <summary>�N���A���ɌĂ�</summary>
    public void GameClear()
    {
        _clerPanel.SetActive(true);
    }

  public  void DeathPlayer()
    {
        _playerHp--;
        FindObjectOfType<PlayerCounter>().DeathPlayer(_playerHp);
    }


    void TimeTextChange()
    {
        if (_isGame)
        {
            _countTime -= Time.deltaTime;
            _timeText.text = _countTime.ToString("00");
        }
    }

    IEnumerator StartCount()
    {
        _StartCountText.text = "3";
        yield return new WaitForSeconds(1);
        _StartCountText.text = "2";
        yield return new WaitForSeconds(1);
        _StartCountText.text = "1";
        yield return new WaitForSeconds(1);
        _StartCountText.text = "Start";
        _isGame = true;
        yield return new WaitForSeconds(1);
        _StartCountText.text = " ";
    }


}
