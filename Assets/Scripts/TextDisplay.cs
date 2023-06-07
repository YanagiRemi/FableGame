using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    private Text textComponent;
    public GameObject logStairs;
    public GameObject bucket;
    public Sprite bucketWithWater;
    public GameObject woodenBridge1;
    public GameObject woodenBridge2;
    // Start is called before the first frame update
    void Start()
    {
        textComponent=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!logStairs.activeSelf){
            textComponent.text="ヒント:家の左側に階段を設置しましょう";
        }else if(bucket.GetComponent<SpriteRenderer>().sprite!=bucketWithWater){
            textComponent.text="ヒント:バケツに水を汲みましょう";
        }else if(!woodenBridge1.activeSelf || !woodenBridge2.activeSelf){
            textComponent.text="ヒント:家と家の間を渡れる橋を作りましょう";
        }
    }
}
