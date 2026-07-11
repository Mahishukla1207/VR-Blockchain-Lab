using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.05f;
    public float speed = 1f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos +
            Vector3.up * Mathf.Sin(Time.time * speed) * amplitude;
    }
}