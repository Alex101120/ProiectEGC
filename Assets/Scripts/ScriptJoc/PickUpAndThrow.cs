using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    [SerializeField] private float maxPickupMass = 5f;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float throwTorque = 5f;
    [SerializeField] private float lerpSpeed = 10f;

    private GameObject heldObject;
    private Rigidbody heldObjectRigidbody;
    private Vector3 targetObjectPosition;
    private float timeHeld;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.rigidbody != null && hit.rigidbody.mass <= maxPickupMass)
                {
                    heldObject = hit.rigidbody.gameObject;
                    heldObjectRigidbody = heldObject.GetComponent<Rigidbody>();
                    heldObjectRigidbody.useGravity = false;
                    timeHeld = 0f;
                }
            }
        }

       
        if (heldObject != null)
        {
            targetObjectPosition = transform.position + Camera.main.transform.forward * 2f;
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetObjectPosition, Time.deltaTime * lerpSpeed);
            timeHeld += Time.deltaTime;
        }

       
        if (Input.GetMouseButtonUp(0))
        {
            if (heldObject != null)
            {
                heldObjectRigidbody.useGravity = true;
                if (timeHeld >= 3f)
                {
                    heldObjectRigidbody.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
                    heldObjectRigidbody.AddTorque(Random.insideUnitSphere * throwTorque);
                }
                heldObject = null;
                heldObjectRigidbody = null;
            }
        }
    }
}
