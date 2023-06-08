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
    public bool brickHint=false;
    public float waitTime=2.0f;
    public BurnStrawHouse BurnStrawHouse;
    public bool strawHint=false;
    public bool woodHint=false;
    public WoodHouse woodHouse;
    public BurnStrawHouse burnStrawHouse;

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
        }else if(!chimney.isWatering&&chimney.isBurning){
            textComponent.text="ヒント:ブタが仕掛けた煙突の中の熱い鍋をどうにかしたいな。。";
        }else if(chimney.isWatering){
            textComponent.text="煙突の中に水を入れている";
        }else if(!chimney.isBurning && !chimney.hasEnterdBrickHouse){
            textComponent.text="ヒント:煙突に入ろう";
        }else if(!brickHint&&chimney.hasEnterdBrickHouse){
            textComponent.text="ヒント:藁のブタが出てきた";
            StartCoroutine(Wait1());
        }else if(!logBridge.activeSelf && !ax.activeSelf){
            textComponent.text="ヒント:川の上に橋を作って渡ろう。丸太で作れそうだ";
        }else if(!ax.activeSelf){
            textComponent.text="ヒント:木に縛り付けられたオノのロープを切ろう";
        }else if(!woodhouse.isBrokenHouse){
            textComponent.text="ヒント:オノで木の家のドアを壊そう";
        }else if(!woodHouse.hasEnteredWoodHouse&&woodhouse.isBrokenHouse){
            textComponent.text="ヒント:木の家に入ろう";
        }else if(!woodHint&&woodHouse.hasEnteredWoodHouse){
            textComponent.text="ヒント:木のブタが出てきた";
            StartCoroutine(Wait2());
        }else if(!brick.activeSelf){
            textComponent.text="ヒント:レンガの家にヒビが入っている部分があるね。ハンマーで壊そう";
        }else if(nabe.GetComponent<SpriteRenderer>().sprite!=fireNabe){
            textComponent.text="ヒント:藁の家は火をつけて壊そう。火は石と鉄で起こせそうだ。ナベは鉄製だ。";
        }else if(!burnStrawHouse.hasBurnedStrawHouse&&!burnStrawHouse.isStrawBurning){
            textComponent.text="ヒント:ナベの火を藁の家に引火させよう。";
        }else if(burnStrawHouse.isStrawBurning){
            textComponent.text="藁が燃えている。";
        }else if(!strawHint){
            textComponent.text="三匹のブタが出てきた";
            StartCoroutine(Wait3());
        }
    }
    IEnumerator Wait1(){
        yield return new WaitForSeconds(waitTime);
        brickHint=true;
    }

    IEnumerator Wait2(){
        yield return new WaitForSeconds(waitTime);
        woodHint=true;
    }

    IEnumerator Wait3(){
        yield return new WaitForSeconds(waitTime);
        strawHint=true;
    }
}
