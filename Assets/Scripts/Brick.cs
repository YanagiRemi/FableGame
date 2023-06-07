using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private bool isBrickTouching;
    [SerializeField]
    private GameObject brick;
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private Sprite brokenBrickHouseSprite;
    [SerializeField]
    private GameObject brickHouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isBrickTouching&&Input.GetKeyDown(KeyCode.Space)){
                switch(charaCtl.item.ItemType){
                    case Items.Hammer:
                        brickHouse.GetComponent<SpriteRenderer>().sprite=brokenBrickHouseSprite;
                        brick.SetActive(true);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isBrickTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider){
        isBrickTouching=false;
    }
}