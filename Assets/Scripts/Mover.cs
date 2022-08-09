using UnityEngine;
public class Mover
{
    private Transform transform;
   
    private float speed;

    private Vector3 minScreenBounds;
    private Vector3 maxScreenBounds;

    private Vector3 moveVector;
    private Vector3 nextPosition;

    public Mover(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
        minScreenBounds = ScreenBounds.MinScreenBounds;
        maxScreenBounds = ScreenBounds.MaxScreenBounds;
        
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

    public Vector3 GetScreenMaxBounds()
    {
        return maxScreenBounds;
    }
    public Vector3 GetScreenMinBounds()
    {
        return minScreenBounds;
    }
}
