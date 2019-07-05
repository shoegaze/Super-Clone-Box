using UnityEngine;

[ExecuteInEditMode]
public class CrateSpawner : MonoBehaviour {
  [SerializeField]
  float width;
  [SerializeField]
  float height;

  private Rect _area = new Rect();

  private void Awake() {
    UpdateArea();
  }
  
  #if UNITY_EDITOR
  private void Update() {
    UpdateArea();
  }
  #endif

  private void OnDrawGizmosSelected() {
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(
      _area.center,
      _area.size
    );
  }

  private void UpdateArea() {
    _area.size = new Vector2(
      width,
      height
    );

    _area.center = new Vector2(
      transform.position.x,
      transform.position.y
    );
  }

  public Vector2 RandomPoint() {
    return new Vector2(
      Random.Range(_area.xMin, _area.xMax),
      Random.Range(_area.yMin, _area.yMax)
    );
  }

}
