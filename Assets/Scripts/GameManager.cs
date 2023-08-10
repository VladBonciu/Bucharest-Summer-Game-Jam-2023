using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject hand;

    public List<CableColor> cableColors;

    public List<CableColor> cablesCut;

    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    AudioSource tickingBomb;

    [SerializeField]
    AudioSource humanVoice;
    [SerializeField]
    AudioClip humanGulp;
    [SerializeField]
    AudioClip humanDie;

    [SerializeField]
    AudioSource monitorSound;

    [SerializeField]
    AudioClip bombExplosion;

    [SerializeField]
    AudioClip bombTicking;

    [SerializeField]
    CameraControl cameraControl;

    [SerializeField]
    TMP_Text monitorText;

    [SerializeField]
    Cable[] cables;
    

    [SerializeField]
    Insanity insanity;

    int correctCuts;
    bool isCountingDown = false;

    [SerializeField]
    TMP_Text timerText;

    [SerializeField]
    int timer = 60;
    int maxTime;
    bool isUsingTimerMonitor;

    void Start()
    {
        tickingBomb.Stop();
        isUsingTimerMonitor = false;
        maxTime = timer;
    }

    public void StartGame()
    {
        
        foreach(Cable cable in cables)
        {
            cable.Reset();
        }

        timer = maxTime;

        isUsingTimerMonitor = true;
        StartCoroutine(Timer());

        hand.SetActive(true);
        cameraControl.GoToGame();
        
        correctCuts = 0;
        GenerateColorSequence();

        tickingBomb.clip = bombTicking;
        musicSource.Play();
        tickingBomb.Play();
        isCountingDown = false;
        ShowInstruction();

        insanity.StartTimer();
        insanity.gameStarted = true;
    }

    IEnumerator Timer()
    {
        if(isUsingTimerMonitor)
        {
            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
            StartCoroutine(Timer());
        }
        
    }

    public void EndGame()
    {
        timer = maxTime;
        hand.SetActive(false);
        correctCuts = 0;

        cableColors.Clear();
        cablesCut.Clear();

        insanity.colors.Clear();
        insanity.inputColors.Clear();

        musicSource.Stop();
        StartCoroutine(StopTicking());
        insanity.gameStarted = false;
        isUsingTimerMonitor = false;

        hand.GetComponent<Hand>().interactionText.text = " ";
    }

    public void LoseGame(int loseIndex)
    {

        //1 - Bomb Explosion
        //2 - Pill Poisoning

        if(loseIndex == 1)
        {
            tickingBomb.Stop();
            tickingBomb.clip = bombExplosion;
            tickingBomb.Play();
        }
        if(loseIndex == 2)
        {
            humanVoice.Stop();
            humanVoice.clip = humanDie;
            humanVoice.Play();
        }

        cameraControl.GoToMenu();
        correctCuts = 0;
        
        EndGame();
        hand.SetActive(false);

    }

    public void WinGame()
    {
        cameraControl.GoToMenu();
        hand.SetActive(false);
        correctCuts = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GulpPill()
    {
        humanVoice.Stop();
        humanVoice.clip = humanGulp;
        humanVoice.Play();
    }

    void GenerateColorSequence()
    {
        List<int> cableValues = new List<int>();

        while(cableValues.Count < 4)
        {
            int item = Random.Range(1, 5);
            
            if (!cableValues.Contains(item))
            cableValues.Add(item);
            
        }

        for (int i = 0; i < 4; i++)
        {
            if(cableValues[i] == 1)
            {
                cableColors.Add(CableColor.Yellow);
            }
            if(cableValues[i] == 2)
            {
                cableColors.Add(CableColor.Green);
            }
            if(cableValues[i] == 3)
            {
                cableColors.Add(CableColor.Red);
            }
            if(cableValues[i] == 4)
            {
                cableColors.Add(CableColor.Blue);
            }
        }
    }

    public void CutCable(CableColor color)
    {
        cablesCut.Add(color);


        if(CompareTo(cablesCut.Count - 1))
        {
            correctCuts++;
            if(correctCuts == 4)
            {
                cameraControl.GoToMenu();
                Debug.Log("You Win! Bomb Dissarmed");
            }
        }
        else
        {
            LoseGame(1);
            Debug.Log("You Lost! Bomb Eploded");
        }
    }

    bool CompareTo(int index)
    {
        return cablesCut[index].CompareTo(cableColors[index]) == 0;
    }

    

    void ShowInstruction()
    {
        if(correctCuts < 4)
        {
            if(isCountingDown == false)
            {
                monitorSound.Play();
                StartCoroutine(CountDownMonitor());
            }
        }
    }

    IEnumerator CountDownMonitor()
    {
        isCountingDown = true;
        
        if(cableColors.Count != 0)
        {
            monitorText.text = cableColors[cablesCut.Count].ToString();
        }
        
        yield return new WaitForSeconds(5f);
        monitorText.text = "Wait 10 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 9 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 8 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 7 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 6 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 5 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 4 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 3 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 2 seconds for the next instruction.";
        yield return new WaitForSeconds(1f);
        monitorText.text = "Wait 1 second for the next instruction.";
        yield return new WaitForSeconds(1f);

        isCountingDown = false;
        ShowInstruction();
    }

    IEnumerator StopTicking()
    {
        yield return new WaitForSeconds(2f);
        tickingBomb.Stop();
    }

    void Update()
    {
        if(timer == 0)
        {
            LoseGame(1);
        }
    }

}

public enum CableColor
{
    Yellow,
    Green,
    Red,
    Blue
}
