/*==============================================================================
Copyright (c) 2019 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    //------------Begin Sound----------
    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;

    //function to stop all sounds
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    //function to play sound
    void playSound(string ss)
    {
        clipTarget = (AudioClip)Resources.Load(ss);
        soundTarget.clip = clipTarget;
        soundTarget.loop = false;
        soundTarget.playOnAwake = false;
        soundTarget.Play();
    }

    //-----------End Sound------------



    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        //Register / add the AudioSource as object
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();

    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + 
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
            //Play Sound, IF detect an target

            if (mTrackableBehaviour.TrackableName == "pag8")
            {
                playSound("sounds/Narrador Pag1");
            }

            if (mTrackableBehaviour.TrackableName == "pag9")
            {
                playSound("sounds/Narrador Pag2");
            }
            if (mTrackableBehaviour.TrackableName == "pag10")
            {
                playSound("sounds/pag10");
            }

            if (mTrackableBehaviour.TrackableName == "pag11")
            {
                playSound("sounds/pag11");
            }
            if (mTrackableBehaviour.TrackableName == "pag12")
            {
                playSound("sounds/pag12");
            }
            if (mTrackableBehaviour.TrackableName == "pag13")
            {
                playSound("sounds/pag13");
            }

            if (mTrackableBehaviour.TrackableName == "pag14")
            {
                playSound("sounds/pag14");
            }
            if (mTrackableBehaviour.TrackableName == "pag15")
            {
                playSound("sounds/pag15");
            }

            if (mTrackableBehaviour.TrackableName == "pag16")
            {
                playSound("sounds/pag16");
            }
            if (mTrackableBehaviour.TrackableName == "pag17")
            {
                playSound("sounds/pag17");
            }

            if (mTrackableBehaviour.TrackableName == "pag18")
            {
                playSound("sounds/pag18");
            }
            if (mTrackableBehaviour.TrackableName == "pag19")
            {
                playSound("sounds/pag19");
            }
            if (mTrackableBehaviour.TrackableName == "pag20")
            {
                playSound("sounds/pag20");
            }

            if (mTrackableBehaviour.TrackableName == "pag21")
            {
                playSound("sounds/pag21");
            }
            if (mTrackableBehaviour.TrackableName == "pag22")
            {
                playSound("sounds/pag22");
            }

            if (mTrackableBehaviour.TrackableName == "pag23")
            {
                playSound("sounds/pag23");
            }
            if (mTrackableBehaviour.TrackableName == "pag24")
            {
                playSound("sounds/pag24");
            }
            if (mTrackableBehaviour.TrackableName == "pag25")
            {
                playSound("sounds/pag25");
            }

            if (mTrackableBehaviour.TrackableName == "pag26")
            {
                playSound("sounds/pag26");
            }
            if (mTrackableBehaviour.TrackableName == "pag27")
            {
                playSound("sounds/pag27");
            }
            if (mTrackableBehaviour.TrackableName == "pag28")
            {
                playSound("sounds/pag28");
            }

            if (mTrackableBehaviour.TrackableName == "pag30")
            {
                playSound("sounds/pag30");
            }

            if (mTrackableBehaviour.TrackableName == "pag31")
            {
                playSound("sounds/pag31");
            }
            if (mTrackableBehaviour.TrackableName == "pag32")
            {
                playSound("sounds/pag32");
            }

            if (mTrackableBehaviour.TrackableName == "pag33")
            {
                playSound("sounds/pag32");
            }

        }
    }


    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
            //Stop All Sounds if Target Lost
            StopAllAudio();

        }

    }

    #endregion // PROTECTED_METHODS
}
