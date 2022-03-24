
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public delegate void LevelEvent();

    public static LevelEvent OnLevelStarted;
    public static LevelEvent OnLevelEnd;

    public GameStates States;
    
    public enum GameStates
    {
        NOT_STARTED,
        STARTED,
        END,
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }
    public void StartLevel()
    {
        States = GameStates.STARTED;
        OnLevelStarted?.Invoke();
    }
    public void LevelEnd()
    {
        States = GameStates.END;
        OnLevelEnd?.Invoke();
    }
// Update is called once per frame
    void Update()
    {
        
    }
}
