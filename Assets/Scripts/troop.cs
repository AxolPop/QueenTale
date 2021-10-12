using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;

public class troop : MonoBehaviour
{
    public static troop Instance;

    public Material aiEnabled;

    public Material aiDisabled;

    public static List<int> troopIndex = new List<int>();
    public static List<GameObject> troopSpawnID = new List<GameObject>();
    public static List<GameObject> troopsTalkingTo = new List<GameObject>();

    Animator animator;

    [Header("Troop Names")]
    public string troopsName;
    public static string setNameInTextBox;

    [Header("Wandering")]
    public float wanderRadius;
    public float wanderTimer;
    public GameObject player;

    TextMeshProUGUI lmao;
    TextMeshProUGUI lmfao;

    Vector3 moveVector;

    //Coroutines

    Coroutine startChargingDude = null;
    Coroutine waitABit = null;
    Coroutine broStartAttacking = null;
    Coroutine troopFind_ = null;

    bool allowAttack = true;

    public NavMeshAgent ai;
    private float timer;

    [Header("Health")]
    Canvas canvas;
    public float troopHealth;
    public int maxtroopHealth;
    Image healthValue;
    public List<Sprite> myTextures = new List<Sprite>();
    Image healthTex;
    int listHealth;

    enemyWander getEnemyScript;

    public static float troopMaxTotal;
    public float distance = 10;
    public float distanceFromSlot = 10;
    public bool canCharge = true;

    Camera cam;

    public static float troopTotal = -1;
    public int troopID;

    public GameObject troopNumber;

    float moveSpeed = 25;
    CharacterController cc;

    bool canGoToKing = true;

    public static bool charging = false;
    public bool chargingPublic;

    public GameObject nearestEnemy;

    public Transform cursorPosition;
    Vector3 setCursorPosition;

    static public bool isTalking = false;
    static public GameObject talkingToTroop;

    float talkingDistance;
    bool isTalkingowo = false;

    [SerializeField] float hiringDistance;
    [SerializeField] Transform cursorObject;

    public Outline outLine;

    bool battlin = false;

    IEnumerator booba;

    public enum State
    {
        wandering,
        atKing,
        attacking,
        charging,
        jumping
    }

    public State state;

