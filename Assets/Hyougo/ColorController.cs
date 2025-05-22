using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TwoPlayerColorController : MonoBehaviour
{
    [Header("�v���C���[1 (Q/E) �̑Ώ�Image���X�g")]
    public List<Image> player1Images;

    [Header("�v���C���[2 (�e���L�[7/9) �̑Ώ�Image���X�g")]
    public List<Image> player2Images;

    [Header("���ʂ̐F���X�g")]
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
        // �Q�[���J�n���ɐԁi���X�g�ŏ��j��K�p
        if (colorList.Count > 0)
        {
            ApplyColor(player1Images, colorList[player1Index]); // red
            ApplyColor(player2Images, colorList[player2Index]); // red
        }
    }

    void Update()
    {
        // --- �v���C���[1���� ---
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

        // --- �v���C���[2���� ---
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
