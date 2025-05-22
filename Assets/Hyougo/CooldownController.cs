using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    public float actionCooldown = 5f;      // アクション後のクールタイム（秒）
    private float actionEndTimePlayer1;    // プレイヤー1のクールタイム終了時刻
    private float actionEndTimePlayer2;    // プレイヤー2のクールタイム終了時刻

    // プレイヤー1用の進捗バー（円形）
    public Image cooldownImagePlayer1;
    private bool isActioningPlayer1 = false;

    // プレイヤー2用の進捗バー（円形）
    public Image cooldownImagePlayer2;
    private bool isActioningPlayer2 = false;

    private void Start()
    {
        // 初期状態では進捗がない状態に設定
        if (cooldownImagePlayer1 != null)
        {
            cooldownImagePlayer1.fillAmount = 0f;
        }
        if (cooldownImagePlayer2 != null)
        {
            cooldownImagePlayer2.fillAmount = 0f;
        }
    }

    private void Update()
    {
        HandlePlayerActions();
    }

    private void HandlePlayerActions()
    {
        // プレイヤー1がスペースキーでアクション
        if (Input.GetKeyDown(KeyCode.Space) && !isActioningPlayer1)
        {
            StartAction(ref isActioningPlayer1, ref actionEndTimePlayer1, cooldownImagePlayer1);
        }

        // プレイヤー2が右シフトキーでアクション
        if (Input.GetKeyDown(KeyCode.RightShift) && !isActioningPlayer2)
        {
            StartAction(ref isActioningPlayer2, ref actionEndTimePlayer2, cooldownImagePlayer2);
        }

        // プレイヤー1のアクション後クールタイムを管理
        if (isActioningPlayer1 && Time.time > actionEndTimePlayer1)
        {
            ResetCooldown(ref isActioningPlayer1, cooldownImagePlayer1);
        }

        // プレイヤー2のアクション後クールタイムを管理
        if (isActioningPlayer2 && Time.time > actionEndTimePlayer2)
        {
            ResetCooldown(ref isActioningPlayer2, cooldownImagePlayer2);
        }

        // アクション進捗バー（円形）の更新
        UpdateCooldownUI();
    }

    // アクションを開始するメソッド
    private void StartAction(ref bool isActioning, ref float actionEndTime, Image cooldownImage)
    {
        // クールタイムの終了時刻を設定
        actionEndTime = Time.time + actionCooldown;
        isActioning = true;  // アクション開始
        cooldownImage.fillAmount = 1f;  // 進捗バーを100%にセット
        Debug.Log("アクション開始！");
    }

    // アクション後のクールタイムをリセットするメソッド
    private void ResetCooldown(ref bool isActioning, Image cooldownImage)
    {
        isActioning = false;  // クールタイム終了
        cooldownImage.fillAmount = 0f;  // 進捗バーをリセット
    }

    // 円形進捗バーのUIを更新するメソッド
    private void UpdateCooldownUI()
    {
        // プレイヤー1のクールタイム進捗バー更新
        if (isActioningPlayer1)
        {
            float remainingTime = actionEndTimePlayer1 - Time.time;  // 残り時間
            cooldownImagePlayer1.fillAmount = remainingTime / actionCooldown;  // 残り時間に応じてバーの進捗を調整
        }

        // プレイヤー2のクールタイム進捗バー更新
        if (isActioningPlayer2)
        {
            float remainingTime = actionEndTimePlayer2 - Time.time;  // 残り時間
            cooldownImagePlayer2.fillAmount = remainingTime / actionCooldown;  // 残り時間に応じてバーの進捗を調整
        }
    }
}
