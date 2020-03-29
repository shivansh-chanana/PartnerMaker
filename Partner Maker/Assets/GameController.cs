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
    [Space]
    public SkinnedMeshRenderer maleSkinnedMeshRend;
    public Material[] maleBodyMat;
    public Texture[] maleTextures;
    [Space]
    public SkinnedMeshRenderer Female_MTCSkinRend , Male_MTCSkinRend;
    public Material[] MTCMat;

    public GameObject female_MTC , male_MTC;
    public Vector2 modelRandomLimit;
    public bool matchCustomerHeadWithBody;
    public bool MTCMatchHeadWithBody;

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
        //Customer Model
        int randomGender = 0;//Random.Range(0,2);
        //Female gender
        if(randomGender == 0)
            ResetModel(femaleSkinnedMeshRend , femaleTextures , femaleBodyMat , true);
        else //Male gender
            ResetModel(maleSkinnedMeshRend, maleTextures, maleBodyMat, true);


        //Model to create
        randomGender = Random.Range(0, 2);
        //Female gender
        if (randomGender == 0)
        {
            ResetModel(Female_MTCSkinRend, femaleTextures, MTCMat, true);
            female_MTC.SetActive(true);
            male_MTC.SetActive(false);
        }
        else
        {//male gender
            ResetModel(Male_MTCSkinRend, maleTextures, MTCMat, true);
            female_MTC.SetActive(false);
            male_MTC.SetActive(true);
        }
    }

    void ResetModel(SkinnedMeshRenderer skinnedMeshRenderer , Texture[] modelTextures , Material[] modelMaterials , bool isMatchHead) {
        skinnedMeshRenderer.SetBlendShapeWeight(0,Random.Range(modelRandomLimit.x , modelRandomLimit.y));
        skinnedMeshRenderer.SetBlendShapeWeight(1, Random.Range(modelRandomLimit.x, modelRandomLimit.y));
        skinnedMeshRenderer.SetBlendShapeWeight(2, Random.Range(modelRandomLimit.x, modelRandomLimit.y));

        Texture bodyTexture = modelTextures[Random.Range(0, modelTextures.Length - 1)];
        modelMaterials[1].mainTexture = bodyTexture;

        if (isMatchHead)
        {
            modelMaterials[0].mainTexture = bodyTexture;
        }
        else {
            Texture headTexture = modelTextures[Random.Range(0, modelTextures.Length - 1)];
            do
            {
                headTexture = modelTextures[Random.Range(0, modelTextures.Length - 1)];
            } while (headTexture == bodyTexture);

            modelMaterials[0].mainTexture = headTexture;
        }
    }
}
