using UnityEngine;

public class GameController : MonoBehaviour {
  //HACK
  [SerializeField]
  GameObject defaultGun;

  private ScoreKeeper _sk;

  public GameObject NextGun {
    get {
      return defaultGun; //HACK

      //if (WeaponJustUnlocked != null) {
      //  var w = WeaponJustUnlocked;
      //  WeaponJustUnlocked = null;
      //  return w;
      //}
      //else {
      //  ply.Give(Random.Select(AllWeapons));
      //}
    }
  }

  private void Awake() {
    DontDestroyOnLoad(gameObject);

    _sk = GetComponent<ScoreKeeper>();
  }

  private void Start() {
    LoadSettings();
  }

  private void LoadSettings() {
    //TODO:
    Debug.Log("Loading settings");

    _sk.HighScore = 0; //--> data.highScore
  }

  public void NotifyGameOver() {
    //TODO:
    Debug.Log("Game over!");
  }
    
}
