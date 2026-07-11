using UnityEngine;

public class FloatingNodeMotion : MonoBehaviour
{
    public float floatAmplitude = 0.25f;
    public float floatSpeed = 1f;
    public float driftRadius = 0.5f;

    private Vector3 startPos;
    private Vector3 driftTarget;
    private Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        PickNewDriftTarget();
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        // Vertical floating
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        Vector3 floatPos = new Vector3(transform.position.x, startPos.y + yOffset, transform.position.z);

        // Horizontal drifting
        Vector3 driftDir = (driftTarget - transform.position);
        if (driftDir.magnitude < 0.1f)
            PickNewDriftTarget();

        rb.MovePosition(Vector3.Lerp(transform.position, floatPos + driftDir * 0.3f, Time.fixedDeltaTime));
    }

    void PickNewDriftTarget()
    {
        driftTarget = startPos + new Vector3(
            Random.Range(-driftRadius, driftRadius),
            0,
            Random.Range(-driftRadius, driftRadius)
        );
    }
    void OnEnable()
{
    startPos = transform.position;
}

}
