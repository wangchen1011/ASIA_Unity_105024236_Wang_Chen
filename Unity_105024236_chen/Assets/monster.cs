 using UnityEngine;

public class monster : MonoBehaviour
{

    [Header("移動速度")]
    [Range(1, 2000)]
    public int speed = 10;
    [Header("旋轉速度"), Tooltip("精靈旋轉速度"), Range(1.5f, 200f)]
    public float turn = 20.5f;
    [Header("撿東西位置")]
    public Rigidbody rigCatch;

    public Transform tran;
    public Rigidbody rig;
    public Animator ani;

    void Update()
    {
        Turn();
        Run();
        Attack();
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        if (other.name == "rock" && ani.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigCatch;
        }
    }

    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }
    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("attack")) return;
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v );
        ani.SetBool("walk", v != 0);
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("atteck");
        }
    }
}
