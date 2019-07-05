using UnityEngine;

public class FloatTowardPlayer : MonoBehaviour {
  [SerializeField]
  float floatForce;

  private Rigidbody2D _rb2d;
  private GameObject _player;

  private void Awake() {
    _rb2d = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    if (_player == null) {
      _player = GameObject.FindWithTag("Player");
    }
  }

  private void FixedUpdate() {
    if (_player != null) {
      Vector2 dir = (_player.transform.position - transform.position).normalized;
      _rb2d.AddForce(dir * floatForce, ForceMode2D.Force);
    }
  }

}
