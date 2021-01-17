using UnityEngine;

public class TerrainGeneratorController : MonoBehaviour
{
	[SerializeField]
	private TerrainGeneratorModel terrainGeneratorModel;

	public void GenerateTerrain(bool checkPlayerIsMoving = false)
	{
		if (CheckWhetherGenerate(checkPlayerIsMoving)) return;

		terrainGeneratorModel.chunkGeneratorController.GenerateChunk();
	}

	private bool CheckWhetherGenerate(bool checkPlayerIsMoving)
	{
		return terrainGeneratorModel.playerController.IsNotMoving() && checkPlayerIsMoving;
	}
}
