using System.Collections.Generic;
using UnityEngine;

public class ChunkGeneratorController : MonoBehaviour
{
	[SerializeField]
	private ChunkGeneratorModel chunkGeneratorModel;

	public void GenerateChunk()
	{
		Vector3Int chunkPosition = GetChunkPosition();

		GetPositionsToGenerate(chunkPosition)
			.ForEach(position => CheckWhetherGenerate(position));
	}

	private Vector3Int GetChunkPosition()
	{
		return Vector3Int.FloorToInt(chunkGeneratorModel.playerModel.playerView.position) /
			chunkGeneratorModel.size *
			chunkGeneratorModel.size;
	}

	private List<Vector3Int> GetPositionsToGenerate(Vector3Int position)
	{
		int size = chunkGeneratorModel.size;

		return new List<Vector3Int>
		{
			position + (Vector3Int.forward * size) + (Vector3Int.left * size),
			position + (Vector3Int.forward * size),
			position + (Vector3Int.forward * size) + (Vector3Int.right * size),
			position + (Vector3Int.left * size),
			position,
			position + (Vector3Int.right * size),
			position + (Vector3Int.back * size) + (Vector3Int.left * size),
			position + (Vector3Int.back * size),
			position + (Vector3Int.back * size) + (Vector3Int.right * size)
		};
	}

	private void CheckWhetherGenerate(Vector3Int position)
	{
		string name = position.ToString();
		bool finded = chunkGeneratorModel
			.updateManagerModel
			.chunkControllers
			.Find(chunk => chunk.GetNameOfObject() == name);

		if (finded) return;

		CreateChunk(position, name);
	}

	private void CreateChunk(Vector3Int position, string name)
	{
		GameObject chunk = new GameObject(name);
		SetPositionAndParent(chunkGeneratorModel.chunksView, position, chunk.transform);

		GameObject model = new GameObject("Model");
		SetPositionAndParent(chunk.transform, position, model.transform);


		GameObject view = new GameObject("View");
		SetPositionAndParent(chunk.transform, position, view.transform);

		GameObject controller = new GameObject("Controller");
		SetPositionAndParent(chunk.transform, position, controller.transform);

		GameObject terrain = Instantiate(chunkGeneratorModel.terrain, position, Quaternion.identity);

		terrain.transform.name = "TerrainView";
		terrain.transform.parent = view.transform;

		ChunkModel chunkModel = model.AddComponent<ChunkModel>();

		chunkModel.nameOfObject = name;
		chunkModel.playerModel = chunkGeneratorModel.playerModel;
		chunkModel.terrain = terrain;
		chunkModel.chunkGeneratorModel = chunkGeneratorModel;

		ChunkController chunkController = controller.AddComponent<ChunkController>();

		chunkController.chunkModel = chunkModel;

		chunkGeneratorModel
			.updateManagerModel
			.chunkControllers
			.Add(controller.GetComponent<ChunkController>());
	}

	private void SetPositionAndParent(Transform parent, Vector3Int position, Transform child)
	{
		child.position = position;
		child.parent = parent;
	}
}
