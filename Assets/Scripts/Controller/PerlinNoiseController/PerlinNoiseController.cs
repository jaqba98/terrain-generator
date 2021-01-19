using UnityEngine;

public class PerlinNoiseController : MonoBehaviour
{
    [SerializeField]
    private PerlinNoiseModel perlinNoiseModel;

    public Vector3[] CalculatePerlinNoise(Vector3[] vertices)
    {
        float scale = perlinNoiseModel.scale;

        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x / scale;
            float z = vertices[i].z / scale;

            float setX = transform.position.x / scale;
            float setZ = transform.position.z / scale;

            float height = Mathf.PerlinNoise(x + scale + setX, z + scale + setZ) * perlinNoiseModel.maxHight;

            if (height < perlinNoiseModel.minHeight) height = perlinNoiseModel.minHeight;

            vertices[i].y = height;
        }

        return vertices;
    }
}
