using UnityEngine;

public class TerrainGeneratorController : MonoBehaviour
{
    [SerializeField] TerrainGeneratorModel terrainGeneratorModel;

    void Start() => GenerateTerrain();

    void Update() => GenerateTerrain(true);

    void GenerateTerrain(bool checkAPlayerIsMoving = false)
    {
        if (terrainGeneratorModel.playerController.IsNotMoving() && checkAPlayerIsMoving) return;
        
        terrainGeneratorModel.chunkGeneratorController.GenerateChunk();
    }
}
