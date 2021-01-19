using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private PlayerModel playerModel;

    public bool IsNotMoving()
    {
        if (playerModel.playerView.position == playerModel.lastPosition) return true;

        playerModel.lastPosition = playerModel.playerView.position;

        return false;
    }

    public void Move()
	{
        float vertical = Input.GetAxis("Vertical");

        if (vertical <= 0f) return;

        Vector3 move = playerModel.playerView.TransformDirection(Vector3.forward);

        move *= playerModel.moveSpeed * Time.deltaTime;

        playerModel.characterController.Move(move);
    }

	public void Rotation()
	{
        Plane playerPlane = new Plane(Vector3.up, playerModel.playerView.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 target = ray.GetPoint(hitDist);

            if (Vector3.Distance(target, playerModel.playerView.transform.position) < 2f) return;

            Quaternion targetRotation = Quaternion.LookRotation(target - playerModel.playerView.transform.position);

            playerModel.playerView.transform.rotation =
                Quaternion.Slerp(playerModel.playerView.transform.rotation, targetRotation, playerModel.mouseLookSpeed);
        }
    }
}
