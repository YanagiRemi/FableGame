using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStrawHouse : MonoBehaviour
{
    [SerializeField]
    private bool isStrawHouseTouching;
    [SerializeField]
    private CharaCtl charaCtl;
    public bool isStrawBurning=false;
    public bool hasBurnedStrawHouse=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isStrawHouseTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.FireNabe:
                        GetComponent<Animator>().enabled=true;
                        isStrawBurning=true;
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isStrawHouseTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isStrawHouseTouching=false;
    }

    private void BurnedStrawHouse(){
        hasBurnedStrawHouse=true;
        isStrawBurning=false;
    }
}
