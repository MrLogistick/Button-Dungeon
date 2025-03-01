using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] float unpressedPosition = 0.75f;
    [SerializeField] GameObject levelObject;
    int currentLevelSection = 0;

    public void ResetPosition() {
        transform.localPosition = new Vector2(0, unpressedPosition);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            transform.localPosition = Vector3.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            NextLevelSection();
        }
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q)) {
            NextLevelSection();
            ResetPosition();
        }
    }

    public void NextLevelSection() {
        Transform additive = levelObject.transform.GetChild(0);
        Transform temporary = levelObject.transform.GetChild(1);

        additive.GetChild(currentLevelSection).gameObject.SetActive(true);
        temporary.GetChild(currentLevelSection).gameObject.SetActive(false);
        currentLevelSection++;
        print("Part " + currentLevelSection + " Executed");
    }
}