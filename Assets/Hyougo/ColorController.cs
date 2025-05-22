using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TwoPlayerColorController : MonoBehaviour
{
    [Header("プレイヤー1 (Q/E) の対象Imageリスト")]
    public List<Image> player1Images;

    [Header("プレイヤー2 (テンキー7/9) の対象Imageリスト")]
    public List<Image> player2Images;

    [Header("共通の色リスト")]
    public List<Color> colorList = new List<Color>
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow
    };

    private int player1Index = 0;
    private int player2Index = 0;

    void Start()
    {
        // ゲーム開始時に赤（リスト最初）を適用
        if (colorList.Count > 0)
        {
            ApplyColor(player1Images, colorList[player1Index]); // red
            ApplyColor(player2Images, colorList[player2Index]); // red
        }
    }

    void Update()
    {
        // --- プレイヤー1操作 ---
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player1Index = (player1Index - 1 + colorList.Count) % colorList.Count;
            ApplyColor(player1Images, colorList[player1Index]);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            player1Index = (player1Index + 1) % colorList.Count;
            ApplyColor(player1Images, colorList[player1Index]);
        }

        // --- プレイヤー2操作 ---
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            player2Index = (player2Index - 1 + colorList.Count) % colorList.Count;
            ApplyColor(player2Images, colorList[player2Index]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            player2Index = (player2Index + 1) % colorList.Count;
            ApplyColor(player2Images, colorList[player2Index]);
        }
    }

    void ApplyColor(List<Image> targets, Color color)
    {
        foreach (Image img in targets)
        {
            if (img != null)
                img.color = color;
        }
    }
}
