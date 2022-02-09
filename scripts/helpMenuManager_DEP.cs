using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpMenuManager_DEP : MonoBehaviour
{
    // Variables for handling button changes
    public Button[] interactionButtons;

    public GameObject controlsPanel;
        public GameObject[] helpPanels;

    public int menuIndex;
        public int[] panelPos;

    // Start is called before the first frame update
    void Start()
    {
        changeButtonState();
        showPanels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeButtonState()
    {
        // Deactivates the previous button when at the beginning of navigation
        if (menuIndex == 0) { interactionButtons[0].enabled = false; }
            else { interactionButtons[0].enabled = true;  }

        // Deactivates the next button when at the end of navigation
        if (menuIndex == 4) { interactionButtons[2].enabled = false; }
            else { interactionButtons[2].enabled = true; }

    }

    public void previousPanel()
    {        

            for (int i = 0; i < helpPanels.Length; i++)
            {
                if (i >= menuIndex - 1)
                {                  
                    // Triggers animation to previous position
                    helpPanels[i].GetComponent<Animator>().SetTrigger("PreviousSlide");
                }

                else
                {
                    // We don't trigger any animation for that panel
                }
                
            }

            menuIndex--;

            changeButtonState();

    }

    public void nextPanel()
    {
        // We only do things if we aren't at the end of the stack
        if (menuIndex != 4)
        {

            for (int i = 0; i < helpPanels.Length; i++)
            {
                if (i >= menuIndex)
                {
                    // Triggers animation to previous position
                    helpPanels[i].GetComponent<Animator>().SetTrigger("NextSlide");
                }

                else
                {
                    // We don't trigger any animation for that panel
                }

            }

            menuIndex++;

            changeButtonState();
        }

    }

    public void hidePanels()
    {
        for (int i = 0; i < helpPanels.Length; i++)
        {
            if (i > menuIndex - 1)
            {
                int currPos = i - menuIndex;

                // Triggers hide animation by activating two trigger states
                helpPanels[i].GetComponent<Animator>().SetTrigger("Hide");
                    helpPanels[i].GetComponent<Animator>().SetTrigger("Position"+currPos);
            }

            else
            {
                // We don't trigger any animation for that panel
            }

        }

        // Reset the menu index
        menuIndex = 0;

        // Deacctivate all the interaction buttons
        for (int i = 0; i < interactionButtons.Length; i++)
        {
            interactionButtons[i].enabled = false;
        }

        controlsPanel.GetComponent<Animator>().Play("Deactivate");
    }

    public void showPanels()
    {
        controlsPanel.GetComponent<Animator>().Play("Activate");
        
        for (int i = 0; i < helpPanels.Length; i++)
        {
            int currPos = i + 1;

            helpPanels[i].GetComponent<Animator>().SetTrigger("Open" + currPos);
        }

        // Activate the close and next buttons
        interactionButtons[1].enabled = true;
            interactionButtons[2].enabled = true;

    }
}
