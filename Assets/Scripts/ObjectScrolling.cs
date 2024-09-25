using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectScrolling : MonoBehaviour {
    private Rigidbody2D _rb2d;

    void Start() {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.velocity = new Vector2(GameController.Instance.ScrollSpeed, 0);
    }

    void Update() {
        if (GameController.Instance.isGameOver) {
            _rb2d.velocity = Vector2.zero;
        }
    }
}
