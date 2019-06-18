using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance;
    
    public float speed;
    private Rigidbody2D body;

    private void Start() {
        if (Instance) {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this);
        
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");
        this.body.velocity = new Vector2(hor, vert) * this.speed;
    }

}