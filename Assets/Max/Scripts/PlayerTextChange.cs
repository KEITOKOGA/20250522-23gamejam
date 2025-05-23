using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTextChange : MonoBehaviour
{

    //Change the colors based on "Ready" state
    [Header("Color Gradient Change")]
    [SerializeField] public TextMeshProUGUI Player1;
    [SerializeField] public TextMeshProUGUI Player2;
    [SerializeField] public TMP_ColorGradient NotReady;
    [SerializeField] public TMP_ColorGradient Ready;

    [Header("Timer Gradient Color")]
    [SerializeField] private TMP_ColorGradient Timer1s;
    [SerializeField] private TMP_ColorGradient Timer2s;
    [SerializeField] private TMP_ColorGradient Timer3s;
    [SerializeField] private TMP_ColorGradient TimerGO;

    //Start the countdown and decide the timer
    [Header("Countdown")]
    [SerializeField] private GameObject menuUI;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private int countdownTimer = 3;

    //Sound when a player is ready
    [Header("Sounds")]
    [SerializeField] private AudioClip readySound;
    [SerializeField] private AudioClip timerSound;
    [SerializeField] private AudioSource menuAudioSource;


    public bool isReadyP1 = false;
    public bool isReadyP2 = false;
    public bool gameStarts = false;

    private int readyCounterP1 = 0;
    private int readyCounterP2 = 0;

    private bool countdownRunning = false;
    bool konamiflag = false;
    int cmd1Seq = 0;
    int[] keyCodes1;
    int[] konamiCommand = new[] {
        (int)KeyCode.UpArrow,
        (int)KeyCode.UpArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.B,
        (int)KeyCode.A
    };

    private void Start()
    {
        countdownText.gameObject.SetActive(false);
        keyCodes1 = (int[])Enum.GetValues(typeof(KeyCode));
    }
    private void Update()
    {
        // Change text to "READY"
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.E))
        {
            if (readyCounterP1 == 0)
            {
                Debug.Log("P1 is ready");
                Player1.text = "P1 IS READY";
                isReadyP1 = true;
                readyCounterP1++;
                Player1.colorGradientPreset = isReadyP1 ? Ready : NotReady;

                if (!countdownRunning)
                {
                    menuAudioSource.PlayOneShot(readySound);
                }
            }
            else if(readyCounterP1 == 1)
            {
                Player1.text = "PRESS E";
                isReadyP1 = false;
                readyCounterP1--;
                Player1.colorGradientPreset = isReadyP1 ? Ready : NotReady;
            }

        }


        if (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.O))
        {
            if (readyCounterP2 == 0)
            {
                Debug.Log("P2 is ready");
                Player2.text = "P2 IS READY";
                isReadyP2 = true;
                readyCounterP2++;
                Player2.colorGradientPreset = isReadyP2 ? Ready : NotReady;

                if (!countdownRunning)
                {
                    menuAudioSource.PlayOneShot(readySound);
                }
            }
            else if (readyCounterP2 == 1)
            {
                Player2.text = "PRESS O";
                isReadyP2 = false;
                readyCounterP2--;
                Player2.colorGradientPreset = isReadyP2 ? Ready : NotReady;
            }
        }

        if (isReadyP1 == true && isReadyP2 == true && countdownRunning == false)
        {
            StartCoroutine(Countdown());
            Debug.Log("Countdown running");
        }
        var com1 = keyCodes1.Length;
        for (var i = 0; i < com1; i++)
        {
            if (Input.GetKeyUp((KeyCode)keyCodes1[i]))
            {
                if (konamiCommand[cmd1Seq] == keyCodes1[i])
                {
                    cmd1Seq++;
                    if (cmd1Seq == konamiCommand.Length)
                    {
                        konamiflag = true;
                        cmd1Seq = 0;
                    }
                }
                else
                {
                    cmd1Seq = 0;
                }
            }
        }
    }


    private IEnumerator Countdown()
    {
        countdownRunning = true;
        menuUI.SetActive(false);
        countdownText.gameObject.SetActive(true);

        int timer = Mathf.CeilToInt(countdownTimer); // Start with 3 as integer

        menuAudioSource.PlayOneShot(timerSound);

        while (timer > 0)
        {
            switch(timer)
            {
                case 3:
                    countdownText.colorGradientPreset = Timer3s;
                    break;
                case 2:
                    countdownText.colorGradientPreset = Timer2s;
                    break;
                case 1:
                    countdownText.colorGradientPreset = Timer1s;
                    break;
            }

            countdownText.ForceMeshUpdate();

            countdownText.text = timer.ToString();
            yield return new WaitForSeconds(1);
            // Wait exactly 1 second
            Debug.Log(timer);
            timer--; // Decrement integer
        }

        countdownText.text = "GO!";
        countdownText.colorGradientPreset = TimerGO;
        countdownText.ForceMeshUpdate();

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        countdownRunning = false;
        if(konamiflag == false)
        {
            StartGame();
        }
        else
        {
            SpecialGame();
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("InGameScene");
    }
    private void SpecialGame()
    {
        SceneManager.LoadScene("SpecialScene");
    }
}
