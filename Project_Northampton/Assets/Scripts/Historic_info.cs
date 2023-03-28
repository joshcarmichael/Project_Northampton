using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Historic_info : MonoBehaviour
{
    public GameObject Player;
    public GameObject UITextCanvas;
    public GameObject PlayerArmature;
    public GameObject HistroicTiggerBox;
   
    private void Start()
    {
        ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UITextCanvas.SetActive(true);
            PlayerArmature.SetActive(false);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
            StartCoroutine("func");
           
        }    
    }

   public void ExitTrigger()
    {
       
        
    }

    IEnumerator func()
    {
        Debug.Log("Hello");
        yield return new WaitForSecondsRealtime(4); //Wait 1 second
        HistroicTiggerBox.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
