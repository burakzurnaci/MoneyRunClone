
using _game.Scripts.Interaction;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.States != GameManager.GameStates.STARTED) return;
        var isInteractable = other.TryGetComponent<IInteractable>(out var interactable);
        if (isInteractable) interactable.OnInteracted(this);
    }
    
}
