using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private static UIController instance;

    public PlayerMovement player;
    public static int PlayerHealth { get; private set; }
    public static int SteamCollected { get; private set; }

    public static bool isGamePaused;
    public float sliderProcentPerSteamPoint = 0.1f;
    public Image[] healthImages;
    public Slider steamSlider;

    public GameObject playerUI;
    public GameObject menuUI;
    public GameObject pauseUI;

    public Sprite fullHealthSprite;
    public Sprite emptyHealthSprite;

    private void Start()
    {
        playerUI.SetActive(false);
        menuUI.SetActive(true);
        pauseUI.SetActive(false);
    }
    public static UIController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<UIController>();
        }
        return instance;
    }
    private void UpdatePlayerHealth()
    {
        throw new System.NotImplementedException();
    }
    private void UpdateSteamCollected()
    {
        throw new System.NotImplementedException();
    }
    private void DisplayHealth()
    {
        foreach (var image in healthImages)
        {
            //image.enabled = false;
            image.sprite = emptyHealthSprite;
        }
        for (int i = 0; i < PlayerHealth && i < healthImages.Length; i++)
        {
            //healthImages[i].enabled = true;
            healthImages[i].sprite = fullHealthSprite;
        }
    }
    private void DisplaySteamSlider()
    {
        steamSlider.value = Mathf.Clamp01(SteamCollected * sliderProcentPerSteamPoint);
    }
    public void StartGame()
    {
        playerUI.SetActive(true);
        menuUI.SetActive(false);
        pauseUI.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    private void Update()
    {
        if(!menuUI.activeSelf)
        {
            if (InputController.Pause)
            {
                Pause();
            }
            UpdatePlayerHealth();
            UpdateSteamCollected();
            DisplayHealth();
            DisplaySteamSlider();
        }
    }
    public void Pause()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1f;
            AudioManager.GetInstance().ChangeVolume("LevelTheme", 1f);
            pauseUI.SetActive(false);
            isGamePaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            AudioManager.GetInstance().ChangeVolume("LevelTheme", 0.5f);
            pauseUI.SetActive(true);
            isGamePaused = true;
        }
    }
}
