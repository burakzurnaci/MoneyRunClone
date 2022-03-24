using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private MoneyStackController _moneyStackController;
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _hscoreText;
    public GameObject _play;
    public GameObject _end;
    // Start is called before the first frame update
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
    private void OnEnable()
    {
        GameManager.OnLevelStarted += GameStart;

    }

    private void GameStart()
    {
        _play.SetActive(false);
    }
}