using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingEra : MonoBehaviour
{
    public GameObject Cube01;
    public GameObject Cube02;
    public GameObject Cube03;
   public void DropDownFuction(int value)
    {
        if(value == 0)
        {
            Cube01.SetActive(true);
            Cube02.SetActive(false);
            Cube03.SetActive(false);
        }

        if (value == 1)
        {
            Cube01.SetActive(false);
            Cube02.SetActive(true);
            Cube03.SetActive(false);
        }

        if (value == 2)
        {
            Cube01.SetActive(false);
            Cube02.SetActive(false);
            Cube03.SetActive(true);
        }
    }
}
