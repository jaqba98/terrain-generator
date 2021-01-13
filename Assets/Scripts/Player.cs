using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    public bool IsNotMoving()
    {
        if (transform.position == lastPosition) return true; 
        lastPosition = transform.position;
        return false;
    }
}
