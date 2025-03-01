using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] Animator transition;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition() {
        transition.SetTrigger("LoadNew");
        LevelData.IncrementLevel();
        yield return new WaitForSeconds(1f);
        print($"Loading Level {LevelData.level + 1}");
        SceneManager.LoadScene(LevelData.level);
    }
}