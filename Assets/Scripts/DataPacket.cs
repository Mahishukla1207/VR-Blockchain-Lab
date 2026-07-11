using UnityEngine;

public class DataPacket : MonoBehaviour
{
    public Transform targetUser;
    public float speed = 2f;

    private bool reached = false;

    void Update()
    {
        if (targetUser == null || reached) return;

        // Keep movement on ground
        Vector3 targetPos = new Vector3(
            targetUser.position.x,
            transform.position.y,
            targetUser.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        // Stop when close enough
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            reached = true;
        }
    }
}
