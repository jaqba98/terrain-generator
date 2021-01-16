using UnityEngine;

public class UpdateManagerController : MonoBehaviour
{
	[SerializeField] UpdateManagerModel updateManagerModel;

	void Start()
	{
		UpdateManagerModel.updateManagerControllerInstance = this;
	}

	void Update()
	{
		updateManagerModel.terrainGeneratorController.GenerateTerrain(true);

		foreach(ChunkController chunkController in updateManagerModel.chunkControllers)
		{
			chunkController.ManagedUpdate();
		}
	}

	public void RegisterChunkController(ChunkController chunkController)
	{
		updateManagerModel.chunkControllers.Add(chunkController);
	}

	public void UnregisterChunkController(ChunkController chunkController)
	{
		updateManagerModel.chunkControllers.Remove(chunkController);
	}
}
