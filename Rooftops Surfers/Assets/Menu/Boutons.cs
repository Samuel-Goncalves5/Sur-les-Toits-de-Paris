using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boutons : MonoBehaviour
{
    public GameObject Paramètres;
    public GameObject Principal;
    public GameObject Chargement;
    [HideInInspector] static AudioManager audioManager;
    private bool fullScreen = true;
    private static bool initialisation = true;
    public bool ingamemenu;
    
    public void Start()
    {
        if (ingamemenu) return;
        if (initialisation)
        {
            Screen.fullScreen = true;
            initialisation = false;
        }
        if (!(audioManager is null)) return;
        audioManager = AudioManager.instance;
        audioManager.Play("test");
    }

    public void BStart()
    {
        Paramètres.SetActive(false);
        Principal.SetActive(false);
        Chargement.SetActive(true);
        SceneManager.LoadScene("Scenes/Partie");
    }
    
    public void BParametres()
    {
        Paramètres.SetActive(true);
        Principal.SetActive(false);
    }

    public void BSite()
    {
        Application.OpenURL("https://rooftopofworld.com/");
    }

    public void BQuitter()
    {
        Application.Quit();
    }

    public void BQuitter2()
    {
        Chargement.SetActive(true);
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void BRetour()
    {
        Paramètres.SetActive(false);
        Principal.SetActive(true);
    }

    public void SetVolume(float volume) => audioManager.UpdateVolume(volume);

    public GameObject B1;
    public GameObject B2;
    public void SetFullScreenTrue()
    {
        Screen.fullScreen = true;
        fullScreen = true;
        B1.SetActive(true);
        B2.SetActive(false);
    }
    
    public void SetFullScreenFalse()
    {
        Screen.fullScreen = false;
        fullScreen = false;
        B2.SetActive(true);
        B1.SetActive(false);
    }

    public Dropdown Dresolution;

    public void SetResolution()
    {
        switch (Dresolution.value)
        {
            case 0:
                Screen.SetResolution(1366, 768, fullScreen);
                break;
            case 1:
                Screen.SetResolution(1280,768, fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280,720, fullScreen);
                break;
            case 3:
                Screen.SetResolution(1280,600, fullScreen);
                break;
            case 4:
                Screen.SetResolution(1024,768, fullScreen);
                break;
        }
    }
}
