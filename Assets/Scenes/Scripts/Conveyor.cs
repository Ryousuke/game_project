using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor: MonoBehaviour
{
    //�x���g�R���x�A�̉ғ���
    public bool IsOn = false;
    //�x���g�R���x�A�̐ݒ葬�x
    public float ConveyorSetSpeed = 3.0f;
    //���݂̃x���g�R���x�A�̑��x
    public float CurrentSpeed { get { return _currentSpeed;} }
    // �x���g�R���x�A�����̂𓮂�������
    public Vector3 ConveyorDirection = Vector3.forward;
    // �R���x�A�����̂������́i�����́j
    [SerializeField] private float _forcePower = 50f;
    private float _currentSpeed = 0;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    // Start is called before the first frame update
    void Start()
    {
        //�����͐��K�����Ă���
        ConveyorDirection = ConveyorDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpeed = IsOn ? ConveyorSetSpeed : 0;
        //���ł����I�u�W�F�N�g�͏�������
        _rigidbodies.RemoveAll(r => r == null);
        foreach (var r in _rigidbodies)
        {
            //���̂̈ړ����x�̃x���g�R���x�A�����̐������������o��
            var objectSpeed = Vector3.Dot(r.velocity, ConveyorDirection);

            //�ڕW�l�ȉ��Ȃ��������
            if (objectSpeed < Mathf.Abs(ConveyorSetSpeed))
            {
                r.AddForce(ConveyorDirection * _forcePower, ForceMode.Acceleration);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidBody != null && !_rigidbodies.Contains(rigidBody))
        {
            _rigidbodies.Add(rigidBody);
            // ��]���Œ肷��
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidBody != null && _rigidbodies.Contains(rigidBody))
        {
            _rigidbodies.Remove(rigidBody);
            // ��]�̌Œ����������
            rigidBody.constraints = RigidbodyConstraints.None;
        }
    }
}
