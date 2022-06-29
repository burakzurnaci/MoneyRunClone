
using _game.Scripts.Interaction;
using UnityEngine;

public class Obstacle : MonoBehaviour,IInteractable
{
    public ParticleSystem collisionParticleSystem;
    public MeshRenderer mr;
    public bool once = true;
    public BoxCollider bc;
    [SerializeField] private int count;
    // Start is called before the first frame update
    public void OnInteracted(Interactor interactor)
    {
        var moneyStackController = interactor.GetComponentInParent<MoneyStackController>();
        if (moneyStackController != null)
        {
            moneyStackController.RemoveStack(count);
            UIManager.Instance._scoreText.SetText(moneyStackController.GetScore().ToString());
        }

        var em = collisionParticleSystem.emission;
        var dur = collisionParticleSystem.duration;
        em.enabled = true;
        collisionParticleSystem.Play();
        once = false;
        Destroy(bc);
        Destroy(mr);
        
        Invoke(nameof(DestroyObj), dur);
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
