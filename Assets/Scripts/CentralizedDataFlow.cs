using System.Collections;
using UnityEngine;

public class CentralizedDataFlow : MonoBehaviour
{
    [Header("References")]
    public Transform server;              // Central server
    public Transform[] users;             // User1, User2, User3, User4
    public GameObject dataPacketPrefab;   // DataPacket prefab

    [Header("Settings")]
    public float spawnInterval = 0.5f;    // Time between packets

    private bool isFlowing = false;
    private Coroutine flowRoutine;

    // =========================
    // START DATA FLOW
    // =========================
    public void StartFlow()
    {
        if (isFlowing) return;

        isFlowing = true;
        flowRoutine = StartCoroutine(SpawnPackets());
    }

    // =========================
    // STOP DATA FLOW
    // =========================
    public void StopFlow()
    {
        isFlowing = false;

        if (flowRoutine != null)
        {
            StopCoroutine(flowRoutine);
            flowRoutine = null;
        }
    }

    // =========================
    // PACKET SPAWNER
    // =========================
    private IEnumerator SpawnPackets()
    {
        while (isFlowing)
        {
            SpawnSinglePacket();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // =========================
    // SPAWN ONE PACKET
    // =========================
    private void SpawnSinglePacket()
    {
        if (users.Length == 0 || dataPacketPrefab == null) return;

        // Pick random user
        int randomIndex = Random.Range(0, users.Length);
        Transform targetUser = users[randomIndex];

        // Direction from server to user
        Vector3 direction = (targetUser.position - server.position).normalized;

        // Spawn ON GROUND, slightly away from server
        Vector3 spawnPos = new Vector3(
            server.position.x + direction.x * 0.6f,
            0.05f, // ground height
            server.position.z + direction.z * 0.6f
        );

        // Instantiate packet
        GameObject packet = Instantiate(
            dataPacketPrefab,
            spawnPos,
            Quaternion.identity
        );

        // Assign target to mover
        DataPacketMover mover = packet.GetComponent<DataPacketMover>();
        if (mover != null)
        {
            mover.SetTarget(targetUser);
        }

        // Debug (optional)
        Debug.Log("Packet spawned → Target: " + targetUser.name);
    }
}
