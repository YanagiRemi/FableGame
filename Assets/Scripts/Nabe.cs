using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nabe : MonoBehaviour
{
   [SerializeField]
    private bool isNabeTouching;
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private Sprite fireNabe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isNabeTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.Brick:
                        GetComponent<SpriteRenderer>().sprite=fireNabe;
                        GetComponent<ItemObj>().ItemType=Items.FireNabe;
                    break;
                }
                SoundManager.Instance.PlaySE(SE.BtnItemGet);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isNabeTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isNabeTouching=false;
    }
}
