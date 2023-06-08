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
    public float waitTime=3.0f;
    public BurnStrawHouse BurnStrawHouse;
    public bool strawHint=false;
    public bool woodHint=false;
    public bool startHint=false;
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
        if(!startHint){
            textComponent.text="ヒント:まずはレンガの家の煙突に入れるようにしよう。窓からうかがった時、ブタが煙突の中に熱々の鍋を用意していたから注意が必要だ。。";
            StartCoroutine(StartWait());
        }else if(bucket.GetComponent<SpriteRenderer>().sprite!=bucketWithWater && chimney.isBurning){
            textComponent.text="ヒント:まずは煙突の中の熱々の鍋の火を消せるものを用意しよう";
        }else if(!logStairs.activeSelf&&chimney.isBurning){
            textComponent.text="ヒント:藁の家の左側に階段をつくって登れるようにしよう。";
        }else if(!woodenBridge2.activeSelf){
            textComponent.text="ヒント:藁の家とレンガの家の間が渡れない。木の家の屋根の上に使えそうなものがあったはず。。";
        }else if(!chimney.isWatering&&chimney.isBurning){
            textComponent.text="ヒント:ブタが仕掛けた煙突の中の熱い鍋をどうにかしたいな。。";
        }else if(chimney.isWatering){
            textComponent.text="煙突の中に水を入れている。";
        }else if(!chimney.isBurning && !chimney.hasEnterdBrickHouse){
            textComponent.text="ヒント:煙突に入ろうか";
        }else if(!brickHint&&chimney.hasEnterdBrickHouse){
            textComponent.text="ヒント:藁の家のブタは木の家に逃げた。ナイフと鉄のナベを家の中で見つけた。";
            StartCoroutine(Wait1());
        }else if(!logBridge.activeSelf && !ax.activeSelf){
            textComponent.text="ヒント:川の上が渡れないから橋を作ろう。さっきの丸太で作れそうだ。";
        }else if(!ax.activeSelf){
            textComponent.text="ヒント:木に縛り付けられたオノのロープを何かで切ろう。";
        }else if(!woodhouse.isBrokenHouse){
            textComponent.text="ヒント:木の家のドアを壊したい。";
        }else if(!woodHouse.hasEnteredWoodHouse&&woodhouse.isBrokenHouse){
            textComponent.text="ヒント:木の家に入ろう";
        }else if(!woodHint&&woodHouse.hasEnteredWoodHouse){
            textComponent.text="ヒント:木の家のブタは藁の家に逃げた。ハンマーを家の中で見つけた。";
            StartCoroutine(Wait2());
        }else if(!brick.activeSelf){
            textComponent.text="ヒント:レンガの家にヒビが入っている部分があるね。叩いたらレンガが取れそう";
        }else if(nabe.GetComponent<SpriteRenderer>().sprite!=fireNabe){
            textComponent.text="ヒント:藁の家は火をつけて壊そう。火は石と鉄で起こせそうだ。使えるものはないかな。";
        }else if(!burnStrawHouse.hasBurnedStrawHouse&&!burnStrawHouse.isStrawBurning){
            textComponent.text="ヒント:ナベに火がついた。ナベの火を藁の家に引火させよう。";
        }else if(burnStrawHouse.isStrawBurning){
            textComponent.text="藁が燃えている";
        }else if(!strawHint){
            textComponent.text="やったー！ごちそうだ！いただきまーす！";
            StartCoroutine(Wait3());
        }
    }

    IEnumerator StartWait(){
        yield return new WaitForSeconds(waitTime);
        startHint=true;
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
