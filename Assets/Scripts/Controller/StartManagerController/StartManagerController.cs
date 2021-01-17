using UnityEngine;

public class StartManagerController : MonoBehaviour
{
	[SerializeField]
	private StartManagerModel startManagerModel;

	private void Start() => StartManager();

	private void StartManager()
	{
		startManagerModel.terrainGeneratorController.GenerateTerrain();
	}
}
