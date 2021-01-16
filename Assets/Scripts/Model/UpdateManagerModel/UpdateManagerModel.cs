using System.Collections.Generic;
using UnityEngine;

public class UpdateManagerModel : MonoBehaviour
{
	public static UpdateManagerController updateManagerControllerInstance;

	public List<ChunkController> chunkControllers = new List<ChunkController>();

	public TerrainGeneratorController terrainGeneratorController;
}
