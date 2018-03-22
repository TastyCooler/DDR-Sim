using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour {

    public float minGroundNormalY = 0.065f;
    public float gravityModifier = 1f;

    protected Vector2 targetVelocity;
    protected Vector2 velocity;
    protected Rigidbody2D myRigidbody;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    protected bool grounded;
    protected Vector2 groundNormal;
    public bool destroyed;
    public AudioClip grab;
    protected const float minMoveDistance = 0.0001f;
    protected const float shellRadius = 0.01f;
    private void OnEnable()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
       
    }

    private void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;
 
        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if(distance > minMoveDistance)
        {
            int count = myRigidbody.Cast(move, contactFilter, hitBuffer, distance + shellRadius);

            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if(projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance; 
            }
        }

        myRigidbody.position = myRigidbody.position + move;
    }

    float depthIntoScene = 10f;

    float defaultDepthIntoScene = 5f;
    float selectScale = 0.16f;

    void MoveToMouseAtSpecifiedDepth(float depth)
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = depth;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        this.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, mouseWorldPosition.z);

    }

    //OnMouseDown is called when the user has pressed the mouse button while over GUIElement or Collider.
    public void OnMouseDown()
    {
        //Get the vector from the camera to the object
        Vector3 headingToObject = this.transform.position - Camera.main.transform.position;
        //find the projection on the forward vector of the camera
        depthIntoScene = Vector3.Dot(headingToObject, Camera.main.transform.forward);
        AudioSource.PlayClipAtPoint(grab, transform.position);
    }
    // OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mousebutton

    public void OnMouseDrag()
    {
        // when the mouse button is held and we move the mouse, move the object along with it
        // this provides simple click and drag functionality
        
        MoveToMouseAtSpecifiedDepth(depthIntoScene);
    }

    //OnMouseEnter is called when the mouse entered the GUIElement or Collider.
    public virtual void OnMouseEnter()
    {
        //change the scale of the object to make it clear it's been selected
        this.transform.localScale = new Vector3(selectScale, selectScale, selectScale);
    }

    // OnMouseExit is called when the mouse is not any longer over the GUIElement or Collider.
    public virtual void OnMouseExit()
    {
        //reset the scale to default when the object is no longer selected
        this.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
    }
   

}
