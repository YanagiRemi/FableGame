using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour
{
    [SerializeField]
    private CharaCtl charaCtl;
    [SerializeField]
    private GameObject wolf;
    [SerializeField]
    private bool isBurning=true;
    private Rigidbody2D rb2d;
    private bool isChimneyTouching;
    [SerializeField]
    private GameObject bucket;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float rotateSpeed = 8f; // 回転速度
    [SerializeField]
    private float targetAngle = 45f;
    [SerializeField]
    private Sprite emptyBucket;
    [SerializeField]
    private bool isWatering;
    private Renderer renderer;
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
            if(!isBurning){
                renderer.sortingLayerName="Dafault";
                if(charaCtl.item!=null){
                    charaCtl.itemObject.GetComponent<Renderer>().sortingLayerName="Default";
                }
                wolf.transform.position = new Vector2(7.8f,1f);
                GetComponent<EdgeCollider2D>().enabled=false;
            }else if(charaCtl.item.ItemType==Items.Bucket){
                isWatering=true;
                charaCtl.isItemGetting=false;
                charaCtl.item=null;
                bucket.transform.position = new Vector2(8.4f,0.8f);
            }
        }
        if(!isBurning){
            if(wolf.transform.position.y <= -2.0f && wolf.activeSelf){
                    wolf.SetActive(false);
                    if(charaCtl.item!=null){
                        charaCtl.itemObject.SetActive(false);
                    }
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
