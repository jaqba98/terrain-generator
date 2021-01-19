using UnityEngine;

public class ChunkModel : MonoBehaviour
{
	[HideInInspector]
	public ChunkGeneratorModel chunkGeneratorModel;

	[HideInInspector]
	public GameObject terrain;

	[HideInInspector]
	public PlayerModel playerModel;

	[HideInInspector]
	public string nameOfObject;
}
