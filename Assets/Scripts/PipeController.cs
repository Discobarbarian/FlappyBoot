using UnityEngine;

public class PipeController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<BirdController>() != null) {
            GameController.Instance.BirdScored();
        }
    }
}
