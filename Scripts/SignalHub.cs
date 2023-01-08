using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;

public class SignalHub : MonoBehaviour
{
    //staggered animation
    //exponent-decimal-scale
    //exponent-decimal-scale-unit
    //decimal-exponent-scale
    //decimal-exponent-scale-unit

    public bool currentProcessDone;

    public bool exponentUpAniDone;
    public bool exponentDownAniDone;
    public bool decimalRightAniDone;
    public bool decimalLeftAniDone;
    public bool scaleUpAniDone;
    public bool scaleDownAniDone;

    public bool upSignalFromHub2Exp;
    public bool upSignalFromHub2Dec;
    public bool upSignalFromExp2Dec;
    public bool upSignalFromDec2Exp;
    public bool upSignalFromExp2Scale;
    public bool upSignalFromDec2Scale;
    public bool upSignalFromScale2Unit;

    public bool downSignalFromHub2Exp;
    public bool downSignalFromHub2Dec;
    public bool downSignalFromExp2Dec;
    public bool downSignalFromDec2Exp;
    public bool downSignalFromExp2Scale;
    public bool downSignalFromDec2Scale;
    public bool downSignalFromScale2Unit;

    public bool upByExp;
    public bool upByDec;
    public bool downByExp;
    public bool downByDec;

    //for simultaneous animation
    public bool upSignalFromHub;
    public bool downSignalFromHub;
    //wrong thinking. have to seperate signals from hub to exponent/decimal/scaling
    //because the signal is set to false once it reaches the script.
    //so set another signal from hub to scaling, in addition to the staggered setting.
    public bool upSignalFromHub2Scale;
    public bool downSignalFromHub2Scale;

    public int currentWorldIndex = 16;
    public int targetWorldIndexFromPP = 16;

    public GameObject HMDInputObeject;
    HMDInputModule vrpnInput;

    public Transform decimalButton;
    public bool rightActionFromButton;
    public bool leftActionFromButton;

    public Transform exponentButton;
    public bool upActionFromButton;
    public bool downActionFromButton;

    #region declare transform of the buttons on progress panel
    public Transform PP10_Button;
    public Transform PP9_Button;
    public Transform PP8_Button;
    public Transform PP7_Button;
    public Transform PP6_Button;
    public Transform PP5_Button;
    public Transform PP4_Button;
    public Transform PP3_Button;
    public Transform PP2_Button;
    public Transform PP1_Button;
    public Transform PP0_Button;
    public Transform PPM10_Button;
    public Transform PPM9_Button;
    public Transform PPM8_Button;
    public Transform PPM7_Button;
    public Transform PPM6_Button;
    public Transform PPM5_Button;
    public Transform PPM4_Button;
    public Transform PPM3_Button;
    public Transform PPM2_Button;
    public Transform PPM1_Button;
    #endregion
    
    public bool scaleUpFromPP;
    public bool scaleDownFromPP;

    bool isSkippingWorlds;

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean up_ClickAction;
    public SteamVR_Action_Boolean down_ClickAction;

    public GameObject leftController, rightController;

    //keyboard testing
    //U:exponent up
    //D: exponent down
    //R: decimal right
    //L:decimal left


    void Start()
    {
        vrpnInput = HMDInputObeject.GetComponent<HMDInputModule>();

        currentProcessDone = true;


    }

