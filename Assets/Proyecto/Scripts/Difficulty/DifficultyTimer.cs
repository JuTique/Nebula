using UnityEngine;
using TMPro;
using MoreMountains.CorgiEngine;

public class DifficultyTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerDisplay;
    [SerializeField] private CanvasGroup canvasGroup;

    private float timeRemaining;
    private bool isRunning = false;

    void Start()
    {
        if (!DifficultyManager.IsTimerEnabled())
        {
            if (canvasGroup != null)
                canvasGroup.alpha = 0;
            
            if (timerDisplay != null) 
                timerDisplay.gameObject.SetActive(false);
                
            return;
        }

        timeRemaining = DifficultyManager.GetTimerDuration();
        isRunning = true;

        if (canvasGroup != null)
            canvasGroup.alpha = 1;
            
        if (timerDisplay != null) 
            timerDisplay.gameObject.SetActive(true);

        // Ajustar tiempo según el nivel (para modo difícil)
        AdjustTimerByLevel();
    }

    void AdjustTimerByLevel()
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        
        if (currentScene == "Nivel1")
            timeRemaining = 300; // 5 min
        else if (currentScene == "Nivel2")
            timeRemaining = 240; // 4 min
        else if (currentScene == "Nivel3")
            timeRemaining = 180; // 3 min
    }

    void Update()
    {
        if (!isRunning || timeRemaining <= 0)
            return;

        timeRemaining -= Time.deltaTime;

        if (timerDisplay != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerDisplay.text = $"{minutes:00}:{seconds:00}";
        }

        if (timeRemaining <= 0)
        {
            TimeUp();
        }
    }

    void TimeUp()
    {
        isRunning = false;
        Debug.Log("¡Se acabó el tiempo!");
        
        // Matar al jugador
        Health playerHealth = FindObjectOfType<Health>();
        if (playerHealth != null && playerHealth.CompareTag("Player"))
        {
            playerHealth.Kill();
        }
    }
}
