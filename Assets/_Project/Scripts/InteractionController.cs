using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

interface IInteractable
{
    public void Interact();
    public string interactionName { get;}
    public bool isInteracted { get;}
}
public class InteractionController : MonoBehaviour
{
    [SerializeField] private Image interactImage;
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactRange;
    [SerializeField] private TextMeshProUGUI interactionText;

    private IInteractable interactable1;



    private void Update()
    {
        interactable1 = null;
        Ray r = new Ray(interactorSource.position, interactorSource.forward);

        if (Physics.Raycast(r, out RaycastHit hitObject, interactRange))
        {
            if (hitObject.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.isInteracted)
                {
                    interactImage.gameObject.SetActive(false);
                    return;
                }
                interactable1 = interactable;
                interactionText.text = interactable.interactionName + " (E)";
                interactImage.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && !interactable.isInteracted)
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
