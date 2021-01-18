using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private PlayerModel playerModel;

	public void Move()
	{
        playerModel.vertical = Input.GetAxis("Vertical");

        if (playerModel.vertical == 0f) return;

        Vector3 move = playerModel.vertical > 0 ?
            playerModel.playerView.TransformDirection(Vector3.forward) :
            playerModel.playerView.TransformDirection(Vector3.back);

        move *= playerModel.moveSpeed * Time.deltaTime;

        playerModel.characterController.Move(move);
    }

	public void Rotation()
	{
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 target = ray.GetPoint(hitDist);

            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

            playerModel.playerView.transform.rotation =
                Quaternion.Slerp(playerModel.playerView.transform.rotation, targetRotation, playerModel.mouseLookSpeed);
        }
    }

	public bool IsNotMoving()
	{
		if (playerModel.playerView.position == playerModel.lastPosition) return true;

		playerModel.lastPosition = playerModel.playerView.position;

		return false;
	}
}
