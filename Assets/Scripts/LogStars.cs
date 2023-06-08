using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogStars : MonoBehaviour
{
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private GameObject logStairs;
    [SerializeField]
    private bool isTouching;
    [SerializeField]
    private CharaCtl charaCtl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.Log:
                        logStairs.SetActive(true);
                        log.SetActive(false);
                        charaCtl.isItemGetting=false;
                        charaCtl.item=null;
                        break;
                }
                SoundManager.Instance.PlaySE(SE.BtnItemGet);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider){
        isTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isTouching=false;
    }
}
