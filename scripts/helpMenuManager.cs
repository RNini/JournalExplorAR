using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class helpMenuManager : MonoBehaviour
{
    // Variables for UI elements
    public Button[] interactionButtons;             // Help panel buttons

    public GameObject helpPanel;                    // Help panel, containing all content
        public TextMeshProUGUI headerTMP;                // Header text object

        [TextArea]
        public string[] headerText;                     // Text array for switching out content
            public string tempHeader;                       // Temp variable for holding switch-out text
    
        public TextMeshProUGUI instructionsTMP;         // Instructions text object

        [TextArea]
        public string[] instructionsText;               // Text array for switching out content
            public string tempInstructions;                       // Temp variable for holding switch-out text

    // Image sequence-driven variables
    public Animator helperGraphic;                  // Animator where tutorial animations will be displayed
        public string[] graphicTriggers;                // Used for changing graphics
        public string tempTrigger;

        public Animator headerAnimator;                 // Animator for fading text in and out
        public Animator textAnimator;                   // Ibid
        public Animator graphicCover;

    // Video Player variables
    public VideoClip[] helperClips;                 // Helper clips
        public GameObject helperPlayer;                 // Gameobject that plays helper animations

    public int currentPanel = 0;                    // Index used to keep track of current panel


    // Start is called before the first frame update
    void Start()
    {
        changeButtonState(0);
            changePanel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeButtonState(int panelIndex)
    {
        
        for (int i = 0; i < interactionButtons.Length; i++)
        {
            // Deactivates the previous button when at the beginning of navigation
            if (i == panelIndex) { interactionButtons[i].interactable = false; }
            
                // Activates the other buttons
                else { interactionButtons[i].interactable = true; }
        }

        currentPanel = panelIndex;
    }

    // Functions for changing panel information
    public void changePanel(int panelIndex)
    {
        // Cache our text to be assigned with animation states
        tempHeader = headerText[panelIndex];
            tempInstructions = instructionsText[panelIndex];
            tempTrigger = graphicTriggers[panelIndex];
        
        // Start fade sequence for appropriate UI elements
        textAnimator.SetTrigger("ChangeContent");
            headerAnimator.SetTrigger("ChangeContent");
            graphicCover.SetTrigger("ChangeContent");

        // Push panelIndex to set button states
        changeButtonState(panelIndex);
    }

        // We will trigger this through animation events to insure content shows after animations
        public void changeContents()
        {
            // Updates the panel content
            headerTMP.text = tempHeader;
                instructionsTMP.text = tempInstructions;

        // helperGraphic.SetTrigger(tempTrigger);
        helperPlayer.GetComponent<VideoPlayer>().clip = helperClips[currentPanel];
            helperPlayer.GetComponent<VideoPlayer>().Play();
        }


    // Functions for controlling panel display
    public void showPanel()
    {
        helpPanel.GetComponent<Animator>().Play("Activate");
    }

        public void hidePanel()
        {
            helpPanel.GetComponent<Animator>().Play("Deactivate");
        }

}
