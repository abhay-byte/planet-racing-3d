using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicInfo : MonoBehaviour
{
    public Image info;
    public Text InfoHead;
    public Text InfoAbout;
    public Text InfoNotSupported;
    public Sprite Home;
    public Sprite dof;
    public Sprite bloom;
    public Sprite lensDistortion;
    public Sprite motionBlur;
    public Sprite chromaticAberration;
    public Sprite vignette;
    public Sprite colorAdjustment;
    public Sprite tonemapping;
    public Sprite lLG;
    public Sprite filmgrain;

    public GraphicSettings Data;
    void Start()
    {
        //Fetch the Image from the GameObject
        //info = GetComponent<Image>();
    }
    public void Dof()
    {
        info.sprite = dof;
        InfoHead.text = "Depth of Field";
        InfoAbout.text = "The Depth Of Field component applies a depth of field effect, which simulates the focus properties of a camera lens. In real life, a camera can only focus sharply on an object at a specific distance.";
        if (!Data.depthOfFieldPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }

    }
    public void Bloom()
    {
        info.sprite = bloom;
        InfoHead.text = "Bloom";
        InfoAbout.text = "The Bloom effect creates fringes of light extending from the borders of bright areas in an image. This creates the illusion of extremely bright light overwhelming the Camera.";
        if (!Data.bloomPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void LensDistortion()
    {
        info.sprite = lensDistortion;
        InfoHead.text = "Lens Distortion";
        InfoAbout.text = "The Lens Distortion effect distorts the final rendered picture to simulate the shape of a real-world camera lens.";
        if (!Data.lensDistortionPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void MotionBlur()
    {
        info.sprite = motionBlur;
        InfoHead.text = "Motion Blur";
        InfoAbout.text = "The Motion Blur effect simulates the blur that occurs in an image when a real-world camera films objects moving faster than the camera’s exposure time. This is usually due to rapidly moving objects, or a long exposure time.";
        if (!Data.motionBlurPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void ChromaticAberration()
    {
        info.sprite = chromaticAberration;
        InfoHead.text = "Chromatic Aberration";
        InfoAbout.text = "Chromatic Aberration creates fringes of color along boundaries that separate dark and light parts of the image. It mimics the color distortion that a real-world camera produces when its lens fails to join all colors to the same point.";
        if (!Data.chromaticAberrationBlurPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void Vignette()
    {
        info.sprite = vignette;
        InfoHead.text = "Vignette";
        InfoAbout.text = "In photography, vignetting is the term for the darkening and/or desaturating towards the edges of an image compared to the center.";
        if (!Data.vignettePPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void ColorAdjustment()
    {
        info.sprite = colorAdjustment;
        InfoHead.text = "Color Adjustment";
        InfoAbout.text = "Use this effect to tweak the overall tone, brightness, and contrast of the final rendered image.";
        if (!Data.colourAdjustmentPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void Tonemapping()
    {
        info.sprite = tonemapping;
        InfoHead.text = "Tonemapping";
        InfoAbout.text = "Tonemapping is the process of remapping the HDR values of an image to a new range of values. Its most common purpose is to make an image with a low dynamic range appear to have a higher range.";
        if (!Data.toneMappingPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }    
    public void LLG()
    {
        info.sprite = lLG;
        InfoHead.text = "Lift Gamma Gain";
        InfoAbout.text = "This effect allows you to perform three-way color grading. The Lift Gamma Gain trackballs follow the ASC CDL standard.";
        if (!Data.liftGammaGainPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }
    public void Filmgrain()
    {
        info.sprite = Home;
        InfoHead.text = "Film grain";
        InfoAbout.text = "The Film Grain effect simulates the random optical texture of photographic film, usually caused by small particles being present on the physical film.";
        if (!Data.filmGrainPPE.IsInteractable())
        {
            InfoNotSupported.text = "Not supported.";
        }
        else
        {
            InfoNotSupported.text = "";
        }
    }

}
