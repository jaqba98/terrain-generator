using UnityEngine;

public class UpdateManagerController : MonoBehaviour
{
	[SerializeField]
	private UpdateManagerModel updateManagerModel;

	private void Update() => UpdateManager();

	private void UpdateManager()
	{
		updateManagerModel.terrainGeneratorController.GenerateTerrain(true);
		updateManagerModel.chunkControllers.ForEach(chunk => chunk.ManagedUpdate());
	}
}
