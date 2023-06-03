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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charaCtl.item!=null){
            if(isRiverTouching&&charaCtl.item.ItemType==Items.Bucket&&Input.GetKeyDown(KeyCode.Space)){
            bucket.GetComponent<SpriteRenderer>().sprite=bucketWithWater;
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
