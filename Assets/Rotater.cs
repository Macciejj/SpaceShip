using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] Vector3 rotationValues;
    [SerializeField] float rotationSpeed = 10;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1 * rotationSpeed * Time.deltaTime));
    }
}
