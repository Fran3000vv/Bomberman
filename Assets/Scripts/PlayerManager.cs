using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector2[] positions;
    private void Start() {
        positions=new Vector2[4];
        positions[0] = new Vector2(-6f,5f);
        positions[1] = new Vector2(6f,5f);
        positions[2] = new Vector2(-6f,-5f);
        positions[3] = new Vector2(6f,-5f);
    }
}
