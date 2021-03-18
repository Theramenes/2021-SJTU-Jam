using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Animations;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Data")]
    public CharacterMovementStateSO MovementState;
    public Vector3VariableSO InitVelocity;
    public Vector3VariableSO RuntimeVelocity;

    [Header("Animator")]
    public Animator BoyAnimator;

    // Events
    [Header("Events")]
    public UnityEvent OnDashStart;
    public UnityEvent OnCollideWall;
    public UnityEvent OnFall;
    public UnityEvent OnStop;

    private Rigidbody rb;
    private float stopTimeThreshold = 1.5f;
    private float stopSpeedThreshold = 0.1f;
    private float gameStartDelayThreshold = 2.0f;
    private bool isDash = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BoyAnimator = GetComponentInChildren<Animator>();

        MovementParameterInitialize();
    }
    // Update is called once per frame
    void Update()
    {
        RuntimeVelocity.Value = rb.velocity;
        MovementState.CharacterPosition.SetValue(transform.position);
        SpeedCalculation();
        AliveCheck();
    }

    public void GameStart()
    {
        Debug.Log("Game Start.");
        StartCoroutine("GameStartDelay");
    }

    private void addInitialVelocity()
    {
        isDash = true;
        rb.velocity = InitVelocity.Value;
        BoyAnimator.SetInteger("Trigger", 1);
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCollideWall.Invoke();
    }

    private void AliveCheck() 
    {
        if (isDash)
        {
            if (MovementState.CharacterSpeed.Value <= stopSpeedThreshold)
            {
                StartCoroutine("OnStopChecking");
            }

            if (MovementState.CharacterPosition.Value.y < -1)
            {
                OnFall.Invoke();
                isDash = false;
            }
        }
        return;
    }

    public void OnDeadFreeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        BoyAnimator.SetInteger("Trigger", 0);
    }

    /*
     * utility methods
     */
    private void SpeedCalculation()
    {
        float x = RuntimeVelocity.Value.x;
        float y = RuntimeVelocity.Value.y;

        MovementState.CharacterSpeed.Value = Mathf.Sqrt(x * x + y * y);
    }

    private void MovementParameterInitialize()
    {
        MovementState.CharacterSpeed.VariableInitialize();
        MovementState.CharacterPosition.VariableInitialize();
        MovementState.CharacterVelocity.VariableInitialize();
    }

    private IEnumerator GameStartDelay()
    {
        float timeElapsed = 0.0f;

        while (true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= gameStartDelayThreshold)
            {

                Debug.Log("start dash");
                OnDashStart.Invoke();
                addInitialVelocity();
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator OnStopChecking()
    {
        float timeElapsed = 0.0f;
        
        while(MovementState.CharacterSpeed.Value < stopSpeedThreshold)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= stopTimeThreshold)
            {
                isDash = false;
                OnStop.Invoke();
                yield break;
            }
            yield return null;
        }
        yield break;
    }

    IEnumerator WaitFewSeconds()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
    }



}
