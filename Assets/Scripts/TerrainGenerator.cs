using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size;

    private Player player;

    public GameObject plane;

    private void Start()
    {
        Init();
        GenerateTerrain();
    }

    private void Init()
    {
        player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (player.IsNotMoving()) return;

        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        Vector3Int position = player.GetVector3IntPosition(size);

        CreateTerrain(position);
        CreateTerrain(new Vector3Int(position.x + size, position.y, position.z));
        CreateTerrain(new Vector3Int(position.x - size, position.y, position.z));
        CreateTerrain(new Vector3Int(position.x, position.y, position.z + size));
        CreateTerrain(new Vector3Int(position.x, position.y, position.z - size));
        CreateTerrain(new Vector3Int(position.x + size, position.y, position.z + size));
        CreateTerrain(new Vector3Int(position.x + size, position.y, position.z - size));
        CreateTerrain(new Vector3Int(position.x - size, position.y, position.z + size));
        CreateTerrain(new Vector3Int(position.x - size, position.y, position.z - size));
    }

    private void CreateTerrain(Vector3Int position)
    {
        if (GameObject.Find(position.ToString())) return;

        GameObject chunk = new GameObject(position.ToString());
        chunk.transform.position = position;
        GameObject terrain = Instantiate(plane, position, chunk.transform.rotation);
        terrain.transform.parent = chunk.transform;

        chunk.transform.parent = transform;
    }
}