    void Update()
    {
        
        rightActionFromButton = decimalButton.GetComponent<DecimalButton>().scaleUp;
        leftActionFromButton = decimalButton.GetComponent<DecimalButton>().scaleDown;

        upActionFromButton = exponentButton.GetComponent<ExponentButton>().scaleUp;
        downActionFromButton = exponentButton.GetComponent<ExponentButton>().scaleDown;

        // Use right controller to scale up or down, by pointing up or down
        if (up_ClickAction.GetStateDown(m_TargetSource) && (rightController.transform.rotation.x < -0.2))
        {
            upActionFromButton = true;
        }
        if (up_ClickAction.GetStateDown(m_TargetSource) && (rightController.transform.rotation.x >= 0.2))
        {
            downActionFromButton = true;
        }

        // Use left controller to scale up or down, by pointing up or down
        if (down_ClickAction.GetStateDown(m_TargetSource) && (leftController.transform.rotation.x < -0.2))
        {
            upActionFromButton = true;
        }
        if (down_ClickAction.GetStateDown(m_TargetSource) && (leftController.transform.rotation.x >= 0.2))
        {
            downActionFromButton = true;
        }

        #region get signal from progress panel
        if (PP10_Button.GetComponent<PP10_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP10_Button.GetComponent<PP10_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP9_Button.GetComponent<PP9_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP9_Button.GetComponent<PP9_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP8_Button.GetComponent<PP8_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP8_Button.GetComponent<PP8_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP7_Button.GetComponent<PP7_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP7_Button.GetComponent<PP7_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP6_Button.GetComponent<PP6_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP6_Button.GetComponent<PP6_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP5_Button.GetComponent<PP5_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP5_Button.GetComponent<PP5_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP4_Button.GetComponent<PP4_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP4_Button.GetComponent<PP4_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP3_Button.GetComponent<PP3_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP3_Button.GetComponent<PP3_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP2_Button.GetComponent<PP2_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP2_Button.GetComponent<PP2_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP1_Button.GetComponent<PP1_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP1_Button.GetComponent<PP1_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PP0_Button.GetComponent<PP0_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PP0_Button.GetComponent<PP0_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }

        if (PPM10_Button.GetComponent<PPM10_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM10_Button.GetComponent<PPM10_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM9_Button.GetComponent<PPM9_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM9_Button.GetComponent<PPM9_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM8_Button.GetComponent<PPM8_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM8_Button.GetComponent<PPM8_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM7_Button.GetComponent<PPM7_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM7_Button.GetComponent<PPM7_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM6_Button.GetComponent<PPM6_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM6_Button.GetComponent<PPM6_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM5_Button.GetComponent<PPM5_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM5_Button.GetComponent<PPM5_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM4_Button.GetComponent<PPM4_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM4_Button.GetComponent<PPM4_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM3_Button.GetComponent<PPM3_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM3_Button.GetComponent<PPM3_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM2_Button.GetComponent<PPM2_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM2_Button.GetComponent<PPM2_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        if (PPM1_Button.GetComponent<PPM1_Button>().triggerSignal)
        {
            targetWorldIndexFromPP = PPM1_Button.GetComponent<PPM1_Button>().targetWorldIndex;
            isSkippingWorlds = true;
        }
        #endregion

        if (isSkippingWorlds)
        {
            if (targetWorldIndexFromPP > currentWorldIndex)
            {
                scaleUpFromPP = true;
            }
            else if (targetWorldIndexFromPP < currentWorldIndex)
            {
                scaleDownFromPP = true;
            }
            else
            {
                isSkippingWorlds = false;
            }
        }

        //below is the simultaneous animation setting
        //action at exponent or decimal, trigger the exponent/decimal/scaling animations at the same time
        //after the all three animations are done, then trigger the possible unit change animation     

        //scale up
        if ((scaleUpFromPP || rightActionFromButton || upActionFromButton || vrpnInput.upFromButton2Exp || vrpnInput.scaleUpHandMotion2Exp || vrpnInput.upFromButton2Dec || vrpnInput.scaleUpHandMotion2Decimal || Input.GetKeyDown(KeyCode.U)) && currentProcessDone)
        {
            currentProcessDone = false;

            rightActionFromButton = false;
            scaleUpFromPP = false;

            vrpnInput.upFromButton2Exp = false;
            vrpnInput.scaleUpHandMotion2Exp = false;
            vrpnInput.upFromButton2Dec = false;
            vrpnInput.scaleUpHandMotion2Decimal = false;

            upSignalFromHub2Exp = true;
            upSignalFromHub2Dec = true;
            upSignalFromHub2Scale = true;

            upSignalFromHub = true;
           
            currentWorldIndex++;
        }
        //after all the three animations done, unit change triggered
        if (upSignalFromHub && exponentUpAniDone && decimalRightAniDone && scaleUpAniDone)
        {
            upSignalFromHub = false;

            if (IsUnitChangeWhenUp(currentWorldIndex))
            {
                upSignalFromScale2Unit = true;
                scaleUpAniDone = false;
            }
            //turn off the trigger
            else
            {
                currentProcessDone = true;

                exponentUpAniDone = false;
                exponentDownAniDone = false;
                decimalLeftAniDone = false;
                decimalRightAniDone = false;
                scaleDownAniDone = false;
                scaleUpAniDone = false;
            }
        }

        //scale down
        if ((scaleDownFromPP || leftActionFromButton || downActionFromButton || vrpnInput.downFromButton2Exp || vrpnInput.scaleDownHandMotion2Exp || vrpnInput.downFromButton2Dec || vrpnInput.scaleDownHandMotion2Decimal || Input.GetKeyDown(KeyCode.D)) && currentProcessDone)
        {

            leftActionFromButton = false;
            scaleDownFromPP = false;

            currentProcessDone = false;
            currentWorldIndex--;

            vrpnInput.downFromButton2Exp = false;
            vrpnInput.scaleDownHandMotion2Exp = false;
            vrpnInput.downFromButton2Dec = false;
            vrpnInput.scaleDownHandMotion2Decimal = false;

            downSignalFromHub2Exp = true;
            downSignalFromHub2Dec = true;
            downSignalFromHub2Scale = true;

            downSignalFromHub = true;
        }
        //after all the three animations done, unit change triggered
        if (downSignalFromHub && exponentDownAniDone && decimalLeftAniDone && scaleDownAniDone)
        {
            downSignalFromHub = false;
            if (IsUnitChangeWhenDown(currentWorldIndex))
            {
                downSignalFromScale2Unit = true;
                scaleDownAniDone = false;
            }
            //turn off the trigger
            else
            {
                currentProcessDone = true;

                exponentUpAniDone = false;
                exponentDownAniDone = false;
                decimalLeftAniDone = false;
                decimalRightAniDone = false;
                scaleDownAniDone = false;
                scaleUpAniDone = false;
            }
        }



        //below is the staggered animation setting
        //staggered animation
        //exponent-decimal-scale
        //exponent-decimal-scale-unit
        //decimal-exponent-scale
        //decimal-exponent-scale-unit

        /* start of the staggered animation
        //scale up
        //action at exponent directly      
        if ( (scaleUpFromPP || upActionFromButton || vrpnInput.upFromButton2Exp || vrpnInput.scaleUpHandMotion2Exp || Input.GetKeyDown(KeyCode.U)) &&  currentProcessDone)
        {
            currentProcessDone = false;

            upSignalFromHub2Exp = true;
            vrpnInput.upFromButton2Exp = false;
            vrpnInput.scaleUpHandMotion2Exp = false;
            upByExp = true;
            upByDec=false;
            downByExp=false;
            downByDec=false;

            currentWorldIndex++;           
        }
        //action at exponent and trigger decimal
        if (upByExp && exponentUpAniDone)
        {
            upSignalFromExp2Dec = true;
            //this aniDone variable only indicates the moment of done
            exponentUpAniDone = false;
        }
        //action at exponent and trigger decimal, and then trigger scaling
        if (upByExp && decimalRightAniDone)
        {
            upSignalFromDec2Scale = true;
            decimalRightAniDone = false;
        }
        //after scaling, unit change triggered
        if (upByExp && scaleUpAniDone)
        {
            if (IsUnitChangeWhenUp(currentWorldIndex))
            {
                upSignalFromScale2Unit = true;
                scaleUpAniDone = false;
            }
            //turn off the trigger
            else
            {                
                currentProcessDone = true;

                exponentUpAniDone = false;
                exponentDownAniDone = false;
                decimalLeftAniDone = false;
                decimalRightAniDone = false;
                scaleDownAniDone = false;
                scaleUpAniDone = false;
            }
        }

        //action at decimal directly
        if ((vrpnInput.upFromButton2Dec || vrpnInput.scaleUpHandMotion2Decimal || Input.GetKeyDown(KeyCode.R)) && currentProcessDone)
        {
            currentProcessDone = false;

            upSignalFromHub2Dec = true;
            vrpnInput.upFromButton2Dec = false;
            vrpnInput.scaleUpHandMotion2Decimal = false;
            upByDec = true; 
            upByExp = false;    
            downByExp = false;
            downByDec = false;

            currentWorldIndex++;
        }
        //action at decimal and trigger exponent
        if (upByDec && decimalRightAniDone)
        {
            upSignalFromDec2Exp = true;
            //this aniDone variable only indicates the moment of done
            decimalRightAniDone = false;
        }
        //action at decimal and trigger exponent, and then trigger scaling
        if (upByDec && exponentUpAniDone)
        {
            upSignalFromExp2Scale = true;
            exponentUpAniDone = false;
        }
        //after scaling, unit change triggered
        if (upByDec && scaleUpAniDone)
        {
            if (IsUnitChangeWhenUp(currentWorldIndex))
            {
                upSignalFromScale2Unit = true;
                scaleUpAniDone = false;
            }
            //turn off the trigger
            else
            {
                scaleUpAniDone = false;
                currentProcessDone = true;

                exponentUpAniDone = false;
                exponentDownAniDone = false;
                decimalLeftAniDone = false;
                decimalRightAniDone = false;
                scaleDownAniDone = false;
                scaleUpAniDone = false;
            }
        }

        //scale down
        //action at exponent directly
        if ((vrpnInput.downFromButton2Exp || vrpnInput.scaleDownHandMotion2Exp || Input.GetKeyDown(KeyCode.D)) && currentProcessDone)
        {
            currentProcessDone = false;

            downSignalFromHub2Exp = true;
            vrpnInput.downFromButton2Exp = false;
            vrpnInput.scaleDownHandMotion2Exp = false;
            downByExp = true;
            upByExp = false;
            upByDec = false;            
            downByDec = false;

            currentWorldIndex--;
        }
        //action at exponent and trigger decimal
        if (downByExp && exponentDownAniDone)
        {
            downSignalFromExp2Dec = true;
            //this aniDone variable only indicates the moment of done
            exponentDownAniDone = false;
        }
        //action at exponent and trigger decimal, and then trigger scaling
        if (downByExp && decimalLeftAniDone)
        {
            downSignalFromDec2Scale = true;
            decimalLeftAniDone = false;
        }
        //after scaling, unit change triggered
        if (downByExp && scaleDownAniDone)
        {
            if (IsUnitChangeWhenDown(currentWorldIndex))
            {
                downSignalFromScale2Unit = true;
                scaleDownAniDone = false;
            }
            //turn off the trigger
            else
            {
                scaleDownAniDone = false;
                currentProcessDone = true;

                exponentUpAniDone = false;
                exponentDownAniDone = false;
                decimalLeftAniDone = false;
                decimalRightAniDone = false;
                scaleDownAniDone = false;
                scaleUpAniDone = false;
            }
        }
        
        //action at decimal directly
        if ((vrpnInput.downFromButton2Dec || vrpnInput.scaleDownHandMotion2Decimal || Input.GetKeyDown(KeyCode.L)) && currentProcessDone)
        {
            currentProcessDone = false;

            downSignalFromHub2Dec = true;
            vrpnInput.downFromButton2Dec = false;
            vrpnInput.scaleDownHandMotion2Decimal = false;
            downByDec = true;
            upByExp = false;
            upByDec = false;
            downByExp = false;

            currentWorldIndex--;
        }
        //action at decimal and trigger exponent
        if (downByDec && decimalLeftAniDone)
        {
            downSignalFromDec2Exp = true;
            //this aniDone variable only indicates the moment of done
            decimalLeftAniDone = false;
        }
        //action at decimal and trigger exponent, and then trigger scaling
        if (downByDec && exponentDownAniDone)
        {
            downSignalFromExp2Scale = true;
            exponentDownAniDone = false;
        }
        //after scaling, unit change triggered
        if (downByDec && scaleDownAniDone)
        {
            if (IsUnitChangeWhenDown(currentWorldIndex))
            {
                downSignalFromScale2Unit = true;
                scaleDownAniDone = false;
            }
            //turn off the trigger
            else
            {
                scaleUpAniDone = false;
                currentProcessDone = true;

                exponentUpAniDone = false;
                exponentDownAniDone = false;
                decimalLeftAniDone = false;
                decimalRightAniDone = false;
                scaleDownAniDone = false;
                scaleUpAniDone = false;
            }
        }
        //end of the staggered animation
         */
    }

    public bool IsUnitChangeWhenUp(int currentWorldIndex)
    {
        if (currentWorldIndex % 3 == 1)
        {
            return true;
        }
        return false;
    }
    public bool IsUnitChangeWhenDown(int currentWorldIndex)
    {
        if (currentWorldIndex % 3 == 0)
        {
            return true;
        }
        return false;
    }
}
