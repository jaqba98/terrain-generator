using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 lastPosition;

    public bool IsNotMoving()
    {
        if (transform.position == lastPosition) return true; 
        lastPosition = transform.position;
        return false;
    }

    public Vector3Int GetVector3IntPosition(int size)
    {
        return new Vector3Int(
            (int) transform.position.x / size * size,
            (int) transform.position.y / size * size,
            (int) transform.position.z / size * size
        );
    }
}
