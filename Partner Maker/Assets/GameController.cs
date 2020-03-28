using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Model Variables")]
    //Current Player Values
    public SkinnedMeshRenderer femaleSkinnedMeshRend;
    public Material[] femaleBodyMat;
    public Texture[] femaleTextures;
    public bool matchFemaleHeadWithBody;
    [Space]
    public SkinnedMeshRenderer maleSkinnedMeshRend;
    public Material[] maleBodyMat;
    public Texture[] maleTextures;
    public bool matchMaleHeadWithBody;
    [Space]
    public Vector2 femaleRandomLimit;
    [Header("UI Variables")]
    [Space]
    public Slider armSlider;
    public Slider legSlider , waistSlider;


    [Space]
    [SerializeField] float armThickness;
    [SerializeField] float legThickness , waistThickness;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Arm thick function
        ArmThicknessFunction();
        //Leg thick function
        LegThicknessFunction();
        //Leg thick function
        WaiseThicknessFunction();
    }

    void ArmThicknessFunction() {
        armThickness = armSlider.value * 100;
        maleSkinnedMeshRend.SetBlendShapeWeight(0 , armThickness);
    }

    void LegThicknessFunction()
    {
        legThickness = legSlider.value * 100;
        maleSkinnedMeshRend.SetBlendShapeWeight(1, legThickness);
    }

    void WaiseThicknessFunction() {
        waistThickness = waistSlider.value * 100;
        maleSkinnedMeshRend.SetBlendShapeWeight(2, waistThickness);
    }

    public void ResetLevel()
    {
        ResetFemaleBody();  
    }

    void ResetFemaleBody() {
        femaleSkinnedMeshRend.SetBlendShapeWeight(0,Random.Range(femaleRandomLimit.x , femaleRandomLimit.y));
        femaleSkinnedMeshRend.SetBlendShapeWeight(1, Random.Range(femaleRandomLimit.x, femaleRandomLimit.y));
        femaleSkinnedMeshRend.SetBlendShapeWeight(2, Random.Range(femaleRandomLimit.x, femaleRandomLimit.y));

        Texture bodyTexture = femaleTextures[Random.Range(0, femaleTextures.Length - 1)];
        femaleBodyMat[1].mainTexture = bodyTexture;

        if (matchFemaleHeadWithBody)
        {
            femaleBodyMat[0].mainTexture = bodyTexture;
        }
        else {
            Texture headTexture = femaleTextures[Random.Range(0, femaleTextures.Length - 1)];
            do
            {
                headTexture = femaleTextures[Random.Range(0, femaleTextures.Length - 1)];
            } while (headTexture == bodyTexture);

            femaleBodyMat[0].mainTexture = headTexture;
        }
    }
}
