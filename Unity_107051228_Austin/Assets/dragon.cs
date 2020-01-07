using UnityEngine;

public class dragon : MonoBehaviour

{
    private void Update()


    {

        Turn();
        Run();
       
        Take();
    }
    public Rigidbody rigcatch;



    private void OnTriggerStay(Collider other)
    {
        print(other);
        if (other.name == "Bone" && ani.GetCurrentAnimatorStateInfo(0).IsName("Breath_Gs"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigcatch;
        }
        if (other.name == "沙子" && ani.GetCurrentAnimatorStateInfo(0).IsName("Breath_Gs"))
        {
            
            GameObject.Find("Bone").GetComponent<HingeJoint>().connectedBody = null;
        }
    }



    #region 區域
    [Header("dgspeed")]
    [Range(1, 1000)]
    public int speed = 20;
    [Tooltip("dg's rotation speed")]
    [Range(1f, 2000f)]
    public float turn = 11.1f;
    public bool mission;
    public string name = "OZ";
    #endregion
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;

    


    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("atk")) return;
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("Walk", v != 0);
    }
    private void Turn()
    {
        float f = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * f * Time.deltaTime, 0);
    }
   
    private void Take()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ani.SetTrigger("atk");
    }
    private void Task()
    { }
}