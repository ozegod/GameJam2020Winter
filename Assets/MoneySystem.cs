using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem 
{
    int money;

    public void MoneyIncrease (int amount) {
        PlayerData.money = PlayerData.money + amount ;
    }
    public void MoneyDecrease (int amount) {
        PlayerData.money = PlayerData.money - amount ;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
