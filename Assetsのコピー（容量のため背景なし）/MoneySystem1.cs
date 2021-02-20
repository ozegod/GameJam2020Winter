using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem1
{
    int money;

    public void gMoneyIncrease (int amount) {
        Player1Data.money = Player1Data.money + amount ;
    }
    public void MoneyDecrease (int amount) {
        Player1Data.money = Player1Data.money - amount ;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
