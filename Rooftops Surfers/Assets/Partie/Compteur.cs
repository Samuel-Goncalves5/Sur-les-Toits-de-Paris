using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Compteur : MonoBehaviour
{
    public Translation[] Translations;
    public int score;
    public Text Text;
    public Text menuText;
    public Text Best;
    public Text menuBest;
    private static int best;
    public GameObject Chargement;
    public Joueur Chat;
    
    private void Start()
    {
        if (best != 0) Best.text = "Best score : " + best;
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
        else
        {
            yield return new WaitForSeconds(0.01f);
            score++;
            foreach (Translation t in Translations) t.Input();
            StartCoroutine(CountRoutine());
        }
    }

    public void End()
    {
        if (score > best)
            best = score;
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
        Text.text = "Score : " + score;
        if (Input.GetKeyDown(KeyCode.Escape)) Menu();
    }

    [HideInInspector] public bool stop;
}