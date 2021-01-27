using UnityEngine;
using UnityEngine.Events;

public class VelocityModItem : BaseItem
{
    public UnityEvent OnBoyTriggerItem;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        OnBoyTriggerItem.Invoke();
        modifyObjectVelocity(other.GetComponent<Rigidbody>());
    }

    private void modifyObjectVelocity(Rigidbody rb)
    {
        rb.velocity += VelocityModify.Value;
    }

}
