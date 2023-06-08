using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHouse : MonoBehaviour
{
     [SerializeField]
    private bool isWoodHouseTouching;
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private Sprite brokenWoodHouse;
    public bool isBrokenHouse=false;
    [SerializeField]
    private GameObject wolf;
    [SerializeField]
    private GameObject pigGimmick2;
    [SerializeField]
    private float waitTime=1.0f;
    public bool hasEnteredWoodHouse=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(isWoodHouseTouching&&Input.GetKeyDown(KeyCode.Space)){
                if(!hasEnteredWoodHouse && isBrokenHouse){
                    wolf.GetComponent<Rigidbody2D>().gravityScale=0;
                    wolf.transform.localPosition=new Vector2(1.38f,-1.69f);
                    StartCoroutine(WaitAndHideWolf());
                }else if(charaCtl.item!=null){
                    switch(charaCtl.item.ItemType){
                        case Items.Ax:
                            GetComponent<SpriteRenderer>().sprite=brokenWoodHouse;
                            isBrokenHouse=true;
                            break;
                    }
                }
            }
    }
    IEnumerator WaitAndHideWolf(){
        yield return new WaitForSeconds(waitTime);
        wolf.SetActive(false);
        wolf.GetComponent<Rigidbody2D>().gravityScale=2;
    　　if (charaCtl.item != null){
            charaCtl.itemObject.SetActive(false);
        }
        pigGimmick2.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isWoodHouseTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isWoodHouseTouching=false;
    }
}