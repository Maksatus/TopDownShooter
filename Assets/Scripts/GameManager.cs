using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gameOver;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            panel.SetActive(true);
        }
    }
    
    private void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
