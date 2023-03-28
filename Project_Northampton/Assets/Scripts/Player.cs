using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera ThirdPersonCamera;
    [SerializeField] CinemachineVirtualCamera FirstPersonCamera;
    public GameObject FPS_Dot;

  

    private void OnEnable()
    {
        CameraSwitcher.Register(ThirdPersonCamera);
        CameraSwitcher.Register(FirstPersonCamera);
        CameraSwitcher.SwitchCamera(ThirdPersonCamera);
        FPS_Dot.SetActive(false);
    }
   
    private void OnDisable()
    {
        CameraSwitcher.Unregister(ThirdPersonCamera);
        CameraSwitcher.Unregister(FirstPersonCamera);
    }


    public void UpdateCamera(CinemachineVirtualCamera target)
    {
       if(CameraSwitcher.IsActiveCamera(ThirdPersonCamera))
        {
            CameraSwitcher.SwitchCamera(FirstPersonCamera);
            FPS_Dot.SetActive(true);
        }
       else if (CameraSwitcher.IsActiveCamera(FirstPersonCamera))
        {
            CameraSwitcher.SwitchCamera(ThirdPersonCamera);
            FPS_Dot.SetActive(false);
        }
    }
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
