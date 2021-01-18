using System.Collections.Generic;
using UnityEngine;

public class UpdateManagerModel : MonoBehaviour
{
	public TerrainGeneratorController terrainGeneratorController;

	[HideInInspector]
	public List<ChunkController> chunkControllers = new List<ChunkController>();

	public PlayerController playerController;
}
