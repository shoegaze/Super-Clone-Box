using UnityEngine;

public class MarchForward : MonoBehaviour {
  [SerializeField]
  WallCheck wallChecker;
  [SerializeField]
  float speed;
  [SerializeField]
  float angrySpeed;
  
  private Animator _anim;
  private Rigidbody2D _rb2d;
  private bool _isBlocked;
  private bool _isAngry = false;

  private void Awake() {
    _anim = GetComponent<Animator>();
    _rb2d = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    _isAngry = _anim.GetBool("IsAngry");
    _isBlocked = wallChecker.IsBlocked;
  }

  private void FixedUpdate() {
    if (_isBlocked) {
      TurnFace(transform.localScale.x < 0);
      _isBlocked = false;
    }

    March();
  }

  private void TurnFace(bool faceRight) {
    float sx = (faceRight)? +1.0f : -1.0f;

    transform.localScale = new Vector2(sx, 1.0f);
  }

  private void March() {
    var s = _isAngry? angrySpeed : speed;

    _rb2d.velocity = new Vector2(
      transform.localScale.x * s,
      _rb2d.velocity.y
    );
  }

}
