using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTriggerManager : MonoBehaviour
{
    public GameObject helpPanel;

    public Animator helperAnimator;
    
    public void changeContents()
    {
        helpPanel.GetComponent<helpMenuManager>().changeContents();
    }

    public void showLegend()
    {
        helperAnimator.SetTrigger("ShowLegend");
    }

    public void hideOptions()
    {
        helperAnimator.Play("Deactivate");
    }
}
