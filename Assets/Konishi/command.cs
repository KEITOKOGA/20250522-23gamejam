using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class command : MonoBehaviour
{
    int[] keyCodes1;
    int cmd = 0;
    int[] konamiCommand =
    {
        (int)KeyCode.UpArrow,
        (int)KeyCode.UpArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.A,
        (int)KeyCode.B
    };  // Start is called before the first frame update
    void Start()
    {
        keyCodes1 = (int[])Enum.GetValues(typeof(KeyCode));
    }

    // Update is called once per frame
    void Update()
    {
        var com1 = keyCodes1.Length;
        for (int i = 0; i < com1; i++)
        {
            if (Input.GetKeyUp((KeyCode)keyCodes1[i]))
            {
                if (konamiCommand[cmd] == keyCodes1[i])
                {
                    cmd++;
                    if (cmd == konamiCommand.Length)
                    {
                        SceneManager.LoadScene("konamiscene");
                        cmd = 0;
                    }
                }
                else
                {
                    cmd = 0;
                }
}
        }
    }
}
