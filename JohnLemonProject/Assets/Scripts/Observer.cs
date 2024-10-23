using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어를 감지하는 스크립트
public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool IsPlayerInRange;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            IsPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
