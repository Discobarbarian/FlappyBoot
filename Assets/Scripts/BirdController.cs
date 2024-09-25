using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class BirdController : MonoBehaviour {
    [SerializeField] private float _upForce = 200f;
    private bool _isDead = false;
    private Rigidbody2D _rb2d;
    private Animator _anim;

    void Start() {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update() {
        if (!_isDead) {
            if (Input.GetMouseButtonDown(0)) {
                _rb2d.velocity = Vector2.zero;
                _rb2d.AddForce(new Vector2(0, _upForce));
                _anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D() {
        _rb2d.velocity = Vector2.zero;
        _isDead = true;
        _anim.SetTrigger("Die");
        GameController.Instance.BirdDied();
    }
}
