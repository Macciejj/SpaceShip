using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    private float scrollSpeed = 10f;

    private float topEdge;
    private float botEdge;

    private Vector3 distanceBetweenEnges;

    private void Start()
    {
        CalculateEdges();
        distanceBetweenEnges = new Vector3(0f, 0f, topEdge - botEdge);
    }

    private void Update()
    {
        transform.localPosition += scrollSpeed * Vector3.back * Time.deltaTime;
        if (PassedEdge())
        {
            moveRightSpriteToTheOppositeEdge();
        }

    }
    private void CalculateEdges()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        topEdge = transform.position.z + spriteRenderer.bounds.extents.z;
        botEdge = transform.position.z - spriteRenderer.bounds.extents.z;
    }

    private void moveRightSpriteToTheOppositeEdge()
    {
        if(scrollSpeed>0)
        {
            transform.position += distanceBetweenEnges;
        }
    }

    private bool PassedEdge()
    {
        return scrollSpeed > 0 && transform.position.z + distanceBetweenEnges.z/2 < botEdge;
    }
}
