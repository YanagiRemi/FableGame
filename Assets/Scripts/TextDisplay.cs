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
    public GameObject woodenBridge2;
    public Chimney chimney;
    public GameObject ax;
    public WoodHouse woodhouse;
    public GameObject brick;
    public GameObject nabe;
    public Sprite fireNabe;
    public GameObject logBridge;
    // Start is called before the first frame update
    void Start()
    {
        textComponent=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!logStairs.activeSelf&&chimney.isBurning){
            textComponent.text="ヒント:家の左側に階段を設置しよう";
        }else if(bucket.GetComponent<SpriteRenderer>().sprite!=bucketWithWater && chimney.isBurning){
            textComponent.text="ヒント:バケツに水を汲もう";
        }else if(!woodenBridge2.activeSelf){
            textComponent.text="ヒント:家と家の間を渡れる橋を作ろう。木の家の屋根の上に使えそうなものがあるね";
        }else if(chimney.isBurning){
            textComponent.text="ヒント:ブタが仕掛けた煙突の中の熱い鍋をどうにかしたいな。。";
        }else if(!logBridge.activeSelf && !ax.activeSelf){
            textComponent.text="ヒント:川の上に橋を作って渡ろう。丸太で作れそうだ";
        }else if(!ax.activeSelf){
            textComponent.text="ヒント:木に縛り付けられたオノのロープを切ろう";
        }else if(!woodhouse.isBrokenHouse){
            textComponent.text="ヒント:オノで木の家のドアを壊して木の家に入ろう";
        }else if(!brick.activeSelf){
            textComponent.text="ヒント:レンガの家にヒビが入っている部分があるね。ハンマーで壊そう";
        }else if(nabe.GetComponent<SpriteRenderer>().sprite!=fireNabe){
            textComponent.text="ヒント:藁の家は火をつけて壊そう。火は石と鉄で起こせそうだ。";
        }
    }
}
