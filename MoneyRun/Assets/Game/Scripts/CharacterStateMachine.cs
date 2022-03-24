using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private static readonly int IsWalk = Animator.StringToHash("Walk");
    private static readonly int IsFail = Animator.StringToHash("Idle");

    private void OnEnable()
    {
        GameManager.OnLevelStarted += SetWalk;
        GameManager.OnLevelEnd += SetFail;
    }

    private void OnDisable()
    {
        GameManager.OnLevelStarted -= SetWalk;
        GameManager.OnLevelEnd -= SetFail;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void SetWalk()
    {
       _animator.SetTrigger(IsWalk);

    }
    void SetFail()
    {
        _animator.SetTrigger(IsFail);
    }

  
}
