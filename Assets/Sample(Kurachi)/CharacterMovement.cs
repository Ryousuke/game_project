using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float moveSpeed = 10f; // �ړ����x
    public float jumpForce = 5f; // �W�����v��
    private Rigidbody rb;
    private Camera mainCamera;
    private bool isGrounded;
    private Animator animator; // �A�j���[�^�[
    Vector3 position; // ���̂̈ʒu���i�[����ϐ�

    public float rotationSpeed = 100f; // �J������]���x

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>(); // �A�j���[�^�[�̎擾
    }

    void Update()
    {
        Move();
        RotateCamera();
        position = transform.position; // ���݈ʒu�̕ۑ�
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("HorizontalWASD");
        float moveVertical = -Input.GetAxis("VerticalWASD"); // �O��̓����𔽓]

        // �J�����̑O�����ƉE�������擾
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Y�������̐������[���ɂ��āAXZ���ʂɓ��e
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // �J�����̕����Ɋ�Â��Ĉړ��x�N�g�����v�Z
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        // �A�j���[�V�����̐���
        bool walking = moveHorizontal != 0 || moveVertical != 0;
        animator.SetBool("isWalking", walking);
    }

    void RotateCamera()
    {
        float rotateHorizontal = Input.GetAxis("HorizontalArrow");
        float rotateVertical = Input.GetAxis("VerticalArrow");

        // �L�����N�^�[�����E�ɉ�]
        transform.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);

        // �J�����̐��������̉�]���L�����N�^�[�ɔ��f
        float newPitch = rotateVertical * rotationSpeed * Time.deltaTime;
        float newRotation = mainCamera.transform.eulerAngles.x - newPitch;

        // �㉺�����̉�]�p�x�𐧌�����
        if (newRotation > 180f)
        {
            newRotation -= 360f;
        }
        newRotation = Mathf.Clamp(newRotation, -30f, 30f); // �ő�30�x�܂ŉ�]�\�ɐ���

        mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, -newPitch);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;

        // �W�����v�A�j���[�V�����̐���
        animator.SetBool("isJumping", true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false); // ���n������W�����v�A�j���[�V����������
        }

        Debug.Log("object =" + collision.gameObject.name);
        if (collision.transform.root.gameObject.name == "Wall") // �u���v�ȊO�Ƃ̏Փ˂����肳�ꂽ
        {
            Vector3 boundVec = transform.position - position; // �ړ��x�N�g��
            //Debug.Log("object =" + boundVec);
            transform.position = position - boundVec; // �����߂�
        }
    }
}
