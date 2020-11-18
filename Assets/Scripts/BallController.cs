using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using System.Linq;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    
    public Rigidbody rb;
    public float movementspeed = 1;
    public List<BallProfil> balls;
    public Balltypes choosetype;
    public List<BallTypeProfil> balltype;

    private void Awake()
    {
        instance = this;
    }









    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeBallType();
       
    }
    private void Update()
    {
        if (!GameManager.instance.IsGameStarted) return;

        if(transform.position.y<=-3)
        {
            GameManager.instance.GameOver();
        }

#if UNITY_ANDROID
                foreach (var item in Input.touches)
                {
                    switch (item.phase)
                    {
                        case TouchPhase.Began:
                            ChangeSelectedType();
                            break;
                    }
                }
#endif

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSelectedType();
        }
#endif


        BallMovement();
        
    }
    public void BallMovement()
    {
        rb.velocity = new Vector3(0,rb.velocity.y, movementspeed);
    }
   
   

    public void ChangeSelectedType()
    {
        if (choosetype == Balltypes.l)
        {
            choosetype = Balltypes.s;
        }

        else if (choosetype == Balltypes.s)
        {
            choosetype = Balltypes.l;

        }

        ChangeBallScale();
        ChangeBallSpeed();
    }
    public Vector3 BallEndValue()
    {
        BallProfil newball = balls.Find(x => x.balltype == choosetype);
        return newball.ballvalue;
    }

    public void ChangeBallScale()
    {
        transform.DOScale(BallEndValue(), 0.5f);

    }
    public void ChangeBallSpeed() 
    {

        BallProfil newball = balls.Find(x => x.balltype == choosetype);
        movementspeed = newball.ballspeed;
    }


    
    [System.Serializable]
    public class BallProfil
    {
        public Balltypes balltype;
        public Vector3 ballvalue;
        public float ballspeed;
        
    }
    public enum Balltypes
    {
        xs=0,s=1,m=2,l=3
    }
    public void OnTriggerEnter(Collider collision)
    {
      if(collision.gameObject.tag=="hit")
        {
            CreaterPlan.instance.CreatePlane();
        }
      else if(collision.gameObject.tag=="change")
        {
            Debug.Log("girdi");
            ChangeBallType();
        }
    }


    public void ChangeBallType()
    {
        int rand = Random.Range(0, balltype.Count);
       
        transform.GetComponent<Renderer>().material =balltype[rand].ballmaterial;
    }
    [System.Serializable]
    public class BallTypeProfil
    {
        public Material ballmaterial;
      
    }

}
