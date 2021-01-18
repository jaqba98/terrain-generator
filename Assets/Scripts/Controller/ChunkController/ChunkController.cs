using UnityEngine;

public class ChunkController : MonoBehaviour
{
	public ChunkModel chunkModel;

	public void ManagedUpdate()
	{
		try
		{
			float distance = GetDistanceBetweenChunkAndPlayer();

			if (distance > 250f)
			{
				chunkModel.terrain.SetActive(false);
			}

			else
			{
				chunkModel.terrain.SetActive(true);
			}
		}

		catch { }
	}

	float GetDistanceBetweenChunkAndPlayer()
	{
		float x1 = transform.position.x;
		float z1 = transform.position.z;
		float x2 = chunkModel.playerModel.playerView.transform.position.x;
		float z2 = chunkModel.playerModel.playerView.transform.position.z;

		return Mathf.Sqrt(((x2 - x1) * (x2 - x1)) + ((z2 - z1) * (z2 - z1)));
	}

	public string GetNameOfObject()
	{
		return chunkModel.nameOfObject;
	}
}
