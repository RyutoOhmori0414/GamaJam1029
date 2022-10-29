using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動速度")]
    float _moveSpeed = 10f;
    [SerializeField, Tooltip("プレイヤーのジャンプのパワー")]
    float _jumpSpeed = 10f;

    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // ジャンプの処理
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector2.up *_jumpSpeed, ForceMode2D.Impulse);
        }
        // 移動の処理
        float h = Input.GetAxisRaw("Horizontal");

        _rb.velocity = Vector3.right * h + Vector3.up * _rb.velocity.y;
    }
}
