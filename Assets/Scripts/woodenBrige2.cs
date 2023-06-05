using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBridge2 : WoodenBridge
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    protected override void Update()
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
            }
        }else{
            if(isRoofEdgeTouching&&Input.GetKeyDown(KeyCode.Space)&&woodenBridge.activeSelf){
                woodenBridge.SetActive(false);
                woodenBoard.SetActive(true);
                charaCtl.isItemGetting=true;
                charaCtl.item=woodenBoard.GetComponent<ItemObj>();
            }
        }
    }
}
