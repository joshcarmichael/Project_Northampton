using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Rendering;
public class OptionsMenu : MonoBehaviour
{
    public Toggle FullscreenTog, VsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    private int SelectedResolution;
    public TextMeshProUGUI resolutionLabel;

    //public AudioMixer theMixer;
   // public TMP_Text mastLabel, musicLabel, sfxLebel;
  //  public Slider mastSlider, musicSlider, sfxSlider;


    public RenderPipelineAsset[] QualiltyLevel;
    public TMP_Dropdown DropDown;


    // Start is called before the first frame update
    void Start()
    {
        FullscreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            VsyncTog.isOn = false;
        }
        else
        {
            VsyncTog.isOn = true;
        }
        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizotal && Screen.height == resolutions[i].Vertical)
            {
                foundRes = true;
                SelectedResolution = i;
                UpdateResLabel();
            }

        }

        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizotal = Screen.width;
            newRes.Vertical = Screen.height;
            resolutions.Add(newRes);
            SelectedResolution = resolutions.Count - 1;
            UpdateResLabel();
        }

        float vol = 0f;
     //   theMixer.GetFloat("MastVol", out vol);
       // mastSlider.value = vol;

      //  theMixer.GetFloat("MusicVol", out vol);
       // musicSlider.value = vol;

       // theMixer.GetFloat("SFXVol", out vol);
      //  sfxSlider.value = vol;

      //  mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
       // musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
      //  sfxLebel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        DropDown.value = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void ResLeft()
    {
        SelectedResolution--;
        if(SelectedResolution <0)
        {
            SelectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        SelectedResolution++;
        if(SelectedResolution> resolutions.Count - 1)
        {
            SelectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[SelectedResolution].horizotal.ToString() + "x" + resolutions[SelectedResolution].Vertical.ToString();
    }
    public void ApplyGraphics()
    {
       // Screen.fullScreen = FullscreenTog.isOn;
            if(VsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[SelectedResolution].horizotal, resolutions[SelectedResolution].Vertical, FullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
      //  mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
      //  theMixer.SetFloat("MastVol", mastSlider.value);
      //  PlayerPrefs.SetFloat("MastVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
     //   musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
      //  theMixer.SetFloat("MusicVol", musicSlider.value);
       // PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
       // sfxLebel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
       // theMixer.SetFloat("SFXVol", sfxSlider.value);
       // PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
    [System.Serializable]
    public class ResItem
    {
        public int horizotal, Vertical;
    }

   public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = QualiltyLevel[value];
    }
    
}
