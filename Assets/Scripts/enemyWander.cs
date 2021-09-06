using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.Events;
using UnityEngine.Animations.Rigging;

public class enemyWander : MonoBehaviour
{
    public List<GameObject> troopToEnemySlots = new List<GameObject>();
    public bool troopEnemyID;
    public List<GameObject> slotList = new List<GameObject>();

    public NavMeshAgent ai;

    public bool isObstacle;
    public bool isSign;
    public bool isSmallWood;
    public bool isWood;
    public bool isRock;
    public bool isSmallRock;
    public bool isHole;
    public GameObject targetPosition;

    public UnityEvent Event;

    public GameObject cursor;
    public float distancetoCursor = 3.5f;

    public float wanderRadius;
    public float wanderTimer;
    private float timer;
    public GameObject player;
    GameObject focus;
    public float health = 100;
    public float maxHealth;
    Image healthValue;

    public bool beingAttacked;

    public Animator animator;

    public bool canAttack = true;


    public enum State
    {
        wandering,

        beingAtk,
        
        chasing,

        attacking,
    }

    public State state;

    GameObject troopAi;

    troop troopScript;

    GameObject[] objects;

    Collider[] hitColliders;
    LayerMask mask = (1 << 11);

    public float playerDistance;

    bool chasingPlayer = false;

    GameObject cylinder;
    GameObject Cylinder1;

    Coroutine attacking;

    public VisualEffect visuallol;

    Canvas healthShow;

    public bool isDead;
    
    // Start is called before the first frame update

    public cursorPosition position;

    public int currentTroops;

    enemyHole objectHole;

    void Start()
    {
        if (isHole)
        {
            objectHole = GetComponent<enemyHole>();
        }

        ai = GetComponent<NavMeshAgent>();

        healthValue = gameObject.transform.Find("Health/Health Value").GetComponent<Image>();

        healthShow = transform.Find("Health").GetComponent<Canvas>();

        maxHealth = health;

        if (!isObstacle)
        {
            animator = transform.Find("Rig").GetComponent<Animator>();
            visuallol = transform.Find("Rig/Smoke Poof").GetComponent<VisualEffect>();

        }

        distancetoCursor = 3.5f;

        GameObject position1 = getCursorPosition.cursorPositionPosition;

        position = GameObject.FindGameObjectWithTag("CursorLol").GetComponent<cursorPosition>();

        if (PlayerPrefs.GetInt("New Game") == 1)
        {
            if (PlayerPrefs.HasKey(gameObject.name + "isDead"))
            {
                PlayerPrefs.DeleteKey(gameObject.name + "isDead");
            }

            for (int step = 0; step <= 10; step++)
            {

            }

            PlayerPrefs.SetInt("New Game", 0);
        }
    }

    public float cursorDistance;

    public float getHitPointDistance;

    // Update is called once per frame
    void Update()
    {

        getHitPointDistance = Vector3.Distance(position.hit.point, transform.position);

        if (getHitPointDistance <= 5 && Input.GetKey(KeyCode.LeftShift) && isDead == false)
        {
                position.snapToPosition = true;
                position.canSnap(gameObject);
        }
        if (!Input.GetKey(KeyCode.LeftShift) || isDead)
        {
            position.snapToPosition = false;
        }


        if (!isObstacle)
        {
            playerDistance = Vector3.Distance(transform.position, player.transform.position);
        }

        switch (state)
        {
            case State.wandering:
            canAttack = true;
            chasingPlayer = false;

            if (ai != null)
            {
                ai.acceleration = 8;
            }
            timer += Time.deltaTime;
    
            if (timer >= wanderTimer && !isObstacle && ai.isOnNavMesh)
            {
                ai.speed = 3f;
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                ai.SetDestination(newPos);
                timer = 0;
            }

            if (beingAttacked == true && !isObstacle)
            {
                state = State.attacking;
            }
            
            if (beingAttacked == false)
            {
                troopToEnemySlots.Clear();
            }

            if (playerDistance < 7f && !isObstacle)
            {
                state = State.chasing;
            }

            break;

            case State.attacking:

            chasingPlayer = false;

            if (beingAttacked == false && canAttack == true)
            {
                animator.SetBool("preparing", false);
                StopCoroutine(attacking);
                state = State.wandering;
            }

            if (canAttack == true)
            {
                attacking = StartCoroutine(startAttacking());
            }

            break;

            case State.chasing:

            ai.SetDestination(player.transform.position);

            if (beingAttacked)
            {
                state = State.attacking;
            }

            if (playerDistance < 3f)
            {
                ai.speed = 0;
                if (canAttack == true)
                {
                    attacking = StartCoroutine(startAttacking());

                }
            }
            else if (canAttack == true) { ai.speed = 4f; }

            if (playerDistance > 5f && canAttack == true)
            {
                state = State.wandering;
            }

            break;
        }


        if (isObstacle == false && ai.velocity.magnitude > 0.0f)
        {
            animator.SetBool("idle", false);
        }
        else if (isObstacle == false)
        {
            animator.SetBool("idle", true);
        }
        healthValue.fillAmount = health / maxHealth;

        
        if (canAttack == true && !isObstacle)
        {
            animator.SetBool("preparing", false);
        }

        if (health < 1 && a == true)
        {
            StartCoroutine(yourmom());
        }

        if (health < maxHealth || Vector3.Distance(cursorPosition.cursorObject.transform.position, transform.position) < distancetoCursor)
        {
           healthShow.enabled = true; 
        }
        else { healthShow.enabled = false; }

        if (troopToEnemySlots.Count == slotList.Count)
        {
            troopEnemyID = true;
        }
        else
        {
            troopEnemyID = false;
        }
    }

