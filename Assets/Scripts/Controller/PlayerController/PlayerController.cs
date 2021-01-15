using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] PlayerModel playerModel;

	public bool IsNotMoving()
	{
		if (playerModel.player.position == playerModel.lastPosition) return true;
		playerModel.lastPosition = playerModel.player.position;
		return false;
	}
}
