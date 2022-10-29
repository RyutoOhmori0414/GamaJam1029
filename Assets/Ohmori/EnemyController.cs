using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度"), SerializeField]
    float _moveSpeed = 10f;
    [Tooltip("プレイヤを探知する距離"), SerializeField]
    float _findDistance = 5f;
    Rigidbody2D _rb;
    Vector3 _playerForward;
    PlayerController _controller;
    [SerializeField]
    GameObject _effect;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _controller = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (_controller)
        {
            if (!_controller.IsHiding && Vector3.Distance(_controller.transform.position, transform.position) < 5f)
            {
                _rb.velocity = new Vector3(_controller.transform.position.x - this.transform.position.x, 0, 0).normalized * _moveSpeed;
            }
            else
            {
                _rb.velocity = Vector3.left * (_moveSpeed / 2);
            }
        }
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(_effect);
        go.transform.position = this.transform.position;
        Destroy(go, 5f);
    }
}
