using UnityEngine;

public class DADGameManager : MonoBehaviour
{
    public GameObject droppableObject;
    public GameObject circle;

    public static int Score = 0;
    public static int Level = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Vector2 offset = new Vector2(10, 0);
        // int up = 1;

        // for (int i = 0; i < Level; i++) {
        //     Vector2 spawnPos = new Vector2(offset.x, offset.y + Level * i * up);
        //     Instantiate(droppableObject, spawnPos, Quaternion.identity);
        //     up *= -1;
        // }
    }
}
