using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Common;

namespace Lean.Touch        // We need this to access Lean.touch scripts
{ 

public class modelController : MonoBehaviour
{
    // Game objects with appropriate scripts
    public GameObject mainCam;
        public GameObject targetParent;

        public float oldObjectScale;
            public float currObjectScale;
    
    // Start is called before the first frame update
    void Start()
    {
        // setToPan();
    }
        // Update function to prevent accidental object scaling to 0
        public void FixedUpdate()
        {
            // Keeps track of current scale
            currObjectScale = targetParent.transform.localScale.x;

            // Sets the new scale to the old scale variable if greater than 0.1
            if (currObjectScale > 0.1)
            {
                oldObjectScale = currObjectScale;
            }

                // Otherwise we reset it to the last recorded scale above 0.1
                else { targetParent.transform.localScale = new Vector3(oldObjectScale, oldObjectScale, oldObjectScale); }
        }


        // Functions for changing scripts and parameters       
        public void togglePan()
        {
            if (!mainCam.GetComponent<LeanDragCamera>().enabled)
            {
                mainCam.GetComponent<LeanDragCamera>().enabled = true;
            }

            else { mainCam.GetComponent<LeanDragCamera>().enabled = false; }
        }

            public void toggleRotate()
            {
                if (!targetParent.GetComponent<LeanTwistRotate>().enabled)
                {
                targetParent.GetComponent<LeanTwistRotate>().enabled = true;
                }

                else { targetParent.GetComponent<LeanTwistRotate>().enabled = false; }
            }

            public void toggleZoom()
            {
                if (!targetParent.GetComponent<LeanPinchScale>().enabled)
                {
                    targetParent.GetComponent<LeanPinchScale>().enabled = true;
                }

                else { targetParent.GetComponent<LeanPinchScale>().enabled = false; }
            }


        // These are the deprecated functions for switching model controls
        public void setToPan()
        {
            mainCam.GetComponent<LeanDragCamera>().enabled = true;
                targetParent.GetComponent<LeanTwistRotate>().enabled = false;
                targetParent.GetComponent<LeanPinchScale>().enabled = false;
        }

        public void setToZoom()
        {
            mainCam.GetComponent<LeanDragCamera>().enabled = false;
                targetParent.GetComponent<LeanTwistRotate>().enabled = false;
                targetParent.GetComponent<LeanPinchScale>().enabled = true;
        }

        public void setToRotate()
        {
            mainCam.GetComponent<LeanDragCamera>().enabled = false;
                targetParent.GetComponent<LeanTwistRotate>().enabled = true;
                targetParent.GetComponent<LeanPinchScale>().enabled = false;
        }

}

}
