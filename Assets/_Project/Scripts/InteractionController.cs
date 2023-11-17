using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact();
}
public class InteractionController : MonoBehaviour
{
    [SerializeField] private Image interactImage;
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactRange;

    private IInteractable interactable1;


    private void Update()
    {
        interactable1 = null;
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitObject, interactRange))
        {
            if (hitObject.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactable1 = interactable;
                Debug.Log("Interact");
                interactImage.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }            
        }
        if (interactable1 == null)
        {
            interactImage.gameObject.SetActive(false);
        }
    }
}
