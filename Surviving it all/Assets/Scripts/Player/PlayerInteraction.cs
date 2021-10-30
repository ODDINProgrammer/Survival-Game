using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float interaction_distance = 1f;

    [SerializeField] private TextMeshProUGUI instrucion_text;

    private void Update()
    {
        //  SHOOT A RAY TO THE MIDLLE OF THE SCREEN
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interaction_distance))
        {
            InteractableObject interactable_object = hit.collider.GetComponent<InteractableObject>();

            //  IF WE FOUND SOMETHING TO INTERACT WITH
            if (interactable_object != null)
            {
                instrucion_text.SetText(interactable_object.GetInteractionInstruction().ToString());
                if (Input.GetKeyDown(KeyCode.E))
                    interactable_object.Interact();
            }
        }
        else
        {
            instrucion_text.SetText("");
        }
    }
}
