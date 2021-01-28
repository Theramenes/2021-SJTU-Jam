using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Animations;

public class BoyMovement : MonoBehaviour
{
    public BoyMovementStateSO MovementState;
    public Vector3VariableSO BoyInitVelocity;
    public Vector3VariableSO BoyRuntimeVelocity;

    public Animator BoyAnimator;

    // Events
    public UnityEvent OnBoyCollideWall;
    public UnityEvent OnBoyFall;
    public UnityEvent OnBoyStop;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BoyRuntimeVelocity.Value = rb.velocity;
        MovementState.BoyPosition = transform.position;
        SpeedCalculation();
    }

    // 

    public void DashStart()
    {
        //StartCoroutine(WaitFewSeconds());
        Invoke("AddInitialVelocity", 2);
    }

    private void AddInitialVelocity()
    {
        rb.velocity = BoyInitVelocity.Value;
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

    private void DataInitializer() 
    {
        Vector3 zeroVec3 = new Vector3(0, 0, 0);

        MovementState.RBSpeed.Value = 0.0f;
        MovementState.BoyPosition = zeroVec3;

        BoyRuntimeVelocity.Value = zeroVec3;
    }

    IEnumerator WaitFewSeconds()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
    }

    public void OnDeadFreeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }


}
