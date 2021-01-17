using UnityEngine;

public class TerrainGeneratorController : MonoBehaviour
{
	public TerrainGeneratorModel terrainGeneratorModel;

	public void GenerateTerrain(bool checkPlayerIsMoving = false)
	{
		if (CheckWhetherGenerate(checkPlayerIsMoving))
		{
			return;
		}

		terrainGeneratorModel.chunkGeneratorController.GenerateChunk();
	}

	bool CheckWhetherGenerate(bool checkPlayerIsMoving)
	{
		return terrainGeneratorModel.playerController.IsNotMoving() && checkPlayerIsMoving;
	}
}
