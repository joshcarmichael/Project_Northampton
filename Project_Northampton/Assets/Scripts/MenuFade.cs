using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup MyUIGroup;
    [SerializeField] private bool FadeIn = false;
    [SerializeField] private bool FadeOut = false;
   
    public GameObject PostPro;

    public void Start()
    {
        FadeIn = true;
    }
    public void ShowUI()
    {
        FadeIn = true;
    }

    public void HideUI()
    {
        FadeIn = false;
    }
    private void Update()
    {
        if(FadeIn)
        {
            if(MyUIGroup.alpha<1)
            {
                
                MyUIGroup.alpha += Time.deltaTime;
                PostPro.SetActive(true);
                if (MyUIGroup.alpha>=1)
                {
                    FadeIn = false;
                  
                }
                StartCoroutine("func");
            }
        }

        if (FadeOut)
        {
            if (MyUIGroup.alpha > 0)
            {
               
                MyUIGroup.alpha -= Time.deltaTime;
                PostPro.SetActive(false);
                if (MyUIGroup.alpha == 0)
                {
                    FadeOut = false;
                    Destroy(gameObject);
                   
                }
            }
        }
    }

    IEnumerator func()
    {
        
        yield return new WaitForSecondsRealtime(10); //Wait 1 second
        FadeOut = true;
       
    }
}
