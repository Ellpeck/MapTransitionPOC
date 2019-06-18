using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    public TransitionData data;
    public Transform goalPosition;

    private void OnTriggerEnter2D(Collider2D other) {
        TransitionManager.Instance.Transition(this.data);
    }

}