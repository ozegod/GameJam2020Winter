using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameObject Dice;
    private DiceController diceController;
    private TurnManager turnManager;
    [SerializeField]
    // 現在自分のターンかどうか
    private bool myTurn;

    public static int d = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ターンマネジャーを取得
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        this.Dice = GameObject.Find("Dice");

    }

    // Update is called once per frame
    void Update()
    {
        if (!myTurn)
        {
            return;
        }
        else if (d == 0)
        {
            if (TimeManager.t >= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    diceController.DiceRoll();
                }
            }
        }

        if (TimeManager.t >= 0)
        {
            if (diceController.a % 2 == 0)
            {
                d = int.Parse(Dice.GetComponent<Text>().text);
                int currentPlayer = TurnManager.currentPlayer;
                if (d > 0)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        d -= 1;
                        Dice.GetComponent<Text>().text = d.ToString();
                        transform.Translate(new Vector3(1, 0, 0));
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        d -= 1;
                        Dice.GetComponent<Text>().text = d.ToString();
                        transform.Translate(new Vector3(-1, 0, 0));
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        d -= 1;
                        Dice.GetComponent<Text>().text = d.ToString();
                        transform.Translate(new Vector3(0, 1, 0));
                    }
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        d -= 1;
                        Dice.GetComponent<Text>().text = d.ToString();
                        transform.Translate(new Vector3(0, -1, 0));
                    }
                    //MoveData.MoveMove();
                }

            }
        }
    }

    public void SetMyTurn(bool flag)
    {
        myTurn = flag;
    }

}
