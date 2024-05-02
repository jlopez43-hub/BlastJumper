using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Leland LeVassar, help from PitilT tutorial
 * Purpose: To control the logic for moving between waypoints and checking when to change direction
 * Created: 4/28/24
 */

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] 
    private Transform[] _waypoints;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _checkDistance = 0.05f;

    private Transform _targetWaypoint;
    private int _currentWaypointIndex = 0;

    private void Start()
    {
        _targetWaypoint = _waypoints[0];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetWaypoint.position) < _checkDistance)
        {
            _targetWaypoint = GetNextWaypoint(); 
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++;
        if(_currentWaypointIndex >= _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        return _waypoints[_currentWaypointIndex];
    }
}
