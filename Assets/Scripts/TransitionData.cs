using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Transition Data")]
public class TransitionData : ScriptableObject {

    public SceneAsset firstScene;
    public SceneAsset secondScene;

    public SceneAsset GetOtherScene(string currScene) {
        return this.firstScene.name == currScene ? this.secondScene : this.firstScene;
    }

}