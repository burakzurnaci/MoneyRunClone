using _game.Scripts.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameEnd : MonoBehaviour,IInteractable
{
    // Start is called before the first frame update
    public void OnInteracted(Interactor interactor)
    {
        var moneyStackController = interactor.GetComponentInParent<MoneyStackController>();

        if (moneyStackController != null)
        { 
            UIManager.Instance._hscoreText.SetText(moneyStackController.GetScore().ToString());
            UIManager.Instance._end.SetActive(true);
            GameManager.Instance.LevelEnd();
        }
    }
}
