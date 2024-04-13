using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Random;

public class Hangman : MonoBehaviour
{
    [SerializeField] Transform HangmanPrefab;
    [SerializeField] Transform EndScreenPrefab;
    [SerializeField] private TextMeshProUGUI WordBox;
    [SerializeField] TextMeshProUGUI GuessBox;
    private bool Win = false;
    private bool Lose = false;

    
    private string PlayerInput;

    private string word = "";
    private int strike = 0;
    
    private string[] words = {
                              "ISEEYOU",
                              "HEART",
                              "ICANFEELYOURFEAR",                         
                              "IAMTHEHANGMAN",
                              "YOUWILLHANGTOO",
                              "THENOOSEISTIGHTENING"
                              };
    private string ChosenWord;
    

    // Start is called before the first frame update
    private void Awake()
    {
        ChooseWord();
        Debug.Log("Test");
    }


    void Start()
    {
        SoundManager.PlaySound(SoundManager.SoundType.PhaseOne);
        Debug.Log("ok");
    }


    public void Reset()
    {
        Transform GameOver = EndScreenPrefab.Find("GameOverScreen");
        Transform YouWin = EndScreenPrefab.Find("YouWinScreen");
        if (Lose == true)
        {
            GameOver.gameObject.SetActive(false);
            Lose = false;
        }
        if (Win == true)
        {
            YouWin.gameObject.SetActive(false);
            Win = false;
        }
     
        strike = 0;
        for (int i = 1; i <= 11; i++)
        {
            Transform HangmanStrike = HangmanPrefab.Find($"Hangman{i}");
            HangmanStrike.gameObject.SetActive(false);
        }
        
        WordBox.gameObject.SetActive(true);
        GuessBox.gameObject.SetActive(true);
        SoundManager.PlaySound(SoundManager.SoundType.PhaseOne);
        word = "";
        ChooseWord();
    }

    public void ReadStringInput(string input)
    {
        PlayerInput = input;
        Debug.Log(input);
        GetGuessInput();
    }


    public void GetGuessInput()
    {
        bool IsWrong = true;
        for (int i = 0; i < ChosenWord.Length; i++)
        {
            if (PlayerInput.ToUpper() == ChosenWord[i].ToString())
            {
                //word.Replace(word[i], ChosenWord[i]);
                //word[i] = ChosenWord[i];
                word = word.Remove(i, 1).Insert(i, ChosenWord[i].ToString());
                WordBox.text = word;
                IsWrong = false; 
            }
        }

        if(word == ChosenWord)
        {
            Win = true;
            if (strike >= 6)
            {
                SoundManager.StopSound(SoundManager.SoundType.PhaseTwo);
            }
            else
            {
                SoundManager.StopSound(SoundManager.SoundType.PhaseOne);
            }
            Transform YouWin = EndScreenPrefab.Find("YouWinScreen");
            YouWin.gameObject.SetActive(true);
            WordBox.gameObject.SetActive(false);
            GuessBox.gameObject.SetActive(false);
        }

        if (IsWrong == true)
        {
            strike += 1;          

            switch (strike)
            {
                case 6:
                    SoundManager.StopSound(SoundManager.SoundType.PhaseOne);
                    SoundManager.PlaySound(SoundManager.SoundType.PhaseTwo);
                    break;
                case 12:
                    Lose = true;
                    SoundManager.StopSound(SoundManager.SoundType.PhaseTwo);
                    SoundManager.PlaySound(SoundManager.SoundType.Jumpscare);
                    Transform GameOver = EndScreenPrefab.Find("GameOverScreen");
                    GameOver.gameObject.SetActive(true);
                    WordBox.gameObject.SetActive(false);
                    GuessBox.gameObject.SetActive(false);
                    break;

            }
            if (strike <= 11)
            {
                Transform HangmanStrike = HangmanPrefab.Find($"Hangman{strike}");
                HangmanStrike.gameObject.SetActive(true);
                
            }
        }
    }

    
    

    void ChooseWord()
    {
        ChosenWord = words[Range(0, words.Length)];

        
        for (int i = 0; i < ChosenWord.Length; i++)
        {
            word += "_";
        }
        WordBox.text = word;
        Debug.Log(word);
        
    }
}
