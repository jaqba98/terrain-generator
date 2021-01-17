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
}
