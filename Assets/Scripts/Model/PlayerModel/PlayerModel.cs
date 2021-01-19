using UnityEngine;

public class PlayerModel : MonoBehaviour
{
	public Transform playerView;

	[HideInInspector]
	public Vector3 lastPosition;

	public CharacterController characterController;

	public float moveSpeed;

	public float mouseLookSpeed;
}
