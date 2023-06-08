using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBridge : MonoBehaviour
{
    [SerializeField]
    protected CharaCtl charaCtl;
    [SerializeField]
    protected GameObject woodenBridge;
    protected bool isRoofEdgeTouching;
    [SerializeField]
    protected GameObject woodenBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual　void Update()
    {
        if(charaCtl.item!=null){
            if(isRoofEdgeTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.WoodenBoard:
                        woodenBridge.SetActive(true);
                        woodenBoard.SetActive(false);
                        charaCtl.isItemGetting=false;
                        charaCtl.item=null;
                        break;
                }
                SoundManager.Instance.PlaySE(SE.BtnItemGet);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isRoofEdgeTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isRoofEdgeTouching=false;
    }
}
