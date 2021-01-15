using UnityEngine;

public class ChunkGeneratorController : MonoBehaviour
{
	[SerializeField] ChunkGeneratorModel chunkGeneratorModel;

	public void GenerateChunk()
	{
		Vector3Int chunkPosition = GetChunkPosition();

		foreach (Vector3Int position in GetPositionsToGenerate(chunkPosition))
		{
			string name = position.ToString();
			if (GameObject.Find(name)) continue;
			CreateChunk(position, name);
		}
	}

	Vector3Int GetChunkPosition()
	{
		return Vector3Int.FloorToInt(chunkGeneratorModel.playerModel.player.position) /
      chunkGeneratorModel.size *
      chunkGeneratorModel.size;
	}

	Vector3Int[] GetPositionsToGenerate(Vector3Int position)
	{
		int size = chunkGeneratorModel.size;

		return new Vector3Int[]
  	{
      position,
      position + (Vector3Int.forward * size) + (Vector3Int.left * size),
      position + (Vector3Int.forward * size),
      position + (Vector3Int.forward * size) + (Vector3Int.right * size),
      position + (Vector3Int.left * size),
      position + (Vector3Int.right * size),
      position + (Vector3Int.back * size) + (Vector3Int.left * size),
      position + (Vector3Int.back * size),
      position + (Vector3Int.back * size) + (Vector3Int.right * size)
    };
  }

  void CreateChunk(Vector3Int position, string name)
  {
    GameObject chunk = new GameObject(name);
    chunk.transform.position = position;
    chunk.transform.parent = chunkGeneratorModel.parentOfChunks;
		chunk.AddComponent<ChunkController>();
		chunk.AddComponent<ChunkModel>();
		CreateTerrain(position, chunk);
  }

	void CreateTerrain(Vector3Int position, GameObject chunk)
	{
		GameObject terrain = Instantiate(chunkGeneratorModel.chunk, position, Quaternion.identity);
		terrain.transform.parent = chunk.transform;
	}
}
