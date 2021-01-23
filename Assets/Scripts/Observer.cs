using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameEnding gameEnding;
    bool _isPlayerInRange = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = false;
        }
    }

    Ray ray = new Ray();
    private void Update()
    {
        if(_isPlayerInRange == true)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;

            ray = new Ray(transform.position, direction);

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

    private void OnDrawGizmos()
    {
        if (_isPlayerInRange == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray);
        }
    }
}
