using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour {
  [SerializeField]
  GroundCheck groundChecker;
  [SerializeField]
  float jumpForce;
  [SerializeField]
  float jumpingGravity;
  [SerializeField]
  float climbingGravity;
  [SerializeField]
  float fallingGravity;

  private Animator _anim;
  private Rigidbody2D _rb2d;
  
  private bool _jumpStarted;
  private bool _jumpCanceled;

  private void Awake() {
    _anim = GetComponent<Animator>();
    _rb2d = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    bool grounded = groundChecker.IsGrounded;

    if (grounded && Input.GetButton("Jump")) {
      _jumpStarted = true;
      _jumpCanceled = false;
    }
    else if (!grounded && Input.GetButtonUp("Jump")) {
      _jumpCanceled = true;
    }

    _anim.SetBool("IsJumping", !grounded);
  }

  private void FixedUpdate() {
    if (_jumpStarted) {
      _rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      _jumpStarted = false;
    }
    else {
      ApplyGravity();
    }
  }

  private void ApplyGravity() {
    float g = 0.0f;

    if (_rb2d.velocity.y > 0) {
      if (!_jumpCanceled) {
        g = jumpingGravity;
      }
      else {
        g = climbingGravity;
      }
    }
    else { // vy <= 0
      g = fallingGravity;
    }

    _rb2d.AddForce(Vector2.down * _rb2d.mass * g, ForceMode2D.Force);
  }

}
