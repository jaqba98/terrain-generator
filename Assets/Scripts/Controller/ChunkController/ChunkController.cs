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
		if(Vector3.Distance(transform.position, chunkModel.playerModel.player.position) > 1200f)
		{
			chunkModel.terrain.SetActive(false);
			return;
		}

		chunkModel.terrain.SetActive(true);
	}
}
