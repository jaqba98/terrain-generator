using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private PlayerModel playerModel;

	public void Move()
	{
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        playerModel.characterController.Move(move * Time.deltaTime * 10f);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerModel.characterController.Move(playerModel.playerVelocity * Time.deltaTime);
    }	

	public bool IsNotMoving()
	{
		if (playerModel.playerView.position == playerModel.lastPosition) return true;

		playerModel.lastPosition = playerModel.playerView.position;

		return false;
	}
}
