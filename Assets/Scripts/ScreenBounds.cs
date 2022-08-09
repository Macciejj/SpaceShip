using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenBounds
{
    public static Vector3 MinScreenBounds { get; private set; }
    public static Vector3 MaxScreenBounds { get; private set; }
    static ScreenBounds()
    {
        Camera camera;
        camera = Camera.main;
        float cameraToPlayerDistance = Vector3.Distance(new Vector3(0, /*moveAreaBounds*/3, 0), camera.transform.position);

        MinScreenBounds = camera.ScreenToWorldPoint(new Vector3(0, 0, cameraToPlayerDistance));
        MaxScreenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraToPlayerDistance));
    }
}
