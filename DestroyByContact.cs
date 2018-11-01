using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }


    // Use this for initialization
    void OnTriggerEnter (Collider other) {       
            if (other.tag == "Boundary")
            {
                return;
            }
            Instantiate(explosion, transform.position, transform.rotation);
            if (other.tag == "Player")
            {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            }                   
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.addScore(score);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
