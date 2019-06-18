using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour {

    public static TransitionManager Instance;
    public TransitionData currentTransition;

    private void Awake() {
        if (Instance) {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += this.OnSceneLoaded;
    }

    public void Transition(TransitionData data) {
        this.currentTransition = data;

        var currScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(data.GetOtherScene(currScene).name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (this.currentTransition) {
            foreach (var transition in FindObjectsOfType<Transition>()) {
                if (transition.data == this.currentTransition) {
                    var player = FindObjectOfType<Player>();
                    player.transform.position = transition.goalPosition.position;
                }
            }

            this.currentTransition = null;
        }
    }

}