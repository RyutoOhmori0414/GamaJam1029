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
    /// <summary>�v���C���[���B��Ă��邩�ǂ����ňړ��𐧌�</summary>
    bool _isHiding = false;
    /// <summary>�v���C���[���B��Ă��邩�ǂ���</summary>
    public bool IsHiding { get { return _isHiding; } }
    /// <summary>���݉B�����̂��ǂ���</summary>
    bool _isHidable = false;
    GameObject _killTarget;

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
        // �B��Ă��Ȃ��Ƃ��͈ړ��ł���
        if (!_isHiding)
        {
            // �W�����v�̏���
            if (Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
            // �ړ��̏���
            float h = Input.GetAxisRaw("Horizontal");

            _rb.velocity = Vector3.right * h * _moveSpeed + Vector3.up * _rb.velocity.y;

            if (Input.GetButtonDown("Hide") && _isHidable)
            {
                _isHiding = true;
                // �B�ꂽ�u�Ԃɍs���鏈��������
                _sr.color = Color.clear; // ���ɓ����ɂ���A�������������`
            }

            if (Input.GetButtonDown("Fire1") && _killTarget)
            {
                Destroy(_killTarget);
            }
        }
        //����鏈��
        else if (Input.GetButtonDown("Hide"))
        {
            _isHiding = false;
            _sr.color = Color.yellow;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // �B��鏈��
        if (collision.gameObject.CompareTag("HideObject"))
        {
            _isHidable = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _killTarget = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HideObject"))
        {
            _isHidable = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _killTarget = null;
        }
    }
}
