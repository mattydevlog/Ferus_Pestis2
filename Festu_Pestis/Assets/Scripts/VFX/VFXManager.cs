using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class VFXManager : MonoBehaviour
{
    [Header("Required Components")]
    
    [SerializeField] Contamination_System contaminationSystem;
    [SerializeField] Material vignette;
    [SerializeField] Volume volume;

    [Header("Vignette FX")]
    

    [Header("Red Vignette Opacity")]
    [SerializeField] [Range(0, 4)] int redVignetteOpacityTriggerLevel = 0;

    bool redVignetteOpacityActive = false;
    

    
    [SerializeField] AnimationCurve vignetteOpacityCurve;
    [SerializeField] float vignetteOpacityDuration = 10;
    float timerVignetteOpacity = 0;

    [SerializeField] float vignetteOpacity = 0.6f;
    [SerializeField] float currentVignetteOpacity = 0;

    [Header("Red Vignette Intensity")]
    [SerializeField] [Range(0, 4)] int redVignetteIntensityTriggerLevel = 0;

    bool redVignetteIntensityActive = false;

    
    [SerializeField] AnimationCurve vignetteIntensityCurve;
    [SerializeField] float vignetteIntensityDuration = 10;
    float timerVignetteIntensity = 0;

    [SerializeField] float vignetteIntensity = 0.6f;
    [SerializeField] float currentVignetteIntensity = 0;


    [Header("Red Vignette Size")]
    [SerializeField] [Range(0, 4)] int redVignetteSizeTriggerLevel = 0;
    
    bool redVignetteSizeActive = false;
    
    [SerializeField] AnimationCurve vignetteSizeCurve;
    [SerializeField] float vignetteSizeDuration = 10;
    float timerVignetteSize = 0;

    [SerializeField] float vignetteSize = 8f;
    [SerializeField] float currentVignetteSize = 0;
    

    
    [Header("Post-Process")]
    DepthOfField depthOfField;
    Vignette vignettePP;
    LensDistortion lensDistortion;
    
    [Header("Vignette Black Intensity")]
    [SerializeField] [Range(0, 4)] int blackVignetteTriggerLevel = 0;
    
    bool blackVignetteActive = false;
    
    [SerializeField] AnimationCurve vignetteBlackCurve;
    [SerializeField] float vignetteBlackDuration = 10;
    float timervignetteBlack = 0;

    [SerializeField] float maxvignetteBlackIntensity = 1f;
    [SerializeField] float currentvignetteBlackIntensity = 0;
    
    [Header("Blur Amount")]
    [SerializeField] [Range(0, 4)] int blurTriggerLevel = 0;
    
    bool blurActive = false;
    
    [SerializeField] AnimationCurve blurCurve;
    [SerializeField] float blurDuration = 10;
    float timerBlur = 0;

    [SerializeField] float maxBlurAmount = 40f;
    [SerializeField] float currentBlurAmount = 1;
    
    [Header("Pulse")]
    [SerializeField] [Range(0, 4)] int pulseTriggerLevel = 0;
    
    bool pulseActive = false;
    
    
    [SerializeField] AnimationCurve pulseCurve;
    [SerializeField] float pulseDuration = 10;
    float timerPulse = 0;
    
    [SerializeField] float maxPulse = 0.2f;
    [SerializeField] float currentPulse = 0;

    private void Awake()
    {
        
    }


    private void Start()
    {

        vignette.SetFloat("_FullscreenIntensity", 0);
        vignette.SetFloat("_VignietteIntensity", 0);
        
        
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            
        }
        if (volume.profile.TryGet<Vignette>(out vignettePP))
        {
            
        }

        if (volume.profile.TryGet<LensDistortion>(out lensDistortion))
        {
            
        }
        
    }

    private void FixedUpdate()
    {
       // lensDistortion.intensity.value = Mathf.PingPong(Time.time / 3, 0.2f);
        
    }

    private void Update()
    {
        
        
        
        //Active Check
        if (!redVignetteOpacityActive)
        {
            ActivateRedVignetteOpacity();
        }
        else
        {
            VignetteFadeIn();
        }

        if (!redVignetteIntensityActive)
        {
            ActivateRedVignetteIntensity();
        }
        else
        {
            VignetteIntensityFadeIn();
        }
        
        if (!redVignetteSizeActive)
        {
            ActivateRedVignetteSize();
        }
        else
        {
            VignetteSizeFadeIn();
        }
        
        if (!blackVignetteActive)
        {
            ActivateBlackVignette();
        }
        else
        {
            VignetteBlackFadeIn();
        }
        
        if (!blurActive)
        {
            ActivateBlur();
        }
        else
        {
            BlurFadeIn();
        }
        
        if (!pulseActive)
        {
            ActivatePulse();
        }
        else
        {
            //lensDistortion.intensity.value = Mathf.PingPong(Time.time / 2, 0.2f);
            PulseFadeIn();
        }
        

    }
    //Activators
    private void ActivateRedVignetteOpacity()
    {
        switch (redVignetteOpacityTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    redVignetteOpacityActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    redVignetteOpacityActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    redVignetteOpacityActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    redVignetteOpacityActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    redVignetteOpacityActive = true;
                }

                break;
        }
    }

    private void ActivateRedVignetteIntensity()
    {
        switch (redVignetteIntensityTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    redVignetteIntensityActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    redVignetteIntensityActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    redVignetteIntensityActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    redVignetteIntensityActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    redVignetteIntensityActive = true;
                }

                break;
        }
    }

    
    
    private void ActivateRedVignetteSize()
    {
        switch (redVignetteSizeTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    redVignetteSizeActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    redVignetteSizeActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    redVignetteSizeActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    redVignetteSizeActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    redVignetteSizeActive = true;
                }

                break;
        }
    }
    
    private void ActivateBlackVignette()
    {
        switch (blackVignetteTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    blackVignetteActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    blackVignetteActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    blackVignetteActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    blackVignetteActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    blackVignetteActive = true;
                }

                break;
        }
    }
    
    private void ActivateBlur()
    {
        switch (redVignetteSizeTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    blurActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    blurActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    blurActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    blurActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    blurActive = true;
                }

                break;
        }
    }
    
    private void ActivatePulse()
    {
        switch (redVignetteSizeTriggerLevel)
        {
            case 0: //Infected

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level0)
                {
                    pulseActive = true;
                }

                break;

            case 1: //Beat 1

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level1)
                {
                    pulseActive = true;
                }

                break;

            case 2: //Beat 2

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level2)
                {
                    pulseActive = true;
                }

                break;

            case 3: //Beat 3

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level3)
                {
                    pulseActive = true;
                }

                break;

            case 4: //Full Transitioned

                if (contaminationSystem.CurrentBeats() == Contamination_System.Contamination_Beats.Level4)
                {
                    pulseActive = true;
                }

                break;
        }
    }

    private void VignetteFadeIn()
    {
        if(timerVignetteOpacity  < vignetteOpacityDuration)
        {
            timerVignetteOpacity += Time.deltaTime;

            currentVignetteOpacity = vignetteOpacity * vignetteOpacityCurve.Evaluate(timerVignetteOpacity / vignetteOpacityDuration);
            vignette.SetFloat("_FullscreenIntensity", currentVignetteOpacity);
            
        }
        
    }

     private void VignetteIntensityFadeIn()
    {
        if(timerVignetteIntensity  < vignetteIntensityDuration)
        {
            timerVignetteIntensity += Time.deltaTime;

            currentVignetteIntensity = vignetteIntensity * vignetteIntensityCurve.Evaluate(timerVignetteIntensity / vignetteIntensityDuration);
            vignette.SetFloat("_VignietteIntensity", currentVignetteIntensity);
            
        }
        
    }

    private void VignetteSizeFadeIn()
    {
        if(timerVignetteSize  < vignetteSizeDuration)
        {
            timerVignetteSize += Time.deltaTime;

            currentVignetteSize = vignetteSize * vignetteSizeCurve.Evaluate(timerVignetteSize / vignetteSizeDuration);
            vignette.SetFloat("_VignietteRadiusPower", currentVignetteSize);
        }
       
    }
    
    private void VignetteBlackFadeIn()
    {
        
        if(timervignetteBlack  < vignetteBlackDuration)
        {
            timervignetteBlack += Time.deltaTime;

            currentvignetteBlackIntensity = maxvignetteBlackIntensity * vignetteBlackCurve.Evaluate(timervignetteBlack / vignetteBlackDuration);
            vignettePP.intensity.value = currentvignetteBlackIntensity;
        }
        
    }
    
    private void BlurFadeIn()
    {
        
        if(timerBlur  < blurDuration)
        {
            timerBlur += Time.deltaTime;

            currentBlurAmount = maxBlurAmount * blurCurve.Evaluate(timerBlur / blurDuration);

            depthOfField.focalLength.value = currentBlurAmount;
        }
        
    }
    
    private void PulseFadeIn()
    {
        
        if(timerPulse  < pulseDuration)
        {
            timerPulse += Time.deltaTime;

            currentPulse = maxPulse * pulseCurve.Evaluate(timerPulse / pulseDuration);

            lensDistortion.intensity.value = currentPulse;
        }
        
    } 

 
 
}
