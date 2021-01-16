using UnityEngine;

public class ChunkController : MonoBehaviour
{
	[SerializeField] ChunkModel chunkModel;

	void Start()
	{
		chunkModel = GetComponent<ChunkModel>();
		chunkModel.playerModel = GameObject.Find("Player/Model").GetComponent<PlayerModel>();
		chunkModel.terrain = transform.GetChild(0).gameObject;
		chunkModel.terrainMeshRenderer = chunkModel.terrain.GetComponent<MeshRenderer>();
	}

	void OnEnable()
	{
		UpdateManagerModel.updateManagerControllerInstance.RegisterChunkController(this);
	}

	void OnDisable()
	{
		UpdateManagerModel.updateManagerControllerInstance.UnregisterChunkController(this);
	}

	public void ManagedUpdate()
	{
		try
		{
			float distance = GetDistanceBetweenChunkAndPlayer();

			if (distance > 250f)
			{
				chunkModel.terrain.SetActive(false);
			}

			else
			{
				chunkModel.terrain.SetActive(true);
			}
		}

		catch { }
	}

	float GetDistanceBetweenChunkAndPlayer()
	{
		float x1 = transform.position.x;
		float z1 = transform.position.z;
		float x2 = chunkModel.playerModel.player.transform.position.x;
		float z2 = chunkModel.playerModel.player.transform.position.z;

		return Mathf.Sqrt(((x2 - x1) * (x2 - x1)) + ((z2 - z1) * (z2 - z1)));
	}
}
