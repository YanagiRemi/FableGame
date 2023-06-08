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
    public float startWaitTime=5.5f;
    public float waitTime=5.5f;
    public BurnStrawHouse BurnStrawHouse;
    public bool strawHint=false;
    public bool woodHint=false;
    public bool startHint=false;
    public bool middleHint=false;
    public bool endHint=false;
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
            textComponent.text="まずはレンガの家の煙突に入れるようにしよう。\n煙突の中に熱々の鍋を用意していたから注意が必要だ。。";
            StartCoroutine(StartWait());
        }else if(bucket.GetComponent<SpriteRenderer>().sprite!=bucketWithWater && chimney.isBurning){
            textComponent.text="ヒント:まずは煙突の中の熱々の鍋の火を消せるものを用意しよう";
        }else if(!logStairs.activeSelf&&chimney.isBurning){
            textComponent.text="ヒント:わらの家の左側に階段をつくって登れるようにしよう。丸太が使えそうだ。";
        }else if(!woodenBridge2.activeSelf){
            textComponent.text="ヒント:わらの家とレンガの家の間が渡れない。木の家の屋根の上に使えそうなものがあったはず。。";
        }else if(!chimney.isWatering&&chimney.isBurning){
            textComponent.text="ヒント:ブタが仕掛けた煙突の中の熱い鍋をどうにかしたいな。。";
        }else if(chimney.isWatering){
            textComponent.text="煙突の中に水を入れている。";
        }else if(!chimney.isBurning && !chimney.hasEnterdBrickHouse){
            textComponent.text="ヒント:これで煙突の中の鍋の火が消えたようだ。煙突に入ろう。";
        }else if(!brickHint&&chimney.hasEnterdBrickHouse){
            textComponent.text="レンガの家のブタは木の家に逃げたようだ。ナイフと鉄のナベを家の中で見つけた。";
            StartCoroutine(Wait1());
        }else if(!middleHint){
            textComponent.text="次は木の家に入れるようにしよう。なにかでドアを壊せないかな。";
            StartCoroutine(MiddleWait());
        }else if(!logBridge.activeSelf && !ax.activeSelf){
            textComponent.text="ヒント:川が渡れないから橋を作ろう。さっきの丸太で作れそうだ。";
        }else if(!ax.activeSelf){
            textComponent.text="ヒント:木に縛り付けられたオノのロープを何かで切ろう。";
        }else if(!woodhouse.isBrokenHouse){
            textComponent.text="ヒント:木の家のドアを壊したいな。。";
        }else if(!woodHouse.hasEnteredWoodHouse&&woodhouse.isBrokenHouse){
            textComponent.text="ヒント:木の家に入ろう";
        }else if(!woodHint&&woodHouse.hasEnteredWoodHouse){
            textComponent.text="ヒント:木の家のブタはわらの家に逃げたようだ。ハンマーを家の中で見つけた。";
            StartCoroutine(Wait2());
        }else if(!endHint){
            textComponent.text="次はわらの家に入れるようにしよう。なにかで燃やせないかな。";
            StartCoroutine(EndWait());
        }else if(!brick.activeSelf){
            textComponent.text="ヒント:レンガの家にヒビが入っている部分があるね。なにかで叩いたらレンガが取れそうだ。";
        }else if(nabe.GetComponent<SpriteRenderer>().sprite!=fireNabe){
            textComponent.text="ヒント:わらの家は火をつけて壊そう。火は石と鉄で起こせそうだ。使えるものはないかな。";
        }else if(!burnStrawHouse.hasBurnedStrawHouse&&!burnStrawHouse.isStrawBurning){
            textComponent.text="ヒント:鉄のナベに火がついた。ナベの火をわらの家に引火させよう。";
        }else if(burnStrawHouse.isStrawBurning){
            textComponent.text="わらが燃えている。";
        }else if(!strawHint){
            textComponent.text="やったー！ごちそうだ！いただきまーす！";
            StartCoroutine(Wait3());
        }
    }

    IEnumerator StartWait(){
        yield return new WaitForSeconds(startWaitTime);
        startHint=true;
    }

    IEnumerator MiddleWait(){
        yield return new WaitForSeconds(startWaitTime);
        middleHint=true;
    }

    IEnumerator EndWait(){
        yield return new WaitForSeconds(startWaitTime);
        endHint=true;
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
