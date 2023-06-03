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
    public GameObject itemObject;
    public GameObject collisionObject;
    public float xOffset;
    public float yOffset;
    private bool isItemGetting;
    private ItemObj collisionItem;
    public ItemObj item;
    Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        // animator.SetBool("IsRun", false);
        rb2d =GetComponent<Rigidbody2D>();
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
            rb2d.velocity = Vector2.right * x * moveSpeed;
            //rb2d.AddForce(Vector2.right * x * moveSpeed);
        }
        else
        {
            rb2d.velocity = new Vector2(x * moveSpeed / 2f, rb2d.velocity.y);
        }

        //キャラクターをジャンプさせる
        if (Input.GetKeyDown(KeyCode.UpArrow)&&!isJumping){
            rb2d.AddForce(Vector2.up*jumpSpeed);
            isJumping=true;
            Debug.Log("Jump");
        }

        if(!isItemGetting && isItemTouching && Input.GetKeyDown(KeyCode.Return)){
            itemObject=collisionObject;
            itemObject.transform.position=transform.position+Vector3.up*yOffset;
            isItemGetting=true;
            item = collisionItem;
            // Debug.Log(item.ItemType);
        }
        if(isItemGetting){
            itemObject.transform.position=transform.position+Vector3.up*yOffset;
        }

        if(isItemGetting && Input.GetKeyDown(KeyCode.RightShift)){
            itemObject.transform.position=transform.position+Vector3.right*xOffset;
            isItemGetting=false;
            item=null; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")){
            isJumping=false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        collisionObject=collision.gameObject;
        isItemTouching=true;
        collisionItem = collision.GetComponent<ItemObj>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
            isItemTouching=false;
            collisionItem = null;
    }

}
