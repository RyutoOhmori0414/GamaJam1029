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
    /// <summary>プレイヤーが隠れているかどうかで移動を制限</summary>
    bool _isHiding = false;
    /// <summary>プレイヤーが隠れているかどうか</summary>
    public bool IsHiding { get { return _isHiding; } }
    /// <summary>現在隠れられるのかどうか</summary>
    bool _isHidable = false;

    Rigidbody2D _rb;
    SpriteRenderer _sr;
    Collider2D _collider;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // 隠れていないときは移動できる
        if (!_isHiding)
        {
            // ジャンプの処理
            if (Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
            // 移動の処理
            float h = Input.GetAxisRaw("Horizontal");

            _rb.velocity = Vector3.right * h * _moveSpeed + Vector3.up * _rb.velocity.y;

            if (Input.GetButtonDown("Hide") && _isHidable)
            {
                _isHiding = true;
                // 隠れた瞬間に行われる処理を書く
                _sr.color = Color.clear; // 仮に透明にする、半透明が完成形
            }
        }
        //現れる処理
        else if (Input.GetButtonDown("Hide"))
        {
            _isHiding = false;
            _sr.color = Color.yellow;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 隠れる処理
        if (collision.gameObject.CompareTag("HideObject"))
        {
            _isHidable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isHidable = false;
    }
}
