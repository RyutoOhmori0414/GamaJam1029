using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�̈ړ����x")]
    float _moveSpeed = 10f;
    [SerializeField, Tooltip("�v���C���[�̃W�����v�̃p���[")]
    float _jumpSpeed = 10f;

    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // �W�����v�̏���
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector2.up *_jumpSpeed, ForceMode2D.Impulse);
        }
        // �ړ��̏���
        float h = Input.GetAxisRaw("Horizontal");

        _rb.velocity = Vector3.right * h + Vector3.up * _rb.velocity.y;
    }
}
