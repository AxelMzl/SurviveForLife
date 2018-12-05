using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float rotation_z;

    public float speed = 1.8f;
    public float speedSprint = 3f;
    private float speedRun;

    private GameObject healHUD;
    private HealthBar healBar;
    private Rigidbody2D rbody;

    private Vector2 input; //vector input

    public float offset = 0.0f;
    // Use this for initialization
    void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        healHUD = GameObject.Find("HealthSlider");
        healBar = (HealthBar)healHUD.GetComponent(typeof(HealthBar));
    }

    void Update()
    {
        GetInputMouvement();
    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(input.x * speed, input.y * speed);
        Mouse();
    }

    void GetInputMouvement()
    {
        if (Input.GetButton("Sprint"))
            speedRun = speedSprint;
        else
            speedRun = speed;

        input = Vector2.zero;   //set vector input to 0
        input.x = Input.GetAxisRaw("Horizontal") * speedRun;
        input.y = Input.GetAxisRaw("Vertical") * speedRun;
    }

    public void Mouse() //rotate camera
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "cube")
        {
            //Destroy(col.gameObject);
            healBar.TakeDamage(50);

            if (healBar.currentHealth <= 0)
                GameObject.Find("ObjectPlayer").SetActive(false);
                
        }
    }

}
