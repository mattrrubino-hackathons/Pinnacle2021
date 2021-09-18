using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class HandTracking : MonoBehaviour
{
    [SerializeField] float confidenceThreshold = 0.9f;
    [SerializeField] int bufferFrames = 10;
    MLHandTracking.HandKeyPose[] gestures = new MLHandTracking.HandKeyPose[2];
    InstructionManager im;
    int rightClosedCount = 0;
    int leftClosedCount = 0;

    void Start()
    {
        im = FindObjectOfType<InstructionManager>();

        MLHandTracking.Start();

        gestures[0] = MLHandTracking.HandKeyPose.Fist;
        gestures[1] = MLHandTracking.HandKeyPose.Finger;

        MLHandTracking.KeyPoseManager.EnableKeyPoses(gestures, true, false);
    }

    void OnDestroy()
    {
        MLHandTracking.Stop();
    }

    void Update()
    {
        if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.Fist))
        {
            if (leftClosedCount == 0)
            {
                OnLeftClosed();
            }
            leftClosedCount = bufferFrames;
        }
        else if (leftClosedCount > 0)
        {
            leftClosedCount--;
        }

        if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.Fist))
        {
            if (rightClosedCount == 0)
            {
                OnRightClosed();
            }
            rightClosedCount = bufferFrames;
        }
        else if (rightClosedCount > 0)
        {
            rightClosedCount--;
        }
    }

    bool GetGesture(MLHandTracking.Hand hand, MLHandTracking.HandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type && hand.HandKeyPoseConfidence > confidenceThreshold)
            {
                return true;
            }
        }
        return false;
    }

    public void OnRightClosed()
    {
        Instruction instruction = im.GetInstruction();
        instruction?.AnimationForward();
    }

    public void OnLeftClosed()
    {
        Instruction instruction = im.GetInstruction();
        instruction?.AnimationBackward();
    }
}
