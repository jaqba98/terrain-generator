using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size;

    private Player player;

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

        if (GameObject.Find(position.ToString())) return;

        new GameObject(position.ToString());
    }
}
