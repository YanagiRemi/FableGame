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
    bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        textComponent=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            return;
        }
        if(!startHint){
            textComponent.text="まずはレンガの家の煙突に入れるようにしよう。";
            StartCoroutine(StartWait());
        }else if(!logStairs.activeSelf&&chimney.isBurning){
            textComponent.text= "木の家の左側に丸太を積み上げれば階段が作れそうだ";
        }else if(!woodenBridge2.activeSelf){
            textComponent.text="レンガの家まで渡れない。屋根の上の板を使えば届くかな？";
        }else if(!chimney.isWatering&&chimney.isBurning){
            textComponent.text="熱い鍋をどうにかしたいな...川の水を入れられれば...";
        }else if(chimney.isWatering){
            textComponent.text="こうすればいいんじゃないか？";
        }else if(!chimney.isBurning && !chimney.hasEnterdBrickHouse){
            textComponent.text="これで煙突の中の鍋の火が消えた！中に入ろう";
        }else if(!brickHint&&chimney.hasEnterdBrickHouse){
            textComponent.text="子ブタが木の家に逃げちゃった...";
            StartCoroutine(Wait1());
        }else if(!middleHint){
            textComponent.text="次は木の家に入れるようにしよう。なにかでドアを壊せないかな。";
            StartCoroutine(MiddleWait());
        }else if(!logBridge.activeSelf && !ax.activeSelf){
            textComponent.text="オノを取りに行きたいけど川が渡れない...橋になる丸太でもあれば...";
        }else if(!ax.activeSelf){
            textComponent.text="ロープでオノが取れないな...切れるものがあれば...";
        }else if(!woodhouse.isBrokenHouse){
            textComponent.text="このオノであのドアを...";
        }else if(!woodHouse.hasEnteredWoodHouse&&woodhouse.isBrokenHouse){
            textComponent.text="やったー家に入れるぞ！";
        }else if(!woodHint&&woodHouse.hasEnteredWoodHouse){
            textComponent.text="また子ブタに逃げられちゃった...";
            StartCoroutine(Wait2());
        }else if(!endHint){
            textComponent.text="わらは燃えやすいからなぁ...火があれば...";
            StartCoroutine(EndWait());
        }else if(!brick.activeSelf){
            textComponent.text="レンガの家にヒビが入っている。なにかで叩いたらレンガが取れそうだ。";
        }else if(nabe.GetComponent<SpriteRenderer>().sprite!=fireNabe){
            textComponent.text="火は石と鉄でおこせそうだ。使えるものはないかな。";
        }else if(!burnStrawHouse.hasBurnedStrawHouse&&!burnStrawHouse.isStrawBurning){
            textComponent.text="鉄のナベに火がついた!!!";
        }else if(burnStrawHouse.isStrawBurning){
            textComponent.text="しばらく待てば...";
        }else if(!strawHint){
            isClear = true;
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
        yield return new WaitForSeconds(3f);
        strawHint=true;
        FadeManager.Instance.LoadScene("Ending", 2f);
    }
}
