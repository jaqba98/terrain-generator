using UnityEngine;

public class ChunkController : MonoBehaviour
{
	[HideInInspector]
	public ChunkModel chunkModel;

	public void ManagedUpdate()
	{
		float distance = GetDistanceBetweenChunkAndPlayer();

		if (distance > chunkModel.chunkGeneratorModel.size * 2.5f)
		{
			if (chunkModel.terrain.activeSelf)
			{
				chunkModel.terrain.SetActive(false);
			}

			return;
		}

		if (!chunkModel.terrain.activeSelf)
		{
			chunkModel.terrain.SetActive(true);
		}
	}

	private float GetDistanceBetweenChunkAndPlayer()
	{
		float x1 = transform.position.x;
		float z1 = transform.position.z;
		float x2 = chunkModel.playerModel.playerView.transform.position.x;
		float z2 = chunkModel.playerModel.playerView.transform.position.z;

		return Mathf.Sqrt(((x2 - x1) * (x2 - x1)) + ((z2 - z1) * (z2 - z1)));
	}

	public string GetNameOfObject() => chunkModel.nameOfObject;
}
