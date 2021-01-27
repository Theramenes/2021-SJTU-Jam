using UnityEngine;
using UnityEngine.Events;

public class BoyMovement : MonoBehaviour
{
    public BoyMovementStateSO MovementState;
    public Vector3VariableSO BoyInitVelocity;
    public Vector3VariableSO BoyRuntimeVelocity;

    // Events
    public UnityEvent OnBoyCollideWall;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = BoyInitVelocity.Value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        BoyRuntimeVelocity.Value = rb.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnBoyCollideWall.Invoke();
    }
}
