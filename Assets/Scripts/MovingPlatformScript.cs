using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Leland LeVassar
 * Purpose: To control the logic for moving between waypoints as well as the timing and direction
 * Created: 4/28/24
 */

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    private void Start()
    {
        
    }
}
