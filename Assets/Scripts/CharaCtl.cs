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
    public bool isItemGetting;
    [SerializeField]
    private ItemObj collisionItem;
    public ItemObj item;
    [SerializeField]
    private GameObject woodenBridge;
    [SerializeField]
    private GameObject woodenBridge2;
    [SerializeField]
    private GameObject woodenBoard;
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private GameObject logBrige;
    [SerializeField]
    private GameObject logStairs;
    Animator animator;
    [SerializeField]
    private GameObject backGround;
    Vector3 defaultPosition;
    bool isGameOver;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // animator.SetBool("IsRun", false);
        rb2d =GetComponent<Rigidbody2D>();
        spRenderer=GetComponent<SpriteRenderer>();
        defaultPosition = transform.position;
        SoundManager.Instance.PlayBGM(BGM.Title);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if (transform.position.y < -7)
        {
            isGameOver = true;
            FadeManager.Instance.LoadScene("SampleScene", 1f);
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            FadeManager.Instance.LoadScene("SampleScene", 1f);
            return;
        }
        x=Input.GetAxisRaw("Horizontal"); //左-1,右+1,なにもしない0

        //キャラクターの向きを変える
        if(x>0){
            spRenderer.flipX=true;
        }else if(x<0){
            spRenderer.flipX=false;
        }
        //キャラクターを移動させる
        if(isJumping==false){
            rb2d.velocity = new Vector2(x * moveSpeed / 2f, rb2d.velocity.y);
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
            item=collisionItem;
            if(collisionObject==woodenBridge || collisionObject==woodenBridge2){
                collisionObject.SetActive(false);
                itemObject=woodenBoard;
                itemObject.SetActive(true);
            }else if(collisionObject==logStairs || collisionObject==logBrige){
                if(collisionObject==logBrige){
                    backGround.GetComponent<BoxCollider2D>().enabled=true;
                }
                collisionObject.SetActive(false);
                itemObject=log;
                itemObject.SetActive(true);
            }else{
                itemObject=collisionObject;
            }
            itemObject.transform.position=transform.position+Vector3.up*yOffset;
            isItemGetting=true;
            SoundManager.Instance.PlaySE(SE.BtnItemGet);
        }else if(isItemGetting && Input.GetKeyDown(KeyCode.Return)){
            if(spRenderer.flipX==true){
                itemObject.transform.position=transform.position+Vector3.right*xOffset;
            }else{
                itemObject.transform.position=transform.position+Vector3.left*xOffset;
            }
            isItemGetting=false;
            item=null;
            SoundManager.Instance.PlaySE(SE.BtnItemSet);
        }
        if (isItemGetting){
            itemObject.transform.position=transform.position+Vector3.up*yOffset;
        }
    }
    private void LateUpdate()
    {
        animator.SetBool("IsWalk", x != 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")){
            isJumping=false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(!collision.gameObject.CompareTag("Ground") || collision.gameObject==logStairs){
            collisionObject=collision.gameObject;
            isItemTouching=true;
            collisionItem = collision.GetComponent<ItemObj>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(!collision.gameObject.CompareTag("Ground") || collision.gameObject==logStairs){
            isItemTouching=false;
            collisionItem = null;
        }
    }

}
