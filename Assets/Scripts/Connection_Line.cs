using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        lr.SetPosition(1, endPoint.position);
    }
}