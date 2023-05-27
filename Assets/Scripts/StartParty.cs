using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartParty : MonoBehaviour
{
    public void SceneChange()
    {
        SharedData.playersMode = UnityEngine.Random.Range(2,5);
        string[] ola=new string[]{"White","Black","Red","Blue"};
        Array.Resize(ref ola,SharedData.playersMode);
        SharedData.playerColors=ola;

        SceneManager.LoadScene("Bomberman");
    }
}
