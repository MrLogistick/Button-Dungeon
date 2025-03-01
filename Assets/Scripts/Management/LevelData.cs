using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static int level = 0;

    public static void SetLevel(int newLevel) {
        level = newLevel;
    }

    public static void IncrementLevel() {
        level++;
    }
}