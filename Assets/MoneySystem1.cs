using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//player1のお金
public class MoneySystem1
{

    int money1;

    //money加減
    public void MoneyIncrease (int amount) {
        Player1Data.money = Player1Data.money + amount ;
    }
    public void MoneyDecrease (int amount) {
        Player1Data.money = Player1Data.money - amount ;
    }

    //money表示
    /*public void money() {
        this.money1.GetComponent<Text>().text = Player1Data.money.ToString();
    }
   */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
