using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezier : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointC;
    [SerializeField] Transform pointD;

    [SerializeField] Transform pointE;
    [SerializeField] Transform pointF;

    
    [SerializeField] Transform enemy;

    private float interpolateAmount = 0;

    private void Update()
    {
        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }
        interpolateAmount += Time.deltaTime;
        if (interpolateAmount <= 1)
        {
            enemy.position = CubicInterpolate(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount % 1);
        }
        else if (interpolateAmount <= 2)
        {

            enemy.position = CubicInterpolate(pointD.position, pointE.position, pointF.position, pointA.position, interpolateAmount % 1);
        }
        else interpolateAmount = 0;


    }

    private Vector3 QuadraticInterpolate(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, interpolateAmount%1);
    }

    private Vector3 CubicInterpolate(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticInterpolate(a, b, c, t);
        Vector3 bc_cd = QuadraticInterpolate(b, c, d, t);

        return Vector3.Lerp(ab_bc, bc_cd, interpolateAmount%1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointA.position, 2);
        Gizmos.DrawSphere(pointB.position, 2);
        Gizmos.DrawSphere(pointC.position, 2);
        Gizmos.DrawSphere(pointD.position, 2);
        Gizmos.DrawSphere(pointE.position, 2);
        Gizmos.DrawSphere(pointF.position, 2);
    }
}
