
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float speed;
    public Transform stairSpawnPos;
    private MoneyStackController _moneyStackController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moneyStackController = GetComponent<MoneyStackController>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.States == GameManager.GameStates.STARTED)
        {
            _rigidbody.MovePosition(transform.position + (Vector3.forward*speed*Time.fixedDeltaTime));
        }
        if (GameManager.Instance.States == GameManager.GameStates.END)
        {
            if (_moneyStackController.GetMoneyStacksCount() > 0)
            {
                _rigidbody.MovePosition(transform.position + (Vector3.forward*speed*Time.fixedDeltaTime));
            }
        }
       
    }

    public void SetHeight()
    {
        _rigidbody.velocity = Vector3.up*1.75f;
    }
    public void SetHeightEnd()
    {
        _rigidbody.velocity = Vector3.up*1f;
    }

    public void SetGravity(bool state)
    {
        _rigidbody.useGravity = state;
    }
    public void SetForwardSpeed(int amount)
    {
        speed = amount;
    }
    
}

