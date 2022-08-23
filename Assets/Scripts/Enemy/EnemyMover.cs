using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform startMarker, endMarker;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] float speed = 5;

    private float journeyLength;
    private float startTime;
    private int currentStartPoint;

    private void Start()
    {
        currentStartPoint = 0;
        SetPoints();
    }

    private void OnDrawGizmos()
    {
        foreach (var item in waypoints)
        {
            Gizmos.DrawSphere(item.position, 1);
        }

    }

    public void Move()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        if (fracJourney >= 1f && currentStartPoint + 1 < waypoints.Length)
        {
            currentStartPoint++;
            SetPoints();
        }
    }

    private void SetPoints()
    {
        startMarker = waypoints[currentStartPoint];
        if (currentStartPoint + 1 < waypoints.Length) endMarker = waypoints[currentStartPoint + 1];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    
}
