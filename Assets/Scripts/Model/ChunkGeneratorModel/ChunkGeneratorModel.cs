using UnityEngine;

public class ChunkGeneratorModel : MonoBehaviour
{
	public PlayerModel playerModel;

	public int size;

	public UpdateManagerModel updateManagerModel;

	public Transform chunksView;

	public GameObject terrain;

	public int width;

	public int height;

	public PerlinNoiseController perlinNoiseController;

	public Material material;
}
