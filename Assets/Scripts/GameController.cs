using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCharacterFall()
    {

        Debug.Log("Orga Fall.");
    }

    public void OnCharacterStopped() 
    {
        Debug.Log("Orga Stopped.");
    }

    public void OnCharacterDead()
    {
        //PauseGame();
    }

    public void OnCharacterTakeOff()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("Basic Feature Test Scene");
    }

}
