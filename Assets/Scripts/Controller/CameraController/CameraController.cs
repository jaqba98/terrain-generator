using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CameraModel cameraModel;
    
    public void Follow()
    {
        Vector3 desiredPosition =
            cameraModel.target.position +
            cameraModel.offset;

        Vector3 smoothedPosition =
            Vector3.Lerp(
                cameraModel.cameraView.position,
                desiredPosition,
                cameraModel.smooth
            );

        cameraModel.cameraView.position = smoothedPosition;
    }
}
