using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    Vector2[] positions;
    Sprite[] walkSprites;
    Sprite[] deathSprites;
    public GameObject playerPrefab;

    private void Start() {
        positions=new Vector2[4];
        positions[0] = new Vector2(-6f,5f);
        positions[1] = new Vector2(6f,-5f);
        positions[2] = new Vector2(6f,5f);
        positions[3] = new Vector2(-6f,-5f);
        Debug.Log(SharedData.playersMode);
        var a=0;
        foreach (string col in SharedData.playerColors)
        {
            GameObject player=Instantiate(playerPrefab,positions[a++],Quaternion.identity);
            walkSprites = Resources.LoadAll<Sprite>("Player"+col+"Walk");
            deathSprites = Resources.LoadAll<Sprite>("Player"+col+"Death");
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=walkSprites[0];
            player.transform.GetChild(0).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[0];
            player.transform.GetChild(0).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 0, 4).Array;
            player.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite=walkSprites[4];
            player.transform.GetChild(1).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[4];
            player.transform.GetChild(1).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 4, 4).Array;
            player.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=walkSprites[8];
            player.transform.GetChild(2).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[8];
            player.transform.GetChild(2).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 8, 4).Array;
            player.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite=walkSprites[12];
            player.transform.GetChild(3).GetComponent<AnimatedSpriteRenderer>().idleSprite=walkSprites[12];
            player.transform.GetChild(3).GetComponent<AnimatedSpriteRenderer>().animationSprites=new ArraySegment<Sprite>(walkSprites, 12, 4).Array;
            player.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite=deathSprites[0];
            player.transform.GetChild(4).GetComponent<AnimatedSpriteRenderer>().idleSprite=deathSprites[0];
            player.transform.GetChild(4).GetComponent<AnimatedSpriteRenderer>().animationSprites=deathSprites;
            player.GetComponent<BombController>().destructibleTiles=GameObject.Find("Destructibles").GetComponent<Tilemap>();
        }
    }
}
