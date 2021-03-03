using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//お金
public class MoneySystem2 
{
    int money;

    public void MoneyIncrease (int amount) {
        Player2Data.money = Player2Data.money + amount ;
    }
    public void MoneyDecrease (int amount) {
        Player2Data.money = Player2Data.money - amount ;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
