using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using 지시문

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement; //클래스 내 어디에서나 사용할 수 있는 변수
    Quaternion m_Rotation = Quaternion.identity;

    // Start는 첫 프레임 업데이트 이전에 호출됩니다.
    void Start()
    {
        m_Animator = GetComponent<Animator>();    
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update는 프레임마다 한 번씩 호출됩니다.
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize(); //벡터의 정규화

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);  // !(horizontal이 0과 가까워지면 true)
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;    //수평축을 입력 중이거나, 수직축을 입력중이라면 true 반환

        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);  //파라미터 방향으로 바라보는 회전을 생성
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
