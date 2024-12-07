using UnityEngine;
 
public class DragAndDrop : MonoBehaviour

{

    private Vector3 offset;

    private Camera mainCamera;

    private Rigidbody rb;

    void Start()

    {

        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody>();

    }

    void OnMouseDown()

    {

        rb.isKinematic = true; // Désactiver la physique temporairement

        offset = transform.position - GetMouseWorldPos();

    }

    void OnMouseDrag()

    {

        transform.position = GetMouseWorldPos() + offset;

    }

    void OnMouseUp()

    {

        rb.isKinematic = false; // Réactiver la physique

    }

    private Vector3 GetMouseWorldPos()

    {

        Vector3 mouseScreenPos = Input.mousePosition;

        mouseScreenPos.z = mainCamera.WorldToScreenPoint(transform.position).z;

        return mainCamera.ScreenToWorldPoint(mouseScreenPos);

    }

}

