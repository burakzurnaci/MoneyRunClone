using _game.Scripts.Interaction;
using UnityEngine;

public class MoneyDetector : MonoBehaviour,IInteractable
{
    [SerializeField] private int count;

    public void OnInteracted(Interactor interactor)
    {
        var moneyStackController = interactor.GetComponentInParent<MoneyStackController>();

        if (moneyStackController != null)
        {
            moneyStackController.AddStack(count);
            UIManager.Instance._scoreText.SetText(moneyStackController.GetScore().ToString());
        }
        gameObject.SetActive(false);
    }
}
