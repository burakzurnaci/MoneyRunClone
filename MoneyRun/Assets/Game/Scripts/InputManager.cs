using UnityEngine;


public class InputManager : MonoBehaviour
{
    private MoneyStairController _moneyStairController;
    private float _nextActionTime = 0.0f;
    private MoneyStackController _moneyStackController;
    private float _timer = 0;
    [SerializeField] private float stairPeriod=0.15f;
    private void Awake()
    {
        _moneyStairController = CharacterManager.Instance._playerController.GetComponentInChildren<MoneyStairController>();
        _moneyStackController = CharacterManager.Instance._moneyStackController.GetComponent<MoneyStackController>();
    }

    void Update()
    {
        if (GameManager.Instance.States == GameManager.GameStates.NOT_STARTED)
        {
            if (Input.GetMouseButton(0))
            {
                GameManager.Instance.StartLevel();
            }
        }
        if (GameManager.Instance.States == GameManager.GameStates.STARTED)
        {
            if (Input.GetMouseButton(0))
            {
                _timer += Time.deltaTime;
                if (_moneyStackController.GetMoneyStacksCount() > 0)
                {
                    if (_timer > _nextActionTime)
                    {
                        _nextActionTime += stairPeriod;
                        _moneyStairController.SpawnFromPool(CharacterManager.Instance._playerController.stairSpawnPos);
                        _moneyStackController.RemoveStack(1);
                        CharacterManager.Instance._playerController.SetGravity(false);
                        CharacterManager.Instance._playerController.SetHeight();
                    }
                }
                else
                {
                    _nextActionTime = _timer;
                    _moneyStairController.Reset();
                    CharacterManager.Instance._playerController.SetGravity(true);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                _nextActionTime = _timer;
                _moneyStairController.Reset();
                CharacterManager.Instance._playerController.SetGravity(true);
            }
        }
        if (GameManager.Instance.States == GameManager.GameStates.END)
        {
            _timer += Time.deltaTime;
            if (_moneyStackController.GetMoneyStacksCount() > 0)
            {
                if (_timer > _nextActionTime)
                {
                    _nextActionTime += stairPeriod;
                    _moneyStairController.SpawnFromPool(CharacterManager.Instance._playerController.stairSpawnPos);
                    _moneyStackController.RemoveStack(1);
                    CharacterManager.Instance._playerController.SetGravity(false);
                    CharacterManager.Instance._playerController.SetHeight();
                }
            }
            else
            {
                _moneyStairController.Reset();
                CharacterManager.Instance._playerController.SetGravity(true);
            }
        }
    }
}

