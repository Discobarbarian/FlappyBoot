using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RepeatingBackground : MonoBehaviour {
    private BoxCollider2D _groundCollider;
    private float _groundColliderLength;

    void Start() {
        _groundCollider = GetComponent<BoxCollider2D>();
        _groundColliderLength = _groundCollider.size.x * _groundCollider.transform.lossyScale.x;
    }

    void Update() {
        if (transform.position.x < -_groundColliderLength) {
            RepositionBackground();
        }
    }

    void RepositionBackground() {
        Vector2 offset = new Vector2(_groundColliderLength * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
