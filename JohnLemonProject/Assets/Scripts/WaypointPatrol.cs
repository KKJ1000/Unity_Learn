using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;   //���� ��������Ʈ �ε��� ������ ����

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //����޽ÿ�����Ʈ ���� ������ ����
    }

    void Update()
    {
        //���� �޽� ������Ʈ�� �������� �����ߴ��� Ȯ��
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //���� �ε����� 1�� ���ϰ� ���� �ε����� �����Ͽ� ��������Ʈ �迭�� ��� ������ ��ġ�ϰ� �Ǹ� 0���� ����
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
