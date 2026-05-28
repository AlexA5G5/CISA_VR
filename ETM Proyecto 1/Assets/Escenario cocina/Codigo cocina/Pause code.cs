using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuVR : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Transform head;
    public float distanceFromHead = 1.5f;

    [Header("Input Action")]
    public InputActionReference pauseAction;

    void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePause;
    }

    void OnDisable()
    {
        pauseAction.action.performed -= TogglePause;
        pauseAction.action.Disable();
    }

    void TogglePause(InputAction.CallbackContext context)
    {
        if (GameIsPaused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        pauseMenuUI.transform.position =
            head.position + head.forward * distanceFromHead;

        pauseMenuUI.transform.rotation =
            Quaternion.LookRotation(pauseMenuUI.transform.position - head.position);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;   // importante para despausar
        GameIsPaused = false;

        SceneManager.LoadScene("Main Menu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;          // Muy importante
        GameIsPaused = false;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
