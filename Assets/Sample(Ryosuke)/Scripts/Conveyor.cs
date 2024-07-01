using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor: MonoBehaviour
{
    //ベルトコンベアの稼働状況
    public bool IsOn = false;
    //ベルトコンベアの設定速度
    public float ConveyorSetSpeed = 3.0f;
    //現在のベルトコンベアの速度
    public float CurrentSpeed { get { return _currentSpeed;} }
    // ベルトコンベアが物体を動かす方向
    public Vector3 ConveyorDirection = Vector3.forward;
    // コンベアが物体を押す力（加速力）
    [SerializeField] private float _forcePower = 50f;
    private float _currentSpeed = 0;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    // Start is called before the first frame update
    void Start()
    {
        //方向は正規化しておく
        ConveyorDirection = ConveyorDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpeed = IsOn ? ConveyorSetSpeed : 0;
        //消滅したオブジェクトは除去する
        _rigidbodies.RemoveAll(r => r == null);
        foreach (var r in _rigidbodies)
        {
            //物体の移動速度のベルトコンベア方向の成分だけを取り出す
            var objectSpeed = Vector3.Dot(r.velocity, ConveyorDirection);

            //目標値以下なら加速する
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
            // 回転を固定する
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidBody != null && _rigidbodies.Contains(rigidBody))
        {
            _rigidbodies.Remove(rigidBody);
            // 回転の固定を解除する
            rigidBody.constraints = RigidbodyConstraints.None;
        }
    }
}
