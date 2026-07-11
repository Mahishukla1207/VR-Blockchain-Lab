using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecentralizedDataFlow : MonoBehaviour
{
    [Header("References")]
    public Transform[] nodes;              // All nodes in the circle
    public GameObject dataPacketPrefab;    // Your DataPacket prefab

    [Header("Settings")]
    public float spawnInterval = 0.6f;
    public float groundY = 0.05f;

    private bool running = false;
    private Coroutine flowRoutine;

    // =========================
    // START / STOP
    // =========================
    public void StartFlow()
    {
        if (running) return;

        running = true;
        flowRoutine = StartCoroutine(SpawnPackets());
    }

    public void StopFlow()
    {
        running = false;

        if (flowRoutine != null)
        {
            StopCoroutine(flowRoutine);
            flowRoutine = null;
        }
    }

    // =========================
    // CORE LOGIC
    // =========================
    IEnumerator SpawnPackets()
    {
        while (running)
        {
            // Pick two DIFFERENT nodes
            int fromIndex = Random.Range(0, nodes.Length);
            int toIndex = Random.Range(0, nodes.Length);

            if (fromIndex == toIndex)
                continue;

            Transform fromNode = nodes[fromIndex];
            Transform toNode = nodes[toIndex];

            // Spawn packet at source node (on ground)
            Vector3 spawnPos = new Vector3(
                fromNode.position.x,
                groundY,
                fromNode.position.z
            );

            GameObject packet = Instantiate(
                dataPacketPrefab,
                spawnPos,
                Quaternion.identity
            );

            // Assign target node
            DataPacketMover mover = packet.GetComponent<DataPacketMover>();
            mover.SetTarget(toNode);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Start()
{
    StartFlow();
}

}
