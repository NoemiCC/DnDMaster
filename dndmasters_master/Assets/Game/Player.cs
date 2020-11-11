using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    int points = 0;
    public int maxPoints = 5;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.position = mousePos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Point") {
            Destroy(collision.gameObject);
            points++;

            if (points >= maxPoints) {
                SceneManager.LoadScene("Victory");
            }

        } else if (collision.gameObject.tag == "Bad") {
            SceneManager.LoadScene("Over");
        }
    }

}
