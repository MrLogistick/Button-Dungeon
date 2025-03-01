using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI msg;

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start() {
        int randomizer = Random.Range(0, 4);

        switch (randomizer) {
            case 0:
                msg.text = "Great escape job ;)";
                break;

            case 1:
                msg.text = "Neurotoxins are bad you know";
                break;
            
            case 2:
                msg.text = "Sorry to say, but you're dead";
                break;
            
            case 3:
                msg.text = "Only had to press 'The Button' several more times";
                break;
        }
    }
}