using UnityEngine;

public class FloatingNodeSpawner : MonoBehaviour
{
    public GameObject floatingNodePrefab;
    public int nodeCount = 8;
    public Vector3 spawnArea = new Vector3(3, 1.5f, 3);

    void Start()
    {
        for (int i = 0; i < nodeCount; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(0.8f, spawnArea.y),
                Random.Range(-spawnArea.z, spawnArea.z)
            );

            Instantiate(floatingNodePrefab, randomPos, Quaternion.identity);
        }
    }
}
