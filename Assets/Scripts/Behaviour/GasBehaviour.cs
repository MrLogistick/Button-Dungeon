using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GasBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float damagePerSecond;

    Coroutine damageRoutine;

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            damageRoutine = StartCoroutine(DealDamage(other.gameObject));
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            StopCoroutine(damageRoutine);
            damageRoutine = null;
        }
    }

    IEnumerator DealDamage(GameObject target) {
        while (!target.GetComponent<Health>().hasMask) {
            target.GetComponent<Health>().LoseMaxHealth(damagePerSecond);
            yield return new WaitForSeconds(1);
        }
    }
}