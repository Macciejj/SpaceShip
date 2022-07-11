using UnityEngine;
public class Mover
{
    private Transform transform;
   
    private float speed;

    private Camera camera;
    private float cameraToPlayerDistance;

    private Vector3 minScreenBounds;
    private Vector3 maxScreenBounds;

    private Vector3 moveVector;
    private Vector3 nextPosition;
   
    public Mover(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;

        camera = Camera.main;
        cameraToPlayerDistance = Vector3.Distance(Vector3.zero, camera.transform.position);
        minScreenBounds = camera.ScreenToWorldPoint(new Vector3(0, 0, cameraToPlayerDistance));
        maxScreenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraToPlayerDistance));
    }

    public void Move(Vector2 direction)
    {
        moveVector = new Vector3(direction.x * speed * Time.deltaTime, 0, direction.y * speed * Time.deltaTime);
        nextPosition = transform.position + moveVector;
        if (nextPosition.x < minScreenBounds.x || nextPosition.x > maxScreenBounds.x)
        {
            moveVector.x = 0;
        }
        if (nextPosition.z < minScreenBounds.z || nextPosition.z > maxScreenBounds.z)
        {
            moveVector.z = 0;
        }
        transform.Translate(moveVector);
    }
}
