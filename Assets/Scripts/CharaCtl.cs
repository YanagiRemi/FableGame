using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCtl : MonoBehaviour
{
    public float moveSpeed=1;
    public float jumpSpeed=3;
    private Rigidbody2D rb2d;
    private float x; 
    private SpriteRenderer spRenderer;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private bool isItemTouching;
    public GameObject bucket;
    public float yOffset;
    private bool isItemGetting;

    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        spRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x=Input.GetAxisRaw("Horizontal"); //左-1,右+1,なにもしない0
        
        //キャラクターの向きを変える
        if(x>0){
            spRenderer.flipX=true;
        }else if(x<0){
            spRenderer.flipX=false;
        }
        //キャラクターを移動させる
        if(isJumping==false){
            rb2d.AddForce(Vector2.right * x * moveSpeed);
        }
    
        //キャラクターをジャンプさせる
        if(Input.GetButtonDown("Jump")&&!isJumping){
            rb2d.AddForce(Vector2.up*jumpSpeed);
            isJumping=true;
        }

        if(!isItemGetting && isItemTouching && Input.GetKeyDown(KeyCode.Return)){
            bucket.transform.position=transform.position+Vector3.up*yOffset;
            isItemGetting=true;
        }
        if(isItemGetting){
            bucket.transform.position=transform.position+Vector3.up*yOffset;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")){
            isJumping=false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Bucket")){
            isItemTouching=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Bucket")){
            isItemTouching=false;
        }
    }

}
