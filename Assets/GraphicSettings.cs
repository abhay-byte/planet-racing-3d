using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using CI.QuickSave;
using SaveSystem;

public class GraphicSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle depthOfFieldPPE;
    public Toggle bloomPPE;
    public Toggle lensDistortionPPE;
    public Toggle motionBlurPPE;
    public Toggle chromaticAberrationBlurPPE;
    public Toggle vignettePPE;
    public Toggle colourAdjustmentPPE;
    public Toggle toneMappingPPE;
    public Toggle liftGammaGainPPE;
    public Toggle filmGrainPPE;

    public GameObject DepthOfFieldPPE;
    public GameObject BloomPPE;
    public GameObject LensDistortionPPE;
    public GameObject MotionBlurPPE;
    public GameObject ChromaticAberrationBlurPPE;
    public GameObject VignettePPE;
    public GameObject ColourAdjustmentPPE;
    public GameObject ToneMappingPPE;
    public GameObject LiftGammaGainPPE;
    public GameObject FilmGrainPPE;

    public Button graphicHigh;
    public Button graphicMedium;
    public Button graphicLow;

    public Dropdown resolutionDropdown;

    Cryptography cryptography = new Cryptography("Rey@2626");

    public int depthOfFieldPPEValue;
    public int bloomPPEValue;
    public int lensDistortionPPEValue;
    public int motionBlurPPEValue;
    public int chromaticAberrationBlurPPEValue;
    public int vignettePPEValue;
    public int colourAdjustmentPPEValue;
    public int toneMappingPPEValue;
    public int liftGammaGainPPEValue;
    public int filmGrainPPEValue;
    public int resolutionDropdownValue;

    //public GameObject Environment;
    public RenderPipelineAsset Low;
    public RenderPipelineAsset Medium;
    public RenderPipelineAsset High;
    public RenderPipelineAsset Menu;
    public CanvasScaler UI;
    public Text GraphicPU;
    public Text ApiUsed;
    public string currentSettings;
    public int value;
    public void pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public string graphicVendor;
    public string apiCurrentlyInUse;
    public string gpuName;
    public int ram;
    public int vRam;
    public double GpuScore;
    void Start()
    {
            graphicVendor = SystemInfo.graphicsDeviceVendor;
            apiCurrentlyInUse = SystemInfo.graphicsDeviceType.ToString();
            ram = SystemInfo.graphicsMemorySize;
            vRam = SystemInfo.systemMemorySize;
            gpuName = SystemInfo.graphicsDeviceName;
            var PhoneData = new Dictionary<string, double>
            {
                {"Adreno (TM) 640", 69.73800018310547},{
                "Adreno (TM) 506", 10.356000015735626},{
                "Adreno (TM) 650" , 76.362001247406},{
                "Mali-G72 MP3", 15.239999842643737},{
                "Mali-G78", 61.47000137329101},{
                "Mali-G51", 13.955999865531922},{
                "Adreno (TM) 509", 13.72199987411499},{
                "PowerVR Rogue GE8320", 10.518000118732452},{
                "Adreno (TM) 618", 30.12399963378906},{
                "Adreno (TM) 620", 33.45599950790405},{
                "Mali-T830", 9.311999895572662},{
                "Mali-T760", 10.344000070095062},{
                "Adreno (TM) 612", 16.019999742507935},{
                "Adreno (TM) 512", 25.230000014305116},{
                "Adreno (TM) 505", 11.838000512123108},{
                "Mali-G72", 16.061999917030334},{
                "Mali-G71", 21.491999888420104},{
                "Mali-T720", 7.48199990272522},{
                "Mali-G76", 20.285999579429628},{
                "Adreno (TM) 610", 14.652000274658203},{
                "Mali-G52", 16.1880003118515},{
                "Mali-T860", 9.318000147342682},{
                "Adreno (TM) 630", 53.86199953079224},{
                "Adreno (TM) 660", 101.63400032043457},{
                "Mali-G77", 24.534000549316406},{
                "Adreno (TM) 530", 30.264000191688538},{
                "Adreno (TM) 330", 9.594000055789948},{
                "Mali-G52 MC2", 15.900000157356262},{
                "Adreno (TM) 540", 32.2140003490448},{
                "Mali-G76 MC4", 30.726000394821167},{
                "Adreno (TM) 619", 30.726000394821167},{
                "Mali-G57 MC2", 17.531999802589418},{
                "PowerVR Rogue GE8300", 9.042000153064727},{
                "Adreno (TM) 420", 12.617999939918517},{
                "Adreno (TM) 616", 23.423999891281127},{
                "Mali-T880", 9.636000058650971},{
                "Mali-400 MP", 8.249999964237213},{
                "Adreno (TM) 405", 9.090000085830688},{
                "Adreno (TM) 430", 17.346000216007234},{
                "Mali-G57", 25.193999576568604},{
                "Adreno (TM) 510", 14.346000180244445},{
                "Mali-G57 MC3", 17.748000111579895},{
                "PowerVR Rogue GE8100", 7.745999886989593},{
                "Mali-G57 MC4", 21.08400023460388},{
                "Mali-450 MP", 8.778000168800354},{
                "PowerVR Rogue GM9446", 16.157999782562257},{
                "Adreno (TM) 306", 7.48199990272522},{
                "Adreno (TM) 308", 7.794000163078308},{
                "Adreno (TM) 508", 11.981999859809875},{
                "Intel(R) HD Graphics 520", 53.88399999999999},{
                "Adreno (TM) 642", 50.885998764038085},{
                "Mali-G77 MC9", 25.644000434875487},{
                "PowerVR Rogue GE8322", 9.636000058650971},{
                "Mali-T624", 8.316000137329102},{
                "Mali-T820", 8.652000052928924},{
                "Adreno (TM) 304", 7.415999965667725},{
                "virgl", 38.201999530792236},{
                "Mali-G31", 9.528000075817108},{
                "Adreno (TM) 320", 8.520000178813934},{
                "Mesa DRI Intel(R) UHD Graphics 600 (Geminilake 2x6) ", 17.51400046348572},{
                "Mali-G68 MC4", 23.783999676704408},{
                "PowerVR Rogue G6200", 8.448000011444092},{
                "Android Emulator OpenGL ES Translator (GeForce RTX 2060/PCIe/SSE2)", 46.740000443458555},{
                "PowerVR SGX 544MP", 15.299999957084657},{
                "Intel(R) UHD Graphics 605", 40.299999957084657},{
                "NVIDIA Tegra", 32.07599970817566},{
                "Adreno (TM) 615", 20.466000394821165},{
                "Mesa DRI Intel(R) HD Graphics 400 (Braswell) ", 10.290000078678132},{
                "Adreno (TM) 504", 10.032000153064727},{
                "PowerVR Rogue GX6250", 8.459999785423278},{
                "Adreno (TM) 642L", 44.91599982261658},{
                "Mali-T628", 9.227999975681305},{
                "Mesa DRI Intel(R) HD Graphics (Comet Lake 3x8 GT2) ", 49.65599959373474},{
                "Mali-G71 MP2", 10.158000268936156},{
                "Adreno (TM) 418", 10.062000102996826},{
                "Mali-G52 MC1", 11.321999845504761},{
                "Intel(R) HD Graphics for Atom(TM) x5/x7", 11.124000034332276},{
                "Adreno (TM) 305", 7.415999965667725},{
                "FD618", 27.51000062942505},{
                "PowerVR Rogue G6430", 8.699999771118165}
            };

        //Screen.SetResolution(960, 540, true, 150);
                 //resolutionDropdown.value = 2;
/*                 Application.targetFrameRate = 150; */
        //lowSettings(); */
        try
        {
            try
            {
                GpuScore =  PhoneData[gpuName];
                if(GpuScore>35.0)
                {
                    graphicHigh.interactable = true;
                    graphicMedium.interactable = true;
                    depthOfFieldPPE.interactable = true;
                    bloomPPE.interactable = true;
                    lensDistortionPPE.interactable = true;
                    motionBlurPPE.interactable = true;
                    chromaticAberrationBlurPPE.interactable = true;
                    vignettePPE.interactable = true;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = true;
                    resolutionDropdown.interactable = true;
                }
                else if(GpuScore<=35.0 && GpuScore>30.0)
                {
                    graphicHigh.interactable = false;
                    graphicMedium.interactable = true;
                    depthOfFieldPPE.interactable = false;
                    bloomPPE.interactable = true;
                    lensDistortionPPE.interactable = true;
                    motionBlurPPE.interactable = false;
                    chromaticAberrationBlurPPE.interactable = true;
                    vignettePPE.interactable = true;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = true;
                    resolutionDropdown.interactable = true;
                }
                else if(GpuScore<=30.0 && GpuScore>25.0)
                {
                    graphicHigh.interactable = false;
                    graphicMedium.interactable = true;
                    depthOfFieldPPE.interactable = false;
                    bloomPPE.interactable = false;
                    lensDistortionPPE.interactable = true;
                    motionBlurPPE.interactable = false;
                    chromaticAberrationBlurPPE.interactable = true;
                    vignettePPE.interactable = true;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = true;
                    resolutionDropdown.interactable = true;
                }
                else if(GpuScore<=25.0 && GpuScore>20.0)
                {
                    graphicHigh.interactable = false;
                    graphicMedium.interactable = true;
                    depthOfFieldPPE.interactable = false;
                    bloomPPE.interactable = false;
                    lensDistortionPPE.interactable = true;
                    motionBlurPPE.interactable = false;
                    chromaticAberrationBlurPPE.interactable = true;
                    vignettePPE.interactable = true;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = false;
                    resolutionDropdown.interactable = true;
                }
                else if(GpuScore<=20.0 && GpuScore>16.0)
                {
                    graphicHigh.interactable = false;
                    graphicMedium.interactable = false;
                    depthOfFieldPPE.interactable = false;
                    bloomPPE.interactable = false;
                    lensDistortionPPE.interactable = false;
                    motionBlurPPE.interactable = false;
                    chromaticAberrationBlurPPE.interactable = false;
                    vignettePPE.interactable = true;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = false;
                    resolutionDropdown.interactable = false;
                }
                else if(GpuScore<=16.0)
                {
                    graphicHigh.interactable = false;
                    graphicMedium.interactable = true;
                    depthOfFieldPPE.interactable = false;
                    bloomPPE.interactable = false;
                    lensDistortionPPE.interactable = false;
                    motionBlurPPE.interactable = false;
                    chromaticAberrationBlurPPE.interactable = false;
                    vignettePPE.interactable = false;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = false;
                    resolutionDropdown.interactable = false;
                    //resolutionDropdownValue = 0; 
                }
                else
                {
                    graphicHigh.interactable = false;
                    graphicMedium.interactable = true;
                    depthOfFieldPPE.interactable = false;
                    bloomPPE.interactable = false;
                    lensDistortionPPE.interactable = false;
                    motionBlurPPE.interactable = false;
                    chromaticAberrationBlurPPE.interactable = false;
                    vignettePPE.interactable = false;
                    colourAdjustmentPPE.interactable = true;
                    toneMappingPPE.interactable = true;
                    liftGammaGainPPE.interactable = true;
                    filmGrainPPE.interactable = false;
                    //resolutionDropdown.interactable = false; 
                    //resolutionDropdownValue = 2;                    
                }

                if (graphicVendor != "Qualcomm")
                {
                    depthOfFieldPPEValue = 0;
                    depthOfFieldPPE.interactable = false;
                }
            }
            catch (System.Exception Error2)
            {
                Debug.Log(Error2);
            }
            QuickSaveReader.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Read<string>(cryptography.Encrypt("currentSettings"), (r) => { currentSettings = cryptography.Decrypt<string>(r); })
                .Read<string>(cryptography.Encrypt("depthOfFieldPPE"), (r) => { depthOfFieldPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("bloomPPE"), (r) => { bloomPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("lensDistortionPPE"), (r) => { lensDistortionPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("motionBlurPPE"), (r) => { motionBlurPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("chromaticAberrationBlurPPE"), (r) => { chromaticAberrationBlurPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("vignettePPE"), (r) => { vignettePPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("colourAdjustmentPPE"), (r) => { colourAdjustmentPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("toneMappingPPE"), (r) => { toneMappingPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("liftGammaGainPPE"), (r) => { liftGammaGainPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("filmGrainPPE"), (r) => { filmGrainPPEValue = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("resolutionDropdown"), (r) => { resolutionDropdownValue = cryptography.Decrypt<int>(r); });


            setGraphics();

        }
        catch (System.Exception Error)
        {



            try
            {
                GpuScore =  PhoneData[gpuName];
                if(GpuScore<=16.0)
                {
                    depthOfFieldPPEValue = 0;
                    bloomPPEValue = 0;
                    motionBlurPPEValue = 0;
                    chromaticAberrationBlurPPEValue = 0;
                    vignettePPEValue = 0;
                    resolutionDropdownValue = 2;
                    lensDistortionPPEValue = 0;
                    colourAdjustmentPPEValue = 1;
                    toneMappingPPEValue = 1;
                    liftGammaGainPPEValue = 1;
                    filmGrainPPEValue = 0;
                    currentSettings = "medium";                    
                }
                if(GpuScore<=20.0 && GpuScore>16.0)
                {
                    depthOfFieldPPEValue = 0;
                    bloomPPEValue = 0;
                    motionBlurPPEValue = 0;
                    chromaticAberrationBlurPPEValue = 0;
                    vignettePPEValue = 1;
                    resolutionDropdownValue = 3;
                    lensDistortionPPEValue = 0;
                    colourAdjustmentPPEValue = 1;
                    toneMappingPPEValue = 1;
                    liftGammaGainPPEValue = 1;
                    filmGrainPPEValue = 0;
                    currentSettings = "medium";                    
                }
                if(GpuScore<=25.0 && GpuScore>20.0)
                {
                    depthOfFieldPPEValue = 0;
                    bloomPPEValue = 0;
                    motionBlurPPEValue = 0;
                    chromaticAberrationBlurPPEValue = 1;
                    vignettePPEValue = 1;
                    resolutionDropdownValue = 4;
                    lensDistortionPPEValue = 1;
                    colourAdjustmentPPEValue = 1;
                    toneMappingPPEValue = 1;
                    liftGammaGainPPEValue = 1;
                    filmGrainPPEValue = 0;
                    currentSettings = "low";                    
                }

                if(GpuScore>25.0)
                {
                    depthOfFieldPPEValue = 0;
                    bloomPPEValue = 0;
                    motionBlurPPEValue = 0;
                    chromaticAberrationBlurPPEValue = 1;
                    vignettePPEValue = 1;
                    resolutionDropdownValue = 4;
                    lensDistortionPPEValue = 1;
                    colourAdjustmentPPEValue = 1;
                    toneMappingPPEValue = 1;
                    liftGammaGainPPEValue = 1;
                    filmGrainPPEValue = 0;
                    currentSettings = "medium";                    
                }
                if (graphicVendor != "Qualcomm")
                {
                    depthOfFieldPPEValue = 0;
                }
            }
            catch (System.Exception Error1)
            {
                depthOfFieldPPEValue = 0;
                bloomPPEValue = 0;
                motionBlurPPEValue = 0;
                chromaticAberrationBlurPPEValue = 0;
                vignettePPEValue = 1;
                resolutionDropdownValue = 4;
                lensDistortionPPEValue = 1;
                colourAdjustmentPPEValue = 1;
                toneMappingPPEValue = 1;
                liftGammaGainPPEValue = 1;
                filmGrainPPEValue = 0;
                currentSettings = "medium";  
            }
            setGraphics();
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("depthOfFieldPPE"), cryptography.Encrypt(depthOfFieldPPEValue))
                .Write(cryptography.Encrypt("bloomPPE"), cryptography.Encrypt(bloomPPEValue))
                .Write(cryptography.Encrypt("lensDistortionPPE"), cryptography.Encrypt(lensDistortionPPEValue))
                .Write(cryptography.Encrypt("motionBlurPPE"), cryptography.Encrypt(motionBlurPPEValue))
                .Write(cryptography.Encrypt("chromaticAberrationBlurPPE"), cryptography.Encrypt(chromaticAberrationBlurPPEValue))
                .Write(cryptography.Encrypt("vignettePPE"), cryptography.Encrypt(vignettePPEValue))
                .Write(cryptography.Encrypt("colourAdjustmentPPE"), cryptography.Encrypt(colourAdjustmentPPEValue))
                .Write(cryptography.Encrypt("toneMappingPPE"), cryptography.Encrypt(toneMappingPPEValue))
                .Write(cryptography.Encrypt("liftGammaGainPPE"), cryptography.Encrypt(liftGammaGainPPEValue))
                .Write(cryptography.Encrypt("filmGrainPPE"), cryptography.Encrypt(filmGrainPPEValue))
                .Write(cryptography.Encrypt("resolutionDropdown"), cryptography.Encrypt(resolutionDropdownValue))
                .Write(cryptography.Encrypt("currentSettings"), cryptography.Encrypt(currentSettings))
                .Commit();

            //setGraphics();
        }


    }
    public void lowSettings()
    {
        currentSettings = "low";
        GraphicsSettings.renderPipelineAsset = Low;
        QualitySettings.renderPipeline = Low;
        //resolutionDropdown.value = 2;
        Debug.Log("Changed to low graphic settings");
        QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
            .Write(cryptography.Encrypt("currentSettings"), cryptography.Encrypt(currentSettings))
            .Commit();
    }
    public void MediumSettings()
    {
        currentSettings = "medium";
        GraphicsSettings.renderPipelineAsset = Medium;
        QualitySettings.renderPipeline = Medium;
        //resolutionDropdown.value = 3;
        Debug.Log("Changed to medium graphic settings");
        QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
            .Write(cryptography.Encrypt("currentSettings"), cryptography.Encrypt(currentSettings))
            .Commit();
    }
    public void HighSettings()
    {
        currentSettings = "high";
        //resolutionDropdown.value = 4;
        GraphicsSettings.renderPipelineAsset = High;
        QualitySettings.renderPipeline = High;
        Debug.Log("Changed to high graphic settings");
        QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
            .Write(cryptography.Encrypt("currentSettings"), cryptography.Encrypt(currentSettings))
            .Commit();
    }
    public void menu()
    {
        GraphicsSettings.renderPipelineAsset = Menu;
        QualitySettings.renderPipeline = Menu;
        Debug.Log("Changed to very Menu graphic settings");
    }
    public void Lock()
    {
        QualitySettings.vSyncCount = 1;
        //Application.targetFrameRate = 30;
    }

    public void setGraphics()
    {
        resolutionDropdown.value = resolutionDropdownValue;
        if (currentSettings == "low")
        {
            lowSettings();
        }
        else if (currentSettings == "medium")
        {
            MediumSettings();
        }
        else if (currentSettings == "high")
        {
            HighSettings();
        }
        else
        {
            lowSettings();
        }

        if(depthOfFieldPPEValue==1)
        {
            depthOfFieldPPE.isOn = true;
            DepthOfFieldPPE.SetActive(true);
        }
        else
        {
            depthOfFieldPPE.isOn = false;
            DepthOfFieldPPE.SetActive(false);            
        }

        if(bloomPPEValue==1)
        {
            bloomPPE.isOn = true;
            BloomPPE.SetActive(true);
        }
        else
        {
            bloomPPE.isOn = false;
            BloomPPE.SetActive(false);            
        } 

        if(motionBlurPPEValue==1)
        {
            motionBlurPPE.isOn = true;
            MotionBlurPPE.SetActive(true);
        }
        else
        {
            motionBlurPPE.isOn = false;
            MotionBlurPPE.SetActive(false);            
        } 

        if(chromaticAberrationBlurPPEValue==1)
        {
            chromaticAberrationBlurPPE.isOn = true;
            ChromaticAberrationBlurPPE.SetActive(true);
        }
        else
        {
            chromaticAberrationBlurPPE.isOn = false;
            ChromaticAberrationBlurPPE.SetActive(false);            
        } 

        if(vignettePPEValue==1)
        {
            vignettePPE.isOn = true;
            VignettePPE.SetActive(true);
        }
        else
        {
            vignettePPE.isOn = false;
            VignettePPE.SetActive(false);            
        } 

        if(lensDistortionPPEValue==1)
        {
            lensDistortionPPE.isOn = true;
            LensDistortionPPE.SetActive(true);
        }
        else
        {
            lensDistortionPPE.isOn = false;
            LensDistortionPPE.SetActive(false);            
        } 

        if(colourAdjustmentPPEValue==1)
        {
            colourAdjustmentPPE.isOn = true;
            ColourAdjustmentPPE.SetActive(true);
        }
        else
        {
            colourAdjustmentPPE.isOn = false;
            ColourAdjustmentPPE.SetActive(false);            
        } 

        if(toneMappingPPEValue==1)
        {
            toneMappingPPE.isOn = true;
            ToneMappingPPE.SetActive(true);
        }
        else
        {
            toneMappingPPE.isOn = false;
            ToneMappingPPE.SetActive(false);            
        } 

        if(liftGammaGainPPEValue==1)
        {
            liftGammaGainPPE.isOn = true;
            LiftGammaGainPPE.SetActive(true);
        }
        else
        {
            liftGammaGainPPE.isOn = false;
            LiftGammaGainPPE.SetActive(false);            
        } 

        if(filmGrainPPEValue==1)
        {
            filmGrainPPE.isOn = true;
            FilmGrainPPE.SetActive(true);
        }
        else
        {
            filmGrainPPE.isOn = false;
            FilmGrainPPE.SetActive(false);            
        } 
    }
    public void Resolution()
    {
        //resolutionDropdown = GetComponent<Dropdown>();
        value = resolutionDropdown.value;
        resolutionDropdownValue = resolutionDropdown.value;
        if (value == 0)
        {
            //Screen.SetResolution(426, 240, true, 150);
            UI.scaleFactor = 0.168f;
            QualitySettings.resolutionScalingFixedDPIFactor = 0.222222222f;
            //Application.targetFrameRate = 150;
            Debug.Log("Resolution changed to 240p");
        }
        if (value == 1)
        {
            //Screen.SetResolution(640, 360, true, 150);
            UI.scaleFactor = 0.25f;
            QualitySettings.resolutionScalingFixedDPIFactor = 0.333333333f;
            //Application.targetFrameRate = 150;
            Debug.Log("Resolution changed to 360p");
        } 
        if (value == 2)
        {
            //Screen.SetResolution(800, 450, true, 150);
            UI.scaleFactor = 0.312f;
            QualitySettings.resolutionScalingFixedDPIFactor = 0.416666666f;
            Application.targetFrameRate = 150;
            Debug.Log("Resolution changed to 450p");
        }
        if (value == 3)
        {
            //Screen.SetResolution(960, 540, true, 150);
            UI.scaleFactor = 0.376f;
            QualitySettings.resolutionScalingFixedDPIFactor = 0.5f;
            //Application.targetFrameRate = 150;
            Debug.Log("Resolution changed to 540p");
        }
        if (value == 4)
        {
            //Screen.SetResolution(1280, 720, true, 150);
            UI.scaleFactor = 0.505f;
            QualitySettings.resolutionScalingFixedDPIFactor = 0.666666667f;
            //Application.targetFrameRate = 150;
            Debug.Log("Resolution changed to 720p");
        }
       if (value == 5)
        {
            //Screen.SetResolution(1600, 900, true, 150);
            UI.scaleFactor = 0.628f;
            QualitySettings.resolutionScalingFixedDPIFactor = 0.833333333f;
            //Application.targetFrameRate = 150;
            Debug.Log("Resolution changed to 900p");
        }
        if (value == 6)
        {
            UI.scaleFactor = 0.75f;
            //Screen.SetResolution(1920, 1080, true, 150);
            QualitySettings.resolutionScalingFixedDPIFactor = 1f;
            //Application.targetFrameRate = 30;
            Debug.Log("Resolution changed to 1080p");
        }
        QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
            .Write(cryptography.Encrypt("resolutionDropdown"), cryptography.Encrypt(resolutionDropdownValue))
            .Commit();
    }
    public void screenshot()
    {
        ScreenCapture.CaptureScreenshot("screenshot.png");
    }

    public void depthOfField()
    {
        if(depthOfFieldPPE.isOn)
        {
            depthOfFieldPPEValue = 1;
        }
        else
        {
            depthOfFieldPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("depthOfFieldPPE"), cryptography.Encrypt(depthOfFieldPPEValue))
                .Commit();   
    }

    public void bloom()
    {
        if(bloomPPE.isOn)
        {
            bloomPPEValue = 1;
        }
        else
        {
            bloomPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("bloomPPE"), cryptography.Encrypt(bloomPPEValue))
                .Commit();   
    }

    public void lensDistortion()
    {
        if(lensDistortionPPE.isOn)
        {
            lensDistortionPPEValue = 1;
        }
        else
        {
            lensDistortionPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("lensDistortionPPE"), cryptography.Encrypt(lensDistortionPPEValue))
                .Commit();   
    }

    public void motionBlur()
    {
        if(motionBlurPPE.isOn)
        {
            motionBlurPPEValue = 1;
        }
        else
        {
            motionBlurPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("motionBlurPPE"), cryptography.Encrypt(motionBlurPPEValue))
                .Commit();   
    }

    public void chromaticAberrationBlur()
    {
        if(chromaticAberrationBlurPPE.isOn)
        {
            chromaticAberrationBlurPPEValue = 1;
        }
        else
        {
            chromaticAberrationBlurPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("chromaticAberrationBlurPPE"), cryptography.Encrypt(chromaticAberrationBlurPPEValue))
                .Commit();   
    }

    public void colourAdjustment()
    {
        if(colourAdjustmentPPE.isOn)
        {
            colourAdjustmentPPEValue = 1;
        }
        else
        {
            colourAdjustmentPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("colourAdjustmentPPE"), cryptography.Encrypt(colourAdjustmentPPEValue))
                .Commit();   
    }

    public void vignette()
    {
        if(vignettePPE.isOn)
        {
            vignettePPEValue = 1;
        }
        else
        {
            vignettePPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("vignettePPE"), cryptography.Encrypt(vignettePPEValue))
                .Commit();   
    }

    public void toneMapping()
    {
        if(toneMappingPPE.isOn)
        {
            toneMappingPPEValue = 1;
        }
        else
        {
            toneMappingPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("toneMappingPPE"), cryptography.Encrypt(toneMappingPPEValue))
                .Commit();   
    }

    public void liftGammaGain()
    {
        if(liftGammaGainPPE.isOn)
        {
            liftGammaGainPPEValue = 1;
        }
        else
        {
            liftGammaGainPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("liftGammaGainPPE"), cryptography.Encrypt(liftGammaGainPPEValue))
                .Commit();   
    }

    public void filmGrain()
    {
        if(filmGrainPPE.isOn)
        {
            filmGrainPPEValue = 1;
        }
        else
        {
            filmGrainPPEValue = 0;
        }
            QuickSaveWriter.Create("PlanetRacingSettings[DonotDeleteThis]")
                .Write(cryptography.Encrypt("filmGrainPPE"), cryptography.Encrypt(filmGrainPPEValue))
                .Commit();   
    }      
}


