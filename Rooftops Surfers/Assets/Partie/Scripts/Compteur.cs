using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Compteur : MonoBehaviour
{
    public int score;
    public Text Text;
    public Text menuText;
    public Text Best;
    public Text menuBest;
    private static int best;
    public GameObject Chargement;
    public Joueur Chat;
    public Builder Builder;
    public static int level;
    
    private void Start()
    {
        if (best != 0) Best.text = "Meilleur score : " + best;
        else Best.text = "";
        StartCoroutine(CountRoutine());
        
        Chat.Pause = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsMenu = false;
        Text.gameObject.SetActive(true);
        Best.gameObject.SetActive(true);
    }

    IEnumerator CountRoutine()
    {
        if (stop) End();
        else if (score >= 500) LevelEnd();
        else
        {
            yield return new WaitForSeconds(0.05f);
            score++;
            Builder.Input();
            StartCoroutine(CountRoutine());
        }
    }

    public void End()
    {
        if (score + level*500 > best)
            best = score + level*500;
        level = 0;
        Chargement.SetActive(true);
        SceneManager.LoadScene("Scenes/Partie");
    }

    public void LevelEnd()
    {
        level++;
        Chargement.SetActive(true);
        SceneManager.LoadScene("Scenes/Partie");
    }

    public void Menu()
    {
        if (IsMenu)
        {
            Chat.Pause = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            IsMenu = false;
            Text.gameObject.SetActive(true);
            Best.gameObject.SetActive(true);
        }
        else
        {
            Chat.Pause = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            IsMenu = true;
            menuText.text = Text.text;
            menuBest.text = Best.text;
            Text.gameObject.SetActive(false);
            Best.gameObject.SetActive(false);
        }
    }

    public GameObject PauseMenu;
    public bool IsMenu; 
    private void Update()
    {
        Text.text = "Score : " + (score + level*500);
        if (Input.GetKeyDown(KeyCode.Escape)) Menu();
    }

    [HideInInspector] public bool stop;
}