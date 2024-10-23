using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;   //현재 웨이포인트 인덱스 저장할 변수

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //내브메시에이전트 최초 목적지 설정
    }

    void Update()
    {
        //내비 메시 에이전트가 목적지에 도착했는지 확인
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //현재 인덱스에 1을 더하고 만약 인덱스가 증가하여 웨이포인트 배열의 요소 개수와 일치하게 되면 0으로 설정
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
