using UnityEngine;

public class TerrainGeneratorController : MonoBehaviour
{
	[SerializeField] TerrainGeneratorModel terrainGeneratorModel;

	void Start() => GenerateTerrain();

	public void GenerateTerrain(bool checkPlayerIsMoving = false)
	{
		if (CheckWhetherGenerate(checkPlayerIsMoving)) return;
		terrainGeneratorModel.chunkGeneratorController.GenerateChunk();
	}

	bool CheckWhetherGenerate(bool checkPlayerIsMoving) =>
		terrainGeneratorModel.playerController.IsNotMoving() && checkPlayerIsMoving;
}
