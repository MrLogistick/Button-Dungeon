using UnityEngine;

public class GasMask : MonoBehaviour
{
    [SerializeField] ButtonPress sectionMaster;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.GetComponent<Health>().hasMask = true;
            sectionMaster.ResetPosition();
            sectionMaster.NextLevelSection();
            Destroy(gameObject);
        }
    }
}