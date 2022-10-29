using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  int _enemy = 0;

    [Header("時間制限のテクストUI")]
    [SerializeField] Text _timeText;

    [Header("スタートカウント用のテクストUI")]
    [SerializeField] Text _StartCountText;

    [SerializeField] public GameObject _clerPanel;
    [SerializeField] public GameObject _gameOerPanel;

    [Header("制限時間")]
    [SerializeField] float _timeLimit = 60;
    public  float _countTime = 0;

    [SerializeField] int _playerHp = 3;


    private bool _isGame = false;

    public bool IsGame { get => _isGame; set => _isGame = value; }
    void Start()
    {
        _enemy = 0;
        FindObjectOfType<PlayerCounter>().DeathPlayer(_playerHp);
        StartCoroutine(StartCount());
        _countTime = _timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        TimeTextChange();

        // Debug.Log(_enemy);


        if (_countTime <= 0)
        {
            GameOver();
            _isGame = false;
        }

        if (_playerHp <= 0)
        {
            GameOver();
            _isGame = false;
        }
    }

    /// <summary>ゲームオーバー時に呼ぶ</summary>
    public void GameOver()
    {
        _gameOerPanel.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));

    }

    /// <summary>クリア時に呼ぶ</summary>
    public void GameClear()
    {   
        _isGame = false;
        _clerPanel.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void DeathPlayer()
    {
        _playerHp--;
        FindObjectOfType<PlayerCounter>().DeathPlayer(_playerHp);
    }

    public void KillEnemy()
    {
        _enemy++;
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
