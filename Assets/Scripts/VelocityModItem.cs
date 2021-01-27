using UnityEngine;

public class VelocityModItem : BaseItem
{
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
        other.GetComponent<Rigidbody>().velocity += VelocityModify.Value;
    }

}
