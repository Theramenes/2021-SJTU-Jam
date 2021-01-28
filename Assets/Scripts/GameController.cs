using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public CinemachineVirtualCamera DashFollowCamera;

    public 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoyFall()
    {

        Debug.Log("Orga Fall.");
    }

    public void BoyStopped() 
    {
        Debug.Log("Orga Stopped.");
    }

    public void OnDead()
    {
        //PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
