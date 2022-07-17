using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweePoints : MonoBehaviour
{
    private Transform startMarker, endMarker;
    public Transform[] waypoints;
    [SerializeField] float speed = 5;
    float journeyLength;
    float startTime;

    int currentStartPoint;
    void Start()
    {
        currentStartPoint = 0;
        SetPoints();
    }
    void SetPoints()
    {
        startMarker = waypoints[currentStartPoint];
        if(currentStartPoint + 1 < waypoints.Length) endMarker = waypoints[currentStartPoint + 1];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
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

    private void OnDrawGizmos()
    {
        foreach (var item in waypoints)
        {
            Gizmos.DrawSphere(item.position, 1);
        }
        
    }
}