    bool a = true;

    bool doNotRecieveDamage = false;

    IEnumerator yourmom()
    {
        Debug.Log("Death");
        if (!isObstacle)
        {
            a = false;
            ai.enabled = false;
            ai.updatePosition= false;
            ai.updateRotation = false;
            animator.SetBool("Death", true);
            StopCoroutine(attacking);
            yield return new WaitForSeconds(3);
            visuallol.Play();
            yield return new WaitForSeconds(0.3f);
            StopCoroutine(attacking);
            SkinnedMeshRenderer renderer = transform.Find("Rig/Model").GetComponent<SkinnedMeshRenderer>();
    
            renderer.enabled = false;
    
            yield return new WaitForSeconds(2f);

            isDead = true;

            this.gameObject.SetActive(false);
        }
        else if (isSign)
        {
            a = false;
            visuallol.Play();
            yield return new WaitForSeconds(2);

            health = 0;

            isDead = true;
        }
        else if (!isSign)
        {
            a = false;
            isDead = true;

            Kill();

            while (!save)
            {
                yield return null;
            }

            gameObject.SetActive(false);
        }

             
    }

    //Wandering
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;

    }

    int e;
    IEnumerator startAttacking()
    {
        if (state == State.attacking || state == State.chasing)
        {
            Debug.LogError("Attacking " + e++);
            canAttack = false;
            yield return new WaitForSeconds(1);
            animator.SetBool("preparing", true);
            yield return new WaitForSeconds(3.5f);

            hitColliders = Physics.OverlapSphere(transform.position, 2.5f, mask);

            if (hitColliders.Length > 0 && doNotRecieveDamage == false)
            {
                foreach (var hitCollider in hitColliders)
                {
                    troopAi = hitCollider.gameObject;
                    troopScript = troopAi.GetComponent<troop>();
                    StartCoroutine(troopScript.recieveDamage());
                }
            }
            animator.SetTrigger("attack");

            if (playerDistance < 3f) { player.GetComponent<playerMovement>().Damage(); }
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("preparing", false);
            canAttack = true;
            StopCoroutine(attacking);
        }
    }

    public GameObject buildableObject;

    void Kill()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject != buildableObject)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Don't Disable");
                child.gameObject.SetActive(true);
            }
        }

        if (gameObject.GetComponent<NavMeshObstacle>() != null)
        {
            gameObject.GetComponent<NavMeshObstacle>().enabled = false;
        }

        if (gameObject.GetComponent<CapsuleCollider>() != null)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (gameObject.GetComponent<BoxCollider>() != null)
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public bool save;

    public void Save()
    {
        if (PlayerPrefs.HasKey(gameObject.name + "isDead"))
        {
            PlayerPrefs.DeleteKey(gameObject.name + "isDead");
        }

        if (isObstacle)
        {
            if (isDead)
            {
                save = true;
                PlayerPrefs.SetInt(gameObject.name + "isDead", 1);

                PlayerPrefs.Save();
            }
        }
    }

    public void Load()
    {
        if (PlayerPrefs.GetInt(gameObject.name + "isDead") == 1 && isObstacle)
        {
            StartCoroutine(yourmom());
        }
    }

    public int troopAmount;

    GameObject targetSelection;

    public Vector3 GetPositon()
    {
        if (isSign)
        {
            targetSelection = targetPosition;
        }
        else
        {
            targetSelection = gameObject;
        }

        float angle =  currentTroops * Mathf.PI * 2f / troopAmount;
        return targetSelection.transform.position + new Vector3(Mathf.Cos(angle) * 1, 0, Mathf.Sin(angle) * 1);
    }
}
