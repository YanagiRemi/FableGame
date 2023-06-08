using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kawa : MonoBehaviour
{
    [SerializeField]
    private bool isRiverTouching;
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private GameObject bucket;
    [SerializeField]
    private Sprite bucketWithWater;
    [SerializeField]
    private GameObject logBrige;
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private GameObject backGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isRiverTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.Bucket:
                        bucket.GetComponent<SpriteRenderer>().sprite=bucketWithWater;
                        bucket.GetComponent<ItemObj>().ItemType=Items.BucketWithWater;
                        break;
                    case Items.Log:
                        logBrige.SetActive(true);
                        log.SetActive(false);
                        charaCtl.isItemGetting=false;
                        charaCtl.item=null;
                        break;
                }
                SoundManager.Instance.PlaySE(SE.BtnItemGet);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        isRiverTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isRiverTouching=false;
    }

}
