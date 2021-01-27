using UnityEngine;
using UnityEngine.Events;

public class BoyMovement : MonoBehaviour
{
    public BoyMovementStateSO MovementState;
    public Vector3VariableSO BoyInitVelocity;
    public Vector3VariableSO BoyRuntimeVelocity;

    // Events
    public UnityEvent OnBoyCollideWall;
    public UnityEvent OnBoyFall;
    public UnityEvent OnBoyStop;

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
        BoyRuntimeVelocity.Value = rb.velocity;
        MovementState.BoyPosition = transform.position;
        SpeedCalculation();
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        OnBoyCollideWall.Invoke();
    }

    private void AliveCheck() 
    {
        if (MovementState.RBSpeed.Value == 0.0f)
        {
            OnBoyStop.Invoke();
            return;
        }

        if (MovementState.BoyPosition.y < -1)
        {
            OnBoyStop.Invoke();
            return;
        }
    }

    private void SpeedCalculation()
    {
        float x = BoyRuntimeVelocity.Value.x;
        float y = BoyRuntimeVelocity.Value.y;

        MovementState.RBSpeed.Value = Mathf.Sqrt(x * x + y * y);
    }
}
