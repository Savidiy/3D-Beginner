using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum PatrolType {PingPong, Circle, Test}


[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] GameObject path;
    Transform[] waypoints;
    [SerializeField] PatrolType patrolType;
    int _currentWaypointIndex;
    bool _isIncreaseWaypointIndex = true;

    void Start()
    {
        if (path != null)
        {
            waypoints = new Transform[path.transform.childCount];
            for (int i = 0; i < path.transform.childCount; i++)
            {
                waypoints[i] = path.transform.GetChild(i);
            }
        }
        else
        {
            waypoints = new Transform[0];
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
            navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (waypoints.Length > 0)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                switch (patrolType)
                {
                    case PatrolType.Circle: /// 01230123
                        _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
                        break;
                    case PatrolType.PingPong: /// 0123210123
                        if (waypoints.Length > 1) {
                            if (_isIncreaseWaypointIndex)
                            {
                                _currentWaypointIndex++;
                                if (_currentWaypointIndex >= waypoints.Length)
                                {
                                    _currentWaypointIndex -= 2;
                                    _isIncreaseWaypointIndex = false;
                                }
                            }
                            else
                            {
                                _currentWaypointIndex--;
                                if (_currentWaypointIndex < 0)
                                {
                                    _currentWaypointIndex += 2;
                                    _isIncreaseWaypointIndex = true;
                                }
                            }
                        }
                        break;
                    default:                        
                        Debug.LogError($"{this.GetType().Name}: Unknown Patrol Type");                        
                        break;
                }
                navMeshAgent.SetDestination(waypoints[_currentWaypointIndex].position);
            }
        }
            
    }
}
