using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private int c = 0;
    public Text texto;
    public Text wi;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(move*speed);
    }
    void Update()
    {
        if (c == 12 && Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            c++;
            texto.text = "puntuacion: " + c;
            if (c == 12)
                wi.text = "You Win!";
        }
    }
}
