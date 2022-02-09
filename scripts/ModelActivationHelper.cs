using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelActivationHelper : MonoBehaviour
{

    public Animator[] prefabAnimators;
        public ParticleSystem[] rimGlow;

    public GameObject modelParent;
    
    // Start is called before the first frame update
    void Start()
    {
        modelParent.SetActive(false);
    }

    public void OnMouseDown()
    {
        // Only activates the glow animation for relevant objects
        activateModel(prefabAnimators); 
    }

    public void activateModel(Animator[] animators)
    {
        // Activates the model --> models are inactive to improve performance
        modelParent.SetActive(true);

        // Brings the activation animations
        for (int i = 0; i<animators.Length; i++)
        {
            animators[i].SetTrigger("Touch");
        }

        // Deactivates the activation panel after selection
        this.gameObject.SetActive(false);
    }

}
