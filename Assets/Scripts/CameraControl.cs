using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1; //BombCamera 
    public CinemachineVirtualCamera vcam2; //PillCamera
    public CinemachineVirtualCamera vcam3; //InstructionCamera

    public CinemachineVirtualCamera vcam4; //MenuCamera

    [SerializeField]
    GameManager gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
            vcam3.Priority = 0;
            vcam4.Priority = 0;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
            vcam3.Priority = 0;
            vcam4.Priority = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            vcam1.Priority = 0;
            vcam2.Priority = 0;
            vcam3.Priority = 1;
            vcam4.Priority = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMenu();
        }
    }

    public void GoToMenu()
    {
        vcam1.Priority = 0;
        vcam2.Priority = 0;
        vcam3.Priority = 0;
        vcam4.Priority = 1;

        gameManager.EndGame();
    }

    public void GoToGame()
    {
        vcam1.Priority = 1;
        vcam2.Priority = 0;
        vcam3.Priority = 0;
        vcam4.Priority = 0;
    }
}
