using UnityEngine;

public class ChunkController : MonoBehaviour
{
	[SerializeField] ChunkModel chunkModel;

	void Start()
	{
		chunkModel = GetComponent<ChunkModel>();
		chunkModel.playerModel = FindObjectOfType<PlayerModel>();
		chunkModel.terrain = gameObject.transform.GetChild(0).gameObject;
	}

	void Update()
	{
		if (!chunkModel.playerModel.playerController.IsNotMoving()) return;
		
		if (Vector3.Distance(transform.position, chunkModel.playerModel.player.position) > 400f)
		{
			Destroy(gameObject);
		}
	}
}
