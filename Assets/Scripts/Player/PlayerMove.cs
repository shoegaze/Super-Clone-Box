using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMove : MonoBehaviour {
  [SerializeField]
  float speed;
  
  private Rigidbody2D _rb2d;
  private Animator _anim;

  private float _dir;
  private bool _facingRight;

  public Vector2 Direction {
    get {
      return _facingRight? Vector2.right : Vector2.left;
    }
  }

  private void OnDrawGizmos() {
    //Draw direction
    Gizmos.color = Color.red;
    Gizmos.DrawRay(
      transform.position + new Vector3(0, 0.5f, 0),
      transform.right * 0.75f
    );
  }

  private void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
    _anim = GetComponent<Animator>();
  }

  private void Update() {
    _dir = Input.GetAxisRaw("Horizontal");
    
    if (Input.GetButton("Horizontal")) {
      _facingRight = _dir > 0;
      TurnFace();

      _anim.SetBool("IsWalking", true);
    }
    else {
      _anim.SetBool("IsWalking", false);
    }
  }

  void FixedUpdate() {
    Walk();
	}

  private void TurnFace() {
    //BUG: makes jumping left smaller, while jumping right is still OK
    transform.rotation = Quaternion.Euler(
      0,
      _facingRight ? 0 : 180,
      0
    );

    //transform.localScale = new Vector2(
    //  _facingRight ? +1.0f : -1.0f,
    //  1.0f
    //);
  }

  private void Walk() {
    _rb2d.velocity = new Vector2(_dir * speed, _rb2d.velocity.y);
  }

}
