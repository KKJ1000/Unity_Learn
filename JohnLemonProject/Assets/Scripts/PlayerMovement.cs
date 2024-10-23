using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ���ù�

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement; //Ŭ���� �� ��𿡼��� ����� �� �ִ� ����
    Quaternion m_Rotation = Quaternion.identity;

    // Start�� ù ������ ������Ʈ ������ ȣ��˴ϴ�.
    void Start()
    {
        m_Animator = GetComponent<Animator>();    
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update�� �����Ӹ��� �� ���� ȣ��˴ϴ�.
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize(); //������ ����ȭ

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);  // !(horizontal�� 0�� ��������� true)
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;    //�������� �Է� ���̰ų�, �������� �Է����̶�� true ��ȯ

        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);  //�Ķ���� �������� �ٶ󺸴� ȸ���� ����
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
