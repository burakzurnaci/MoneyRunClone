using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class MoneyStairController : MonoBehaviour
{
    [SerializeField] private GameObject stairPrefab;
    [SerializeField] private int amount;
    private List<GameObject> stairs = new List<GameObject>();

    private void Start()
    {
        for (var i = 0; i < amount; i++)
        {
          var stair=  Instantiate(stairPrefab, transform);
          stair.transform.localPosition = Vector3.zero;
          stair.SetActive(false);
          stairs.Add(stair);
        }
    }

    public void SpawnFromPool(Transform position)
    {
        foreach (var stair in stairs)
        {
            if (!stair.activeInHierarchy)
            {
                stair.transform.SetParent(null);
                stair.transform.DOScale(Vector3.one*2, 0.1f).SetEase(Ease.Linear);
                stair.SetActive(true);
                var position1 = position.position;
                stair.transform.position = new Vector3(position1.x,position1.y,position1.z);
               return;
            };
            
        }
    }

    public void Reset()
    {
        foreach (var stair in stairs.Where(stair => stair.activeInHierarchy))
        {
            DOVirtual.DelayedCall(1, () => DeActive(stair));
        }
      
       
    }

    private void DeActive(GameObject stair)
    {
        stair.SetActive(false);
        stair.transform.SetParent(transform);
    }
}
