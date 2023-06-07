using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWoodHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject wolf;
    [SerializeField]
    private GameObject hammer;
    [SerializeField]
    private CharaCtl charaCtl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExitingWoodHouse(){
        wolf.transform.position=new Vector2(-2.75f,-2.81f);
        wolf.SetActive(true);
        if(charaCtl.item!=null){
            charaCtl.itemObject.SetActive(true);
        }
        hammer.SetActive(true);
    }
}
