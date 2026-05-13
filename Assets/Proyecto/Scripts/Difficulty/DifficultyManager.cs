using UnityEngine;
using MoreMountains.CorgiEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }

    public enum Difficulty { Easy, Medium, Hard }
    public static Difficulty CurrentDifficulty { get; private set; } = Difficulty.Medium;

    [System.Serializable]
    public class DifficultySettings
    {
        public Difficulty difficulty;
        public int playerHealth;
        public int enemyDamage;
        public bool timerEnabled;
        public int timerDurationSeconds; // 0 = sin límite
        public float coinMultiplier;
        public float invulnerabilityDuration;
        public float enemyAggression; // 0-1, afecta velocidad movimiento y rango detección
    }

    [SerializeField] private DifficultySettings[] difficultySettings = new DifficultySettings[3];

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Inicializar dificultades por defecto si no están configuradas
        if (difficultySettings[0] == null)
            InitializeDefaultSettings();
    }

    void InitializeDefaultSettings()
    {
        // FÁCIL
        difficultySettings[0] = new DifficultySettings
        {
            difficulty = Difficulty.Easy,
            playerHealth = 15,
            enemyDamage = 1,
            timerEnabled = false,
            timerDurationSeconds = 0,
            coinMultiplier = 1.25f,
            invulnerabilityDuration = 2f,
            enemyAggression = 0.5f
        };

        // MEDIO
        difficultySettings[1] = new DifficultySettings
        {
            difficulty = Difficulty.Medium,
            playerHealth = 15,
            enemyDamage = 1,
            timerEnabled = false,
            timerDurationSeconds = 0,
            coinMultiplier = 1.25f,
            invulnerabilityDuration = 1.5f,
            enemyAggression = 0.7f
        };

        // DIFÍCIL
        difficultySettings[2] = new DifficultySettings
        {
            difficulty = Difficulty.Hard,
            playerHealth = 6,
            enemyDamage = 3,
            timerEnabled = true,
            timerDurationSeconds = 300, // 5 min para Nivel 1, ajustar por escena
            coinMultiplier = 0.75f,
            invulnerabilityDuration = 0.8f,
            enemyAggression = 1f
        };
    }

    public static void SetDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        PlayerPrefs.SetInt("Difficulty", (int)difficulty);
        PlayerPrefs.Save();
        Debug.Log($"Dificultad cambiada a: {difficulty}");
    }

    public static DifficultySettings GetCurrentSettings()
    {
        return Instance.difficultySettings[(int)CurrentDifficulty];
    }

    public static DifficultySettings GetSettings(Difficulty difficulty)
    {
        return Instance.difficultySettings[(int)difficulty];
    }

    public static int GetPlayerHealth()
    {
        return GetCurrentSettings().playerHealth;
    }

    public static int GetEnemyDamage()
    {
        return GetCurrentSettings().enemyDamage;
    }

    public static bool IsTimerEnabled()
    {
        return GetCurrentSettings().timerEnabled;
    }

    public static int GetTimerDuration()
    {
        return GetCurrentSettings().timerDurationSeconds;
    }

    public static float GetCoinMultiplier()
    {
        return GetCurrentSettings().coinMultiplier;
    }

    public static float GetInvulnerabilityDuration()
    {
        return GetCurrentSettings().invulnerabilityDuration;
    }

    public static float GetEnemyAggression()
    {
        return GetCurrentSettings().enemyAggression;
    }
}
