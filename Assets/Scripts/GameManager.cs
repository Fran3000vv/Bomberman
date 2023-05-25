using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public void CheckWinState(){
        int aliveCount=0;
        foreach (GameObject player in players)
        {
            if(player.activeSelf){
                aliveCount++;
            }
        }
        if(aliveCount<=1){
            Invoke(nameof(NewRound),10f);
        }
    }

    public void NewRound(){
        Debug.Log("Nueva Ronda Comienza");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
