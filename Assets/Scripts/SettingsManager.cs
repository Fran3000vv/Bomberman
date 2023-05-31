using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void SaveConfiguration(LocalSettings settings)
    {
        string json = JsonUtility.ToJson(settings);
        string key = "controlSettings_" + settings.playerId;
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }
    public LocalSettings GetConfiguration(int playerId)
    {
        string key = "controlSettings_" + playerId;
        string json = PlayerPrefs.GetString(key);
        if (!string.IsNullOrEmpty(json))
        {
            return JsonUtility.FromJson<LocalSettings>(json);
        }
        else
        {
            LocalSettings set; 
            switch (playerId)
            {
                case 0:set=new LocalSettings(){playerId=playerId,upKey=KeyCode.W,downKey=KeyCode.S,leftKey=KeyCode.A,rightKey=KeyCode.D,bombKey=KeyCode.Space};break;
                case 1:set=new LocalSettings(){playerId=playerId,upKey=KeyCode.UpArrow,downKey=KeyCode.DownArrow,leftKey=KeyCode.LeftArrow,rightKey=KeyCode.RightArrow,bombKey=KeyCode.Return};break;
                case 2:set=new LocalSettings(){playerId=playerId,upKey=KeyCode.T,downKey=KeyCode.G,leftKey=KeyCode.F,rightKey=KeyCode.H,bombKey=KeyCode.B};break;
                default:set=new LocalSettings(){playerId=playerId,upKey=KeyCode.I,downKey=KeyCode.K,leftKey=KeyCode.J,rightKey=KeyCode.L,bombKey=KeyCode.M};break;
            }
            return set;
        }
    }
}
