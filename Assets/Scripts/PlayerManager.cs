using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    Vector2[] positions;
    Sprite[] walkSprites;
    Sprite[] deathSprites;
    public GameObject playerPrefab;
    private GameObject[] players;

    private void Start() {
        positions=new Vector2[4];
        positions[0] = new Vector2(-6f,5f);
        positions[1] = new Vector2(6f,-5f);
        positions[2] = new Vector2(6f,5f);
        positions[3] = new Vector2(-6f,-5f);
        Debug.Log(SharedData.playersMode);
        int a=0;
        players=new GameObject[SharedData.playersMode];
        foreach (string col in SharedData.playerColors)
        {
            LocalSettings settings=FindObjectOfType<SettingsManager>().GetConfiguration(a);
            GameObject player=Instantiate(playerPrefab,positions[a],Quaternion.identity);
            walkSprites = Resources.LoadAll<Sprite>("Player"+col+"Walk");
            deathSprites = Resources.LoadAll<Sprite>("Player"+col+"Death");
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=walkSprites[0];
            player.transform.GetChild(0).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[0];
            player.transform.GetChild(0).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 0, 4).ToArray();
            player.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite=walkSprites[4];
            player.transform.GetChild(1).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[4];
            player.transform.GetChild(1).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 4, 4).ToArray();
            player.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=walkSprites[8];
            player.transform.GetChild(2).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[8];
            player.transform.GetChild(2).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 8, 4).ToArray();
            player.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite=walkSprites[12];
            player.transform.GetChild(3).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[12];
            player.transform.GetChild(3).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 12, 4).ToArray();
            player.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite=deathSprites[0];
            player.transform.GetChild(4).GetComponent<AnimatedSpriteRenderer>().idleSprite=deathSprites[0];
            player.transform.GetChild(4).GetComponent<AnimatedSpriteRenderer>().animationSprites=deathSprites;
            player.GetComponent<BombController>().destructibleTiles=GameObject.Find("Destructibles").GetComponent<Tilemap>();
            player.GetComponent<BombController>().inputKey=settings.bombKey;
            MovementController movementController=player.GetComponent<MovementController>();
            movementController.inputUp=settings.upKey;
            movementController.inputDown=settings.downKey;
            movementController.inputLeft=settings.leftKey;
            movementController.inputRight=settings.rightKey;
            players[a++]=player;
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().players=players;
    }
}
