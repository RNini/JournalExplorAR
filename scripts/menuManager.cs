using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    // Variables for handling button changes
    public Button[] interactionButtons;
        public int[] buttonStates;

    public GameObject controlsPanel;

    public Button menuButton;
        public Button newModelButton;
        public Button closeButton;

    public int activeButton;

    // Start is called before the first frame update
    void Start()
    {
        // Assigns the changeButtonState function to each button, passing i as a parameter
        // This is necessary as we can't pass a parameter through a function when assigned via the inspector
        interactionButtons[0].onClick.AddListener(delegate { StartCoroutine(resetView()); });
            interactionButtons[1].onClick.AddListener(delegate { toggleButtonVisuals(1); });
            interactionButtons[2].onClick.AddListener(delegate { toggleButtonVisuals(2); });
            interactionButtons[3].onClick.AddListener(delegate { toggleButtonVisuals(3); });

        /* // These are the old function 
        interactionButtons[0].onClick.AddListener(delegate{ StartCoroutine(resetView()); });
                    interactionButtons[1].onClick.AddListener(delegate { changeButtonState(1); });
                    interactionButtons[2].onClick.AddListener(delegate { changeButtonState(2); });
                    interactionButtons[3].onClick.AddListener(delegate { changeButtonState(3); });
        */

        // Sets default variable/visual states
        activeButton = 1;
            interactionButtons[activeButton].GetComponent<Animator>().Play("Activate");
            // interactionButtons[activeButton].enabled = false;

        controlsPanel.GetComponent<Animator>().Play("DelayedActivate");
    }

    // Updates the button visuals for multi-select controls
    public void toggleButtonVisuals(int buttonIndex)
    {
        if (buttonStates[buttonIndex] == 1)
        {
            interactionButtons[buttonIndex].GetComponent<Animator>().Play("Deactivate");
                buttonStates[buttonIndex] = 0;
        }

        else
        {
            interactionButtons[buttonIndex].GetComponent<Animator>().Play("Activate");
            buttonStates[buttonIndex] = 1;
        }

    }

    public void buttonFunctionSwitch()
    {
        // Re-assigns the active controls according to the current button state
        if (activeButton == 0) { /*some function;*/ }
            else if ( activeButton == 1 ) { /*some function;*/ }
            else if ( activeButton == 2 ) { /*some function;*/ }
            else if ( activeButton == 3 ) { /*some function;*/ }
            else if ( activeButton == 4 ) { /*We do nothin... for now*/ }
            else if ( activeButton == 5 ) { /*some function;*/ }
    }

    public void changeButtonState(int buttonIndex)
    {

        // Updates the text on the button, which will be controlled by an animation trigger
        for (int i = 0; i < interactionButtons.Length; i++) 
        {        
            // Re-enables the previously active button and plays the deactivate animation
            if (i == activeButton)
            {
                interactionButtons[i].enabled = true;
                    interactionButtons[i].GetComponent<Animator>().Play("Deactivate");
            }                        
        }

        // Toggles off button interactability and plays the activate animation for the newly active button
        interactionButtons[buttonIndex].enabled = false;
            interactionButtons[buttonIndex].GetComponent<Animator>().Play("Activate");

        // Assigns the newly selected button as the active button
        activeButton = buttonIndex;
    }

    public IEnumerator resetView()
    {
        // Do reset functions
        interactionButtons[0].GetComponent<Animator>().Play("ActiveBlink");
            interactionButtons[0].enabled = false;

        // Allow blink animation to play for 3 seconds
        yield return new WaitForSeconds(3f);

        // Resets button to default states
        interactionButtons[0].GetComponent<Animator>().Play("Inactive");
            interactionButtons[0].enabled = true;
    }
}