    public string stateText;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "talkFunction")
        {
            allowTalk = false;
            troopsTalkingTo.Remove(gameObject);
        }
    }

    public bool allowTalk = false;

    //Variables to set
    public bool canMine = false;
    public bool canCut = false;
    public bool canBuild = false;
    public bool canDig = true;
    public float setDamageSpeed = 1.3f;
    public float setObstacleDamageSpeed = 1.3f;
    public bool canChop = false;
    public jobManager jobsLol;
    public string job;

    public bool hasIncreasedHealth = false;

    public void OnTriggerEnter(Collider other)
    {
        if (state == State.charging)
        {
            switch (other.name)
            {
                case ("farmer"):
                jobsLol.setAbilities(gameObject, other.name);
                job = other.name;
                break;
    
                case ("builder"):
                jobsLol.setAbilities(gameObject, other.name);
                job = other.name;
                break;
    
                case ("miner"):
                jobsLol.setAbilities(gameObject, other.name);
                job = other.name;
                break;
    
                case ("guard"):
                jobsLol.setAbilities(gameObject, other.name);
                job = other.name;
                break;
            }
        }
    }

    public static GameObject foundEnemy;
    public static enemyWander foundEnemyScript;
    

    public void ClearTroops()
    {
        troopIndex.Remove(troopGetIndex);
        state = State.wandering;
    }

    public void setJobOnLoad(string jobName)
    {
        switch (jobName)
        {
            case ("farmer"):
            jobsLol.setAbilities(gameObject, jobName);
            job = jobName;
            break;

            case ("builder"):
            jobsLol.setAbilities(gameObject, jobName);
            job = jobName;
            break;

            case ("miner"):
            jobsLol.setAbilities(gameObject, jobName);
            job = jobName;
            break;

            case ("guard"):
            jobsLol.setAbilities(gameObject, jobName);
            job = jobName;
            break;

            default:
            job = "carefree";
            break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "talkFunction" && state == State.wandering && troopsTalkingTo.Count == 0)
        {
            allowTalk = true;
            troopsTalkingTo.Add(gameObject);
        }
    }

    // Start is called before the first frame update


    AudioSource audioLol;

    public int spawnID;

    public float movementSpeed;

    void Awake()
    {
        Instance = this;

        spawnID = spawnTroop.instantateID;
        troopSpawnID.Add(gameObject);

        maxtroopHealth = Random.Range(3, 5);
        troopHealth = maxtroopHealth;
        listHealth = maxtroopHealth;
        listHealth -= 3;
    }

    public Renderer troopRenderer;

    void Start()
    {
        //Saving
        allowTalk = false;
        outLine.enabled = false;
        canvas = gameObject.GetComponentInChildren<Canvas>();
        troopMaxTotal = 12;
        distance = 10;
        cc = GetComponent<CharacterController>();
        cam = Camera.main;
        state = State.wandering;
        ai = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        allowAttack = true;

        cc.enabled = false;
        healthValue = gameObject.transform.Find("Health/Health Value").GetComponent<Image>();
        healthTex = transform.Find("Health/Health Foreground").GetComponent<Image>();
        healthTex.sprite = myTextures[listHealth];

        lmao = transform.Find("F/Brug").GetComponent<TextMeshProUGUI>();
        lmfao = transform.Find("F/Funny").GetComponent<TextMeshProUGUI>();
        lmfao.enabled = false;

        lmao.enabled = false;

        gameObject.name = nameSystem.troopNames[spawnID];

        animator = GetComponent<Animator>();
        displayDeathMessage = false;

        audioLol = GetComponent<AudioSource>();

        charging = false;

        troopRenderer = transform.Find("Model").GetComponent<Renderer>();
    }

    public bool troopTalkingTo;

    void Hire()
    {
        if (troopIndex.Count < 12 && !charging)
        {
            allowTalk = false;
            troopsTalkingTo.Remove(gameObject);
            troopIDIndex += 1;
            troopGetIndex = troopIDIndex;
            state = State.atKing;
            troopIndex.Add(troopGetIndex);
            troopID = troopIndex.IndexOf(troopGetIndex);
        }
    }

    public static GameObject troopAboutToHire;


    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!system.isPaused)
        {
            chargingPublic = charging;
            stateText = state.ToString();

            health();

            if (Input.GetKeyDown(KeyCode.L))
            {
                troopIndex.Clear();
                troopsTalkingTo.Clear();
            }

            switch (state)
            {
                case State.wandering:

                cc.enabled = false;
                GetComponent<CapsuleCollider>().enabled = true;
                enableAgent();

                    if (allowTalk == true)
                    {

                        lmao.enabled = true;
                        var lookDir = player.transform.position-transform.position;
                        lookDir.y = 0; // keep only the horizontal direction
                        transform.rotation = Quaternion.LookRotation(lookDir);        
                        
                        {
                            if (Input.GetKeyDown(KeyCode.F) && isTalking == false)
                            {
                                talkingToTroop = gameObject;
                                setNameInTextBox = gameObject.name;
                                isTalking = true;
                            }

                            
                            if(Input.GetMouseButtonDown(1))
                            {
                                Hire();
                            }
                        }
                    }
                    else
                    {
                        if (job == "guard")
                        {
                            wasWandering = true;
                            troopFind_ = StartCoroutine(troopFind(15.5f));

                            if (foundEnemy != null)
                            {
                                if (Vector3.Distance(foundEnemy.transform.position, transform.position) < 25)
                                {
                                    badguy = foundEnemy;
                                    enemyScript = foundEnemyScript;

                                    broStartAttacking = StartCoroutine(attackingEnemy());
                                }
                            }
                        }

                        lmao.enabled = false;

                    }

                    canvas.enabled = false;

                    if (allowTalk == true)
                    {
                        ai.speed = 0;
                    }
                    else
                    {
                        ai.speed = 3.8f;
                    }

                    timer += Time.deltaTime;

                    wanderTimer = Random.Range(3, 7);

                    if (timer >= wanderTimer && ai.isOnNavMesh)
                    {
                        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                        ai.SetDestination(newPos);
                        timer = 0;
                    }
                    break;

                ///////////////////////////////////////

                case State.atKing:

                AtKing();

                    break;

                case (State.charging):

                break;

                case (State.attacking):
                
                    break;

                case (State.jumping):

                StopCoroutine(startChargingDude);
                StopCoroutine(waitABit);

                beforeJumpPosition = gameObject.transform.position;

                if (canJump && !troopReturning)
                {
                    disableAgent();

                    canJump = false;
                    transform.DOJump(lolTarget.position, 5, 1, 0.7f, false).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        chargeCheck = false;
                        troopFind_ = StartCoroutine(troopFind(7f));

                    });{}
                }
                break;
            }

            if (troopIndex.Count > troopMaxTotal)
            {
                troopIndex.RemoveRange((int) troopMaxTotal-1, troopIndex.Count-1);

                Debug.Log("Trying to reorganize troops!!!");
            }
        }
    }

    void moveToSlot()
    {
        if (!canGoToKing || state != State.atKing || playerMovement.isInDoor)
        return;

        troopNumber = slotManager.slots[troopID];
    }

    void moveToSlott(GameObject destination)
    {
        var cc = GetComponent<CharacterController>();
        var offset = destination.transform.position - transform.position;

        var lookDir = destination.transform.position-transform.position;
        lookDir.y = 0; // keep only the horizontal direction
        transform.rotation = Quaternion.LookRotation(lookDir);    
        //Get the difference.
        if (offset.magnitude > .1f)
        {
            //If we're further away than .1 unit, move towards the target.
            offset = destination.transform.position - transform.position;
            offset = offset.normalized * movementSpeed;
            //normalize it and account for movement speed.
            cc.Move(new Vector3(offset.x, -0.01f, offset.z) * Time.deltaTime);
            //actually move the character.
        }

        useGravity();
    }

    public float timer_;

    void AtKing()
    {
        if (playerMovement.isInDoor)
        return;

        lmao.enabled = false;
        ai.speed = 25;


        if (!troopIndex.Contains(troopGetIndex))
        {
            state = State.wandering;
        }

        moveToSlot();

        distanceFromSlot = Vector3.Distance(gameObject.transform.position, troopNumber.transform.position);

        if (distanceFromSlot > 30 || ai.isOnOffMeshLink)
        {
            timer_ += 1;
        }
        else
        {
            timer_ = 0;
        }

        if (timer_ > 200)
        {
            ai.Warp(player.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ai.Warp(player.transform.position);
        }

        if (distanceFromSlot <= 13)
        {
            // troopRenderer.material = aiDisabled;

            disableAgent();

            cc.enabled = true;
            GetComponent<CapsuleCollider>().enabled = false;
            Physics.IgnoreLayerCollision(11, 11, true);

            movementSpeed = Random.Range(22.7f, 25.3f);

            cc.radius = 0.3f;

            moveToSlott(troopNumber);
        }
        else
        {
            // troopRenderer.material = aiEnabled;

            enableAgent();

            cc.enabled = false;

            cc.radius = 0.5f;

            ai.SetDestination(troopNumber.transform.position);
        }

        if (troopNumber == null && troopReturning == false)
        {
            Debug.LogError("what the fuck");
            state = State.wandering;
            troopIndex.Remove(troopGetIndex);
        }

        if (troopID < 3 || troopHealth < maxtroopHealth)
        {
            canvas.enabled = true;
        }
        else { canvas.enabled = false; }

        {
            if (Input.GetMouseButtonDown(0))
            {
                if (canGoToKing && canCharge == true && isTalking == false && troopID == 0)
                {
                    Charge();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            troopIndex.Remove(troopGetIndex);
            troopIDIndex = 0;
            troopGetIndex = 0;
            state = State.wandering;
        }
        
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (troopID == 0)
                {
                    troopIndex.Remove(troopGetIndex);
                    troopIndex.Add(troopGetIndex);
                }
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (troopID == troopIndex.Count - 1)
                {
                    troopIndex.Remove(troopGetIndex);
                    troopIndex.Insert(0, troopGetIndex);
                }
            }

        troopID = troopIndex.IndexOf(troopGetIndex);
    }

    public Vector3 beforeJumpPosition;

    public Transform lolTarget;
    bool canJump = true;

    public static bool displayDeathMessage;
    public static List<string> troopDeathName = new List<string>();

    private void LateUpdate()
    {
        //shit i died
        if (troopHealth <= 0)
        {
            charging = false;

            if (badguy != null)
            {
               enemyScript.beingAttacked = false;
               badguy = null;
            }
            StopAllCoroutines();
            if (state == State.atKing)
            {
                troopIndex.Remove(troopGetIndex);
            }

            if (nearestEnemy != null)
            {
                getEnemyScript.canAttack = false;
            }

            setNameInTextBox = gameObject.name;
            displayDeathMessage = true;
            gameObject.SetActive(false);
        }

        if (Gamepad.current != null)
        {
            if (state == State.charging)
            {
                if (Gamepad.current.buttonWest.wasPressedThisFrame && troopReturning == false && playerMovement.isInDoor == false)
                {
                    StartCoroutine(returnToPlayer());
                }
            }
            else
            if (state == State.attacking && canJump == true)
            {
                if (Gamepad.current.buttonWest.wasPressedThisFrame && troopReturning == false && playerMovement.isInDoor == false)
                {
                    StopCoroutine(broStartAttacking);
    
                    StartCoroutine(returnToPlayer());
                }
                
            }
        }
        else if (state == State.charging)
        {
            if (Input.GetMouseButtonDown(1) && troopReturning == false && playerMovement.isInDoor == false && !wasWandering && state != State.wandering && chargeCheck)
            {
                StartCoroutine(returnToPlayer());
            }
        }
        else
        if (state == State.attacking && canJump == true)
        {
            if (Input.GetMouseButtonDown(1) && troopReturning == false && playerMovement.isInDoor == false && !wasWandering && state != State.wandering)
            {
                if (enemyScript != null)
                {
                    enemyScript.beingAttacked = false;
                }
                StopCoroutine(broStartAttacking);

                StartCoroutine(returnToPlayer());
            }
            
        }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <returns></returns>
    ///

    public static int troopIDIndex = 0;

    public int troopGetIndex;

    public static bool unhire;
    [SerializeField] GameObject playersFeet;
    
    void Charge()
    {
        charging = true;
        state = State.charging;
        battlin = true;
        canGoToKing = false;

        charging = true;

        setCursorPosition = cursorObject.transform.position;

        disableAgent();
        canCharge = false;
        startChargingDude = StartCoroutine(startCharging());     
    }

    void health()
    {
        healthValue.fillAmount = troopHealth / maxtroopHealth;
    }

    public void setListHealth(int getMaxHealth, float getTroopHealth)
    {
        troopHealth = getTroopHealth;
        maxtroopHealth = getMaxHealth;
        listHealth = getMaxHealth;
        listHealth -= 3;
        healthTex.sprite = myTextures[listHealth];
    }

     bool troopReturning;



    public IEnumerator returnToPlayer()
    {
        Debug.Log("Returned to player");
        if (troopReturning == false && !wasWandering)
        {
            StopCoroutine(troopFind(0));

            setObstacleDamageSpeed = 1.3f;

            troopReturning = true;

            if (canJump == false) { canJump = true; }

            if (state == State.jumping) { state = State.charging; }

            if (state == State.charging)
            {
                if (waitABit != null && startChargingDude != null)
                {
                    StopCoroutine(waitABit);
                    StopCoroutine(startChargingDude);
                }

                lmfao.enabled = false;
            }

            if (state == State.attacking)
            {
                StopCoroutine(broStartAttacking);
                if (enemyScript.troopToEnemySlots.Contains(gameObject))
                {
                    enemyScript.troopToEnemySlots.Remove(gameObject);
                }
            }

            if (badguy != null && enemyScript != null)
            {
                enemyScript.currentTroops--;
                enemyScript.beingAttacked = false;
            }
            ai.radius = 0.1f;

            while (playerMovement.isInDoor != false)
            {
                yield return null;
            }
    
            if (ai.isOnNavMesh == false && state != State.jumping)
            {
                disableAgent();
                cc.enabled = true;
                while (IsAgentOnNavMesh(gameObject) == false)
                {
                    MoveTowardsTarget(player.transform.position);
                    useGravity();
                    yield return null;
                }
                cc.enabled = false;
                enableAgent();
            }
            else {enableAgent();}

            ai.speed = 25;

            while (Vector3.Distance(transform.position, player.transform.position) > 1.5f)
            {
                enableAgent();

                cc.enabled = false;

                cc.radius = 0.5f;

                ai.SetDestination(player.transform.position);

                yield return null;
            }
    
            canCharge = false;
            canAttack = true;
            canCharge = true;
            canGoToKing = true;
            battlin = false;
            badguy = null;
            targetObjectPosition = null;
            troopIndex.Add(troopGetIndex);
            troopID = troopIndex.IndexOf(troopGetIndex);
            state = State.atKing;
            charging = false;
            yield return new WaitForSeconds(1);
            troopReturning = false;
        }
    }

    public void returnOnButton()
    {
        if (troopReturning == false)
        StartCoroutine(returnToPlayer());
    }

        public IEnumerator recieveDamage()
        {
            troopHealth--;
            if (state == State.attacking && !wasWandering)
            {
                StopCoroutine(broStartAttacking);

                if (enemyScript.troopToEnemySlots.Contains(gameObject))
                {
                    enemyScript.troopToEnemySlots.Remove(gameObject);
                }
                
                yield return new WaitForSeconds(1);
                StartCoroutine(returnToPlayer());
            }
        }

    ///////////////////////////////////////////////////////////////////////////////////////////////////

    public GameObject badguy;

    public GameObject targetObjectPosition;

    public enemyWander enemyScript;

    public bool canAttack = true;

    public static int troopsAttacking = 0;
    //////////////////////////////////////////////// /////////////////////////////////////////////////

    bool wasWandering;

    public IEnumerator attackingEnemy()
    { 
        bool hasUsedJumpSlots = false;

        Debug.Log("<color=red>Started Attacking</color>");

        chargeCheck = false;
        if (state == State.jumping) { state = State.attacking; }
        enableAgent();
        cc.enabled = false;
        state = State.attacking;

        if (!wasWandering)
        {
            StopCoroutine(waitABit);
            StopCoroutine(startChargingDude);
        }

        enemyScript.troopToEnemySlots.Add(gameObject);

        GameObject slotObject = enemyScript.slotList[enemyScript.troopToEnemySlots.IndexOf(gameObject)];

        if (slotObject.tag == "jumpSlot")
        {
            disableAgent();
            transform.DOJump(slotObject.transform.position, 5, 1, 0.7f, false).SetEase(Ease.Linear);
            hasUsedJumpSlots = true;
        }
        else
        {
            ai.SetDestination(slotObject.transform.position);
            GetComponent<CapsuleCollider>().enabled = true;
        }
        

        while (enemyScript.health > 0 && !troopReturning && badguy != null)
        {
            while (Vector3.Distance(transform.position, badguy.transform.position) > 2f && !enemyScript.isObstacle && !hasUsedJumpSlots)
            {
                ai.speed = 15;
                ai.SetDestination(slotObject.transform.position);
                yield return null;
            }

            enemyScript.beingAttacked = true;
            ai.radius = 0.3f;
            if (enemyScript.isObstacle)
            {
                yield return new WaitForSeconds(setObstacleDamageSpeed);
            }
            else
            {
                yield return new WaitForSeconds(setDamageSpeed);
            }
            if (badguy != null)
            {
                ai.speed = 15;
            }
            
            audioLol.pitch = Random.Range(0.70f, 1.30f);
            audioLol.volume = PlayerPrefs.GetFloat("Sfx Value");
            audioLol.Play();
            
            DOVirtual.Float(enemyScript.health, enemyScript.health - 10, 0.15f, Bro).SetEase(Ease.OutSine);
            charging = true;
        }

        

        if (wasWandering)
        {
            foundEnemy = null;
            foundEnemyScript = null;
            state = State.wandering;
        }

        if (hasUsedJumpSlots)
        {
            transform.DOJump(player.transform.position, 5, 1, 0.7f, false).SetEase(Ease.Linear).OnComplete(() =>
            {
                hasUsedJumpSlots = false;
                enableAgent();
            });{};

        }

        yield return new WaitForSeconds(0.5f);

        enemyScript.troopToEnemySlots.Remove(gameObject);

        troopFind_ = StartCoroutine(troopFind(5f));
    }

    IEnumerator bruh()
    {
        while (enemyScript.health > 0)
        {
            ai.SetDestination(badguy.transform.position);
            yield return null;
        }
    }

        void Bro(float x)
    {
        if (badguy != null)
         enemyScript.health = x;
    }

    float onMeshThreshold = 2f;
    public bool IsAgentOnNavMesh(GameObject agentObject)
{
    Vector3 agentPosition = agentObject.transform.position;
    NavMeshHit hit;

    // Check for nearest point on navmesh to agent, within onMeshThreshold
    if (NavMesh.SamplePosition(agentPosition, out hit, onMeshThreshold, NavMesh.AllAreas))
    {
        // Check if the positions are vertically aligned
        if (Mathf.Approximately(agentPosition.x, hit.position.x)
            && Mathf.Approximately(agentPosition.z, hit.position.z))
        {
            // Lastly, check if object is below navmesh
            return agentPosition.y >= hit.position.y;
        }
    }

    return false;
}

    void MoveTowardsTarget(Vector3 target)
    {
        var cc = GetComponent<CharacterController>();
        var offset = target - transform.position;
        //Get the difference.
        if (offset.magnitude > .1f)
        {
            //If we're further away than .1 unit, move towards the target.
            //The minimum allowable tolerance varies with the speed of the object and the framerate. 
            // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
            offset = offset.normalized * moveSpeed;
            //normalize it and account for movement speed.
            cc.Move(offset * Time.deltaTime);
            //actually move the character.
        }
    }

    public static int count;

    IEnumerator playerStopMovement()
    {
        if (count < 3)
        {
        count++;
        }

        while (count > 1)
        {
            playerMovement.allowMovement = false;
            yield return new WaitForSeconds(0.5f);

            if (count > 0)
            {
                count--;
            }

            yield return null;
        }

        playerMovement.allowMovement = true;
    }

    public bool chargeCheck = false;

    IEnumerator DontChargeYet()
    {
        yield return new WaitForSeconds(0.3f);
    }


    IEnumerator startCharging()
    {
        var offsetToPlayer = transform.position - playerMovement.player_.transform.position;

        GetComponent<CapsuleCollider>().enabled = true;
        Physics.IgnoreLayerCollision(11, 11, false);

        while (Vector3.Distance(transform.position, playerMovement.player_.transform.position) > 1f)
        {
            if (offsetToPlayer.magnitude > .1f)
            {
                //If we're further away than .1 unit, move towards the target.
                //The minimum allowable tolerance varies with the speed of the object and the framerate. 
                // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
                offsetToPlayer = transform.position - playerMovement.player_.transform.position;
                offsetToPlayer = offsetToPlayer.normalized * moveSpeed * 2;
                //normalize it and account for movement speed.
                cc.Move(new Vector3(-offsetToPlayer.x, -0.01f, -offsetToPlayer.z) * Time.deltaTime);

                var lookDir = offsetToPlayer-transform.position;
                lookDir.y = 0;
                transform.rotation = Quaternion.LookRotation(lookDir);
                
                useGravity();
            }
            yield return null;
        }

        troopIndex.Remove(troopGetIndex);

        chargeCheck = true;
        canCharge = false;
        
        if (Gamepad.current != null)
        {
            StartCoroutine(playerStopMovement());
        }

        cc.enabled = true;
        waitABit = StartCoroutine(ifWaitingTooLong());
        var offset = transform.position - setCursorPosition;
        distance = Vector3.Distance(offset, transform.position);

        while (badguy == null)
        {
            if (offset.magnitude > .1f)
            {
                //If we're further away than .1 unit, move towards the target.
                //The minimum allowable tolerance varies with the speed of the object and the framerate. 
                // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
                offset = transform.position - setCursorPosition;
                offset = offset.normalized * moveSpeed;
                //normalize it and account for movement speed.
                cc.Move(new Vector3(-offset.x, -0.01f, -offset.z) * Time.deltaTime);

                var lookDir = setCursorPosition-transform.position;
                lookDir.y = 0;
                transform.rotation = Quaternion.LookRotation(lookDir);
                
                useGravity();
            }

            LayerMask mask = 1 << 17;

            troopFind_ = StartCoroutine(troopFind(1f));
            
            yield return null;
        }

        

        cc.enabled = false;
        StopCoroutine(waitABit);

        chargeCheck = false;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(returnToPlayer());
    }

    Collider[] hitColliders;

    IEnumerator troopFind(float searchDistance)
    {
        if (state == State.attacking)
        {
            state = State.charging;
            StopCoroutine(broStartAttacking);
        }

        LayerMask mask = 1 << 17;
         
        hitColliders = Physics.OverlapSphere(transform.position, searchDistance, mask);

        setObstacleDamageSpeed = 1.3f;

        if (hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                targetObjectPosition = hitCollider.gameObject;

                Physics.IgnoreLayerCollision(11, 11, true);
    
                badguy = targetObjectPosition.GetComponentInParent<enemyWander>().gameObject;
    
                enemyScript = badguy.GetComponent<enemyWander>();
    
                if (badguy != null && !troopReturning)
                {
                    if (enemyScript.isSmallWood && canCut && !enemyScript.troopEnemyID && !wasWandering)
                    {
                        broStartAttacking = StartCoroutine(attackingEnemy());
                    }
                    else if (enemyScript.isSign && canBuild && !enemyScript.troopEnemyID && !wasWandering)
                    {
                        broStartAttacking = StartCoroutine(attackingEnemy());
                    } 
                    else if (enemyScript.isSmallRock && canCut && !enemyScript.troopEnemyID && !wasWandering)
                    {
                        if (canMine) { setObstacleDamageSpeed = 0.5f; }
                        broStartAttacking = StartCoroutine(attackingEnemy());
                    }
                    else if (enemyScript.isRock && canMine && !enemyScript.troopEnemyID && !wasWandering)
                    {
                        setObstacleDamageSpeed = 0.5f;
                        broStartAttacking = StartCoroutine(attackingEnemy());
                    }
                    else if (enemyScript.isHole && canDig && !enemyScript.troopEnemyID && !wasWandering)
                    {
                        if (job == "farmer") {setObstacleDamageSpeed = 0.5f;}
                        broStartAttacking = StartCoroutine(attackingEnemy());
                    }
                    else if (!enemyScript.isObstacle && !enemyScript.troopEnemyID)
                    {
                        if (wasWandering)
                        {
                            foundEnemy = badguy;
                            foundEnemyScript = enemyScript;
                        }

                        broStartAttacking = StartCoroutine(attackingEnemy());
                    }
                    else if (!wasWandering)
                    {
                        Debug.Log("gaming");
                        Physics.IgnoreLayerCollision(11, 11, true);
                        chargeCheck = false;
                        yield return new WaitForSeconds(0.7f);
                        lmfao.enabled = true;
                        StopCoroutine(startChargingDude);
                        yield return new WaitForSeconds(1.5f);
                        lmfao.enabled = false;
    
                        StartCoroutine(returnToPlayer());
                    } 
                }
            }
        }
        else if (!chargeCheck)
        {
            if (ai.enabled == false) { enableAgent(); }

            if (wasWandering)
            {
                state = State.wandering;
                wasWandering = false;
                ai.radius = 0.1f;
                charging = false;

            }
            else if (state != State.wandering)
            {
                Debug.Log("awa");
                StartCoroutine(returnToPlayer());
            }
        }
        
    }

    IEnumerator ifWaitingTooLong()
    {
        yield return new WaitForSeconds(0.7f);
        lmfao.enabled = true;
        StopCoroutine(startChargingDude);
        yield return new WaitForSeconds(1.5f);
        lmfao.enabled = false;

        StartCoroutine(returnToPlayer());
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;

    }

        void disableAgent()
    {
        ai.enabled = false;
        ai.updatePosition = false;
        ai.updateRotation = false;
    }

    void enableAgent()
    {
        ai.enabled = true;
        ai.updatePosition = true;
        ai.updateRotation = true;
    }

    void useGravity()
    {
        //REeset the MoveVector
        moveVector = Vector3.zero;

        //Check if cjharacter is grounded
        if (cc.isGrounded == false)
        {
            //Add our gravity Vecotr
            moveVector += Physics.gravity;
        }

        //Apply our move Vector , remeber to multiply by Time.delta
        cc.Move(moveVector * Time.deltaTime);

    }
}
