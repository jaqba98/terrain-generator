using UnityEngine;

public class UpdateManagerController : MonoBehaviour
{
	[SerializeField] UpdateManagerModel updateManagerModel;

	void Start() => UpdateManagerModel.updateManagerControllerInstance = this;

	void Update()
	{
		UpdateTerrainGeneratorController();
		UpdateChunkController();
	}

	void UpdateTerrainGeneratorController()
	{
		updateManagerModel.terrainGeneratorController.GenerateTerrain(true);
	}

	public void RegisterChunkController(ChunkController chunkController)
	{
		updateManagerModel.chunkControllers.Add(chunkController);
	}

	public void UnregisterChunkController(ChunkController chunkController)
	{
		updateManagerModel.chunkControllers.Remove(chunkController);
	}

	void UpdateChunkController() =>
		updateManagerModel.chunkControllers.ForEach(chunk => chunk.ManagedUpdate());
}
