using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] ButtonPress sectionMaster;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.GetComponent<PlayerController>().hasJetpack = true;
            sectionMaster.ResetPosition();
            sectionMaster.NextLevelSection();
            Destroy(gameObject);
        }
    }
}