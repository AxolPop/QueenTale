using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class cameraMovement : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public CinemachineOrbitalTransposer transposer;
    public float cameraStep = 90;
    public float time = .5f;
    public float recenterTime;
    public float recenterStep;
    bool lol = true;
    public float zoomY = 13.51f;
    public float zoomZ = -25.2f;

    public AudioSource source;

    void Awake()
    {
        transposer = virtualCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    static public bool turningCamera = false;
    public bool turningCameraEditor;

    void Update()
    {
        turningCameraEditor = turningCamera;
        if (troop.isTalking == false)
        {
            if (lol == true) 
            { 
                DOVirtual.Float(transposer.m_FollowOffset.y, transposer.m_FollowOffset.y = zoomY, 0.5f, SetCameraZoom).SetEase(Ease.OutSine);
                DOVirtual.Float(transposer.m_FollowOffset.z, transposer.m_FollowOffset.z = zoomZ, 0.5f, SetCameraZoomTwo).SetEase(Ease.OutSine);
                lol = false; 
            }

            //-12.74
            //-25.2
                if (Input.GetKey(KeyCode.E))
                {
                    turningCamera = true;
                    DOVirtual.Float(transposer.m_XAxis.Value, transposer.m_XAxis.Value + cameraStep, time, SetCameraAxis).SetEase(Ease.OutSine);
                }
                else { turningCamera = false; }
                if (Input.GetKey(KeyCode.Q))
                {
                    turningCamera = true;
                    DOVirtual.Float(transposer.m_XAxis.Value, transposer.m_XAxis.Value - cameraStep, time, SetCameraAxis).SetEase(Ease.OutSine);
                }
                else { turningCamera = false; }
                if (Input.GetKey(KeyCode.Tab) && transposer.m_XAxis.Value != playerMovement.rotationy)
                {
                    turningCamera = true;
                    DOVirtual.Float(transposer.m_XAxis.Value, transposer.m_XAxis.Value = 0, recenterTime, SetCameraAxis).SetEase(Ease.OutSine);
                }
                else { turningCamera = false; }

        }

        if (troop.isTalking == true)
        {
            DOVirtual.Float(transposer.m_FollowOffset.y, transposer.m_FollowOffset.y = 5.74f, 0.5f, SetCameraZoom).SetEase(Ease.OutSine);
            DOVirtual.Float(transposer.m_FollowOffset.z, transposer.m_FollowOffset.z = -12.74f, 0.5f, SetCameraZoomTwo).SetEase(Ease.OutSine);
            lol = true;
        }


        source.volume = PlayerPrefs.GetFloat("Mus Value");
    }

    void SetCameraAxis(float x)
    {
        transposer.m_XAxis.Value = x;
    }

    void SetCameraZoom(float z)
    {
        transposer.m_FollowOffset.y = z;
    }

    void SetCameraZoomTwo(float y)
    {
        transposer.m_FollowOffset.z = y;
    }
}
