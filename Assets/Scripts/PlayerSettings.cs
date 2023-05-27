using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPreferences
{
    public KeyCode player1UpKey;
    public KeyCode player1DownKey;
    public KeyCode player1LeftKey;
    public KeyCode player1RightKey;
    public KeyCode player1BombKey;

    public KeyCode player2UpKey;
    public KeyCode player2DownKey;
    public KeyCode player2LeftKey;
    public KeyCode player2RightKey;
    public KeyCode player2BombKey;
}

public class PlayerPreferencesManager : MonoBehaviour
{
    public static PlayerPreferencesManager instance;

    public PlayerPreferences player1Preferences;
    public PlayerPreferences player2Preferences;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerPreferences()
    {
        string player1Json = JsonUtility.ToJson(player1Preferences);
        PlayerPrefs.SetString("player1Preferences", player1Json);

        string player2Json = JsonUtility.ToJson(player2Preferences);
        PlayerPrefs.SetString("player2Preferences", player2Json);

        PlayerPrefs.Save();
    }

    public void LoadPlayerPreferences()
    {
        string player1Json = PlayerPrefs.GetString("player1Preferences");
        if (!string.IsNullOrEmpty(player1Json))
        {
            player1Preferences = JsonUtility.FromJson<PlayerPreferences>(player1Json);
        }
        else
        {
            player1Preferences = new PlayerPreferences();
        }

        string player2Json = PlayerPrefs.GetString("player2Preferences");
        if (!string.IsNullOrEmpty(player2Json))
        {
            player2Preferences = JsonUtility.FromJson<PlayerPreferences>(player2Json);
        }
        else
        {
            player2Preferences = new PlayerPreferences();
        }
    }
}
