using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//public float speed;
	public Text countText;
	public Text winText;
    public Vector3 spherePos;// = new Vector3(22.87f, -0.35f, -21.9f);
    public Vector3 offset = new Vector3(0.0f, 3.0f, 0.0f);
    private Rigidbody rb;
	private int count;
    public GameObject[] gameObjects;

    // Use this for initialization
    void Start () {
        gameObjects = GameObject.FindGameObjectsWithTag("Pick Up");
        rb = GetComponent<Rigidbody>();
        spherePos = rb.position;
		count = 0;
		setCountText ();
		winText.text = "";
	}

	//when player object touches trigger collider (other)
	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject); //destroys object that causes trigger
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
		if (other.gameObject.CompareTag ("Cylinder")) {
            rb.transform.position = spherePos + offset;
            activateObjects();
            count = 0;
            setCountText();

		}
        if (other.gameObject.CompareTag ("Win Zone")) {
            GameObject.Destroy (gameObject);
            countText.text = "YOU WON";
            Time.timeScale = 0;

            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
	}

	void setCountText(){
		countText.text = "Score: " + count.ToString ();
		if (count >= 10) {
			winText.text = "Great Score!!";
		}

	}
		
	void update(){
	}

    public void activateObjects()
    {
        foreach (GameObject go in gameObjects)
        {
            if (!go.activeInHierarchy)
            {
                go.SetActive(true);
            }
        }
    }
}
