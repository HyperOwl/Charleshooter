﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private PlayerWeapons playerweapons;
    
    [SerializeField]
    private TextMeshProUGUI shieldText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI gameoverScore;
    [SerializeField]
    private GameObject runtimeGUI;
    [SerializeField]
    private GameObject gameoverUI;

    public int score = 0;
    public byte transparency = 100;
    private Color32 shieldON;
    private Color32 reloading;
    private Color32 ready;
    private Color32 dead;
    private void Start()
    {
        shieldON = new Color32(37, 202, 255, transparency);
        reloading = new Color32(255, 199, 37, transparency);
        ready =  new Color32(156, 255, 37, transparency);
        dead = new Color32(255, 75, 50, transparency);
        runtimeGUI.SetActive(true);
        gameoverUI.SetActive(false);
    }
    private void Update () {
        switch (playerweapons.shield)
        {
            case PlayerWeapons.WeaponState.Active:
                shieldText.text = "Shield Active";
                shieldText.faceColor = shieldON;
                break;
            case PlayerWeapons.WeaponState.Ready:
                shieldText.text = "Shield Ready";
                shieldText.faceColor = ready;
                break;
            case PlayerWeapons.WeaponState.Reloading:
                shieldText.text = "Shield Charging";
                shieldText.faceColor = reloading;
                break;
            default:
                shieldText.text = "DATA SEQUENCE CORRUPTED";
                shieldText.faceColor = dead;
                break;
        }
        scoreText.text = score.ToString();

	}
    public void GameOver()
    {
        gameoverUI.SetActive(true);
        runtimeGUI.SetActive(false);
        gameoverScore.text = score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
