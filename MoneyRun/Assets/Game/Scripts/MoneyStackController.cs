
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MoneyStackController : MonoBehaviour
{
    [SerializeField] private GameObject moneyStackPrefab;
    [SerializeField] private Transform moneyHolderParent;
    private List<GameObject> moneyStacks = new List<GameObject>();
    private float yPos;
    private float xPos;

   
    
    [Button]
    public void AddStack(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            var money = Instantiate(moneyStackPrefab,moneyHolderParent);
            moneyStacks.Add(money);
            money.transform.localPosition = new Vector3(CalculateXPos(),CalculateYPos() , 0);
        }
       
     
    }
    [Button]
    public void RemoveStack(int amount)
    {
        if (amount > moneyStacks.Count)
        {
            //ToDo GameLose Imp.
            amount = moneyStacks.Count;
            Debug.Log(moneyStacks.Count);
        }
        for (var i = 0; i < amount; i++)
        {
            var money = moneyStacks[moneyStacks.Count - 1];
            DestroyImmediate(money);
            moneyStacks.RemoveAt(moneyStacks.Count-1);
            UIManager.Instance._scoreText.SetText(GetScore().ToString());
        }
        
    }

    public int GetMoneyStacksCount()
    {
        return moneyStacks.Count;
    }

    private float CalculateYPos()
    {
        var yPos =  (int)(moneyStacks.Count / 5f) * 0.1f;
        return yPos;
    }

    private float CalculateXPos()
    {
        if (moneyStacks.Count % 5 == 0)
        {
            return -0.4f;
        }
        
        return - 0.5f +((moneyStacks.Count % 5f) / 10f);
    }

    public int GetScore()
    {
        return moneyStacks.Count * 10;
    }

}
