using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int money;
    public float x;
    public float y;
    public float z;
    public float angleTheta;
    public float anglePhi;
    readonly int r = 5;

    GameObject Dice;
    DiceController diceController;
    public Playermove playermove;
    [SerializeField]
    // 現在自分のターンかどうか
    private bool myTurn;
    public  int D = 0;
    public int countspace = 0;

    public Vector3 GetPositionOnSphere(float angleTheta, float anglePhi, int r)
    {
        float x = r * Mathf.Sin(angleTheta * 2 * Mathf.PI / 360) * Mathf.Cos(anglePhi * 2 * Mathf.PI / 360);
        float y = r * Mathf.Cos(angleTheta * 2 * Mathf.PI / 360);
        float z = r * Mathf.Sin(angleTheta * 2 * Mathf.PI / 360) * Mathf.Sin(anglePhi * 2 * Mathf.PI / 360);
        return new Vector3(x, y, z);
    }

    private void Start()
    {
        angleTheta = 0f;
        anglePhi = 0f;
        // ターンマネジャーを取得
        this.Dice = GameObject.Find("Dice");
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
    }

    void Update()
    {
        this.transform.position = GetPositionOnSphere(angleTheta, anglePhi, r);
        this.transform.rotation = Quaternion.Euler(0, 0, angleTheta);

        if (!myTurn)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                diceController.a++;
                diceController.DiceRoll();
            }

            D = int.Parse(this.Dice.GetComponent<Text>().text);

            if (diceController.a % 3 == 2)
            {
                if (D > 0)
                {
                    D = int.Parse(this.Dice.GetComponent<Text>().text);
                    playermove.MoveStart();
                }
                else
                {
                    playermove.MoveStop();
                }
            }
            if ((diceController.a % 3 == 0) && (diceController.a > 0))
            {
                playermove.u = 0;
            }
            
        }

        //スペースキー押された回数をとりあえずカウント
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countspace++;
        }
    }

    public void SetMyTurn(bool flag)
    {
        myTurn = flag;
    }


}
