using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour
{
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private GameObject wolf;
    public bool isBurning=true;
    private Rigidbody2D rb2d;
    private bool isChimneyTouching;
    [SerializeField]
    private GameObject bucket;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float rotateSpeed = 12f; // 回転速度
    [SerializeField]
    private float targetAngle = 55f;
    [SerializeField]
    private Sprite emptyBucket;
    public bool isWatering;
    private Renderer renderer;
    public GameObject pigGimmick1;
    public bool hasEnterdBrickHouse=false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d =wolf.GetComponent<Rigidbody2D>();
        renderer = wolf.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isChimneyTouching&&Input.GetKeyDown(KeyCode.Space)){
            if(!isBurning&&!hasEnterdBrickHouse){
                renderer.sortingLayerName="Dafault";
                if(charaCtl.item!=null){
                    charaCtl.itemObject.GetComponent<Renderer>().sortingLayerName="Default";
                }
                wolf.transform.localPosition = new Vector2(14.2f,2.45f);
                GetComponent<EdgeCollider2D>().enabled=false;
            }else if(charaCtl.item!=null){
                switch(charaCtl.item.ItemType){
                    case Items.BucketWithWater:
                        isWatering=true;
                        charaCtl.isItemGetting=false;
                        charaCtl.item=null;
                        bucket.transform.localPosition = new Vector2(15.12f,1.48f);
                        break;
                }
            }
        }
        if(!isBurning&&!hasEnterdBrickHouse){
            if(wolf.transform.localPosition.y <= -1.0f && wolf.activeSelf){
                    wolf.SetActive(false);
                    if(charaCtl.item!=null){
                        charaCtl.itemObject.SetActive(false);
                    }
                    pigGimmick1.SetActive(true);
            }
        }else if(isWatering){
                angle += rotateSpeed * Time.deltaTime;
                bucket.transform.rotation = Quaternion.Euler(0, 0, angle);
                if(angle>=targetAngle){
                   isWatering=false;
                   bucket.GetComponent<SpriteRenderer>().sprite=emptyBucket;
                   isBurning=false;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        isChimneyTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        isChimneyTouching=false;
    }
}
