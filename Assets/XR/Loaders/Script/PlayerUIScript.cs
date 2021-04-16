using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUIScript : MonoBehaviour
{
    #region Public Properties

    //プレイヤー名前設定用Text
    public Text PlayerNameText;

    //プレイヤーのmoney用Slider
    public Slider PlayermoneySlider;

    #endregion

    #region Private Properties
    //追従するキャラのPlayerManager情報
    public PlayerManager _target;

    Vector3 _targetPosition;
    #endregion

    #region MonoBehaviour Messages
    void Update()
    {
        // 現在のmoneyをSliderに適用
        if (PlayermoneySlider != null)
        {
            PlayermoneySlider.value = _target.money;
        }
    }
    void LateUpdate()
    {
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
    }
    #endregion

    #region Public Methods
    public void SetTarget(PlayerManager target)
    {
        if (target == null)//targetがいなければエラーをConsoleに表示
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }
        //targetの情報をこのスクリプト内で使うのでコピー
        _target = target;

        if (PlayerNameText != null)
        {
            PlayerNameText.text = _target.photonView.Owner.NickName;
        }
        if (PlayermoneySlider != null)
        {
            PlayermoneySlider.value = _target.money;
        }
    }
    #endregion
}