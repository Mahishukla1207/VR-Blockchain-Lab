using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public GameObject packetPrefab;
    
    public Transform spawnPointA;
public Transform spawnPointB;
public Transform spawnPointC;
public Transform spawnPointD;

    public Transform targetPoint;
    public ServerManager serverManager;


    public void SendRequest()
{
    int randomUser = Random.Range(0, 4);

    Transform selectedSpawn = spawnPointA;

    switch (randomUser)
    {
        case 0:
            selectedSpawn = spawnPointA;
            break;

        case 1:
            selectedSpawn = spawnPointB;
            break;

        case 2:
            selectedSpawn = spawnPointC;
            break;

        case 3:
            selectedSpawn = spawnPointD;
            break;
    }

    SpawnPacket(selectedSpawn);
}
void SpawnPacket(Transform spawnPoint)
{
    if (!serverManager.isOnline)
    {
        Debug.Log("Request Failed! Server is Offline.");
        return;
    }

    GameObject packet = Instantiate(
        packetPrefab,
        spawnPoint.position,
        Quaternion.identity);

    PacketMover mover = packet.GetComponent<PacketMover>();

    mover.target = targetPoint;
    mover.serverManager = serverManager;
}
}