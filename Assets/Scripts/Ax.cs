using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ax : MonoBehaviour
{
    [SerializeField]
    private bool isAxTouching;
    [SerializeField]
    private GameObject ax;
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private Sprite tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isAxTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.Knife:
                        GetComponent<SpriteRenderer>().sprite=tree;
                        ax.SetActive(true);
                    break;
                }
                SoundManager.Instance.PlaySE(SE.BtnItemGet);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isAxTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isAxTouching=false;
    }
}
