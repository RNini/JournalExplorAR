using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject transitionPanel;

    private void Start()
    {
        transitionPanel = GameObject.Find("TransitionPanel");
    }

    public void changeToImg1()
    {
        // Changes the scene to the molecular viewer corresponding to the child object
        changeScene("3.MoleculeViewer_" + this.gameObject.transform.GetChild(0).name);
    }

        public void activateTransition()
        {
            transitionPanel.GetComponent<Animator>().Play("FadeOut");
        }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void resetScene()
    {
        // Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
