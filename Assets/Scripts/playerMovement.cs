using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerMovement : MonoBehaviour
{

    public float playerVelocity;
    Vector3 lastPosition;


    public Transform target;

    public CharacterController controller;
    public Transform cam;

    static public GameObject player;

    static public float rotationy;

    public float speed = 6f;

    Image healthValue;
    public static float playerHealth = 3;
    float maxHealth;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 moveVector;

    bool allowedToDamage = true;

    static public bool moving;

    static public bool isInDoor;

    public GameObject nearestEnemy = null;

    bool checkNearestEnemy = true;

    enemyWander getEnemyScript;

    public bool enemyAttacking;

    public static bool inAttackArea;
    public static bool chase;

    public static bool allowMovement = true;

    float attackDistance;

    bool damage = true;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "attackarea")
        {
            findClosestEnemy();
        }

        if (other.name == "wall")
        {
            isInDoor = true;
        }

        if (other.tag == "failsafe")
        {
            enemySign.failsafe = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "failsafe")
        {
            enemySign.failsafe = false;
        }
    }
    public void canGoToDoor()
    {
        isInDoor = false;
    }

    void Awake()
    {
    }
    
    void Start()
    {
        healthValue = gameObject.transform.Find("Health/Health Value").GetComponent<Image>();
        playerHealth = 3;
        maxHealth = playerHealth;
        lastPosition = transform.position;
    }

    public void Damage()
    {
        playerHealth--;
    }

    void FixedUpdate()
    {
    }

    void Update()
    {
        playerVelocity = Vector3.Distance(transform. position, lastPosition) / Time. deltaTime;

        lastPosition = transform.position;

        player = gameObject;

        rotationy = transform.eulerAngles.y;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f && troop.isTalking == false)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (allowMovement == true)
            {
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            moving = true;
            }
        }
        else { moving = false; }

        //REeset the MoveVector
        moveVector = Vector3.zero;

        //Check if cjharacter is grounded
        if (controller.isGrounded == false)
        {
            //Add our gravity Vecotr
            moveVector += Physics.gravity;
        }

        //Apply our move Vector , remeber to multiply by Time.delta
        controller.Move(moveVector * Time.deltaTime);

        health();

        if (playerHealth <= 0)
        {
            troop.troopIndex.Clear();
            SceneManager.LoadScene("SampleScene");
        }
    }

    public GameObject findClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closestEnemy = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestEnemy = go;
                distance = curDistance;
            }
        }
        nearestEnemy = closestEnemy;
        Debug.Log(closestEnemy);
        getEnemyScript = nearestEnemy.GetComponent<enemyWander>();
        //enemyAttacking = true;
        enemyAttacking = true;
        return closestEnemy;
    }
    IEnumerator recieveDamage()
    {
        damage = false;
        playerHealth--;
        yield return new WaitForSeconds(0.5f);
        damage = true;
    }

    void health()
    {
        healthValue.fillAmount = playerHealth / maxHealth;
    }

    IEnumerator Velocity()
    {
        for (int i = 0; i < 10000; i++)
        {
            Debug.Log(playerVelocity);
            yield return new WaitForSeconds(2);
        }
    }
}