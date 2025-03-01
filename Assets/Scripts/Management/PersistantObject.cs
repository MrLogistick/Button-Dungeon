using UnityEngine;
using System.Collections.Generic;

public class PersistentObject : MonoBehaviour
{
    private static HashSet<string> existingObjects = new HashSet<string>();

    void Awake()
    {
        string objID = gameObject.name; // Use name as an identifier (or another unique property)

        if (existingObjects.Contains(objID))
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            existingObjects.Add(objID);
            DontDestroyOnLoad(gameObject);
        }
    }
}