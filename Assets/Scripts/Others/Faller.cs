using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    [SerializeField] float fallingSpeed = 10f;

    void Update()
    {
        transform.Translate(0,0, -1 * fallingSpeed * Time.deltaTime);
    }
}
