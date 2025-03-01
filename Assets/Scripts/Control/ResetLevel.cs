using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    float unpressedPosition;
    float pressedPosition;

    [SerializeField] GameObject[] itemsToReset;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            
        }
    }
}