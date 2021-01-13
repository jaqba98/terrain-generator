using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Player player;

    private void Start() => player = FindObjectOfType<Player>();

    private void Update()
    {
        if (player.IsNotMoving()) return;

        Debug.Log("IsMoving");
    }
}
