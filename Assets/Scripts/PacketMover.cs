using UnityEngine;

public class PacketMover : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

public ServerManager serverManager;
    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            if (serverManager != null)
    {
        serverManager.ProcessRequest();
    }

    Destroy(gameObject);
        }
    }
}