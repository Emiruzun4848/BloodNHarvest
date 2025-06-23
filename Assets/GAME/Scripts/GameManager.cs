using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGamePaused { get; private set; } = false;
    public bool IsGameOver { get; private set; } = false;
    public bool IsGameStarted { get; private set; } = false;
    public bool IsGameFinished { get; private set; } = false;
    public bool IsGameLoading { get; private set; } = false;
    public bool IsGameSaved { get; private set; } = false;
    public bool IsGameResumed { get; private set; } = false;
    public bool IsGameQuit { get; private set; } = false;
    public bool IsGameRestarted { get; private set; } = false;
    public bool IsGameExit { get; private set; } = false;
    public bool IsGameMenu { get; private set; } = false;
    public bool IsGameSettings { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCharacterState(bool isActive)
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy enemy in enemies)
        {
            enemy.enemyMovement.canMovable = isActive;
            enemy.attackManager.CanAttack = isActive;
        }


        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            player.playerMovement.CanMoveable = isActive;
            player.attackManager.CanAttack = isActive;
        }
    }

    private void Start()
    {
        // Initialize game settings or load saved data here
    }
    public void PauseGame()
    {
        SetCharacterState(false);

    }
    public void ResumeGame()
    {
        SetCharacterState(true);
    }
}