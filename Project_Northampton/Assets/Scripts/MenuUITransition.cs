using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MenuUITransition : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamrea;
    // Start is called before the first frame update
   public void Start()
    {
        currentCamrea.Priority++;
    }

   public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamrea.Priority-- ;
        currentCamrea = target;
        currentCamrea.Priority++;
    }
}
