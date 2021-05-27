using UnityEngine;

public class DroppableObject : MonoBehaviour
{
    string match;

    DraggableObject draggableObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        draggableObject = other.GetComponent<DraggableObject>();
        draggableObject.AbleToMatch(true, this);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        draggableObject.AbleToMatch(false, null);
        draggableObject = null;
    }

    public string GetMatchString() 
    {
        return match;
    }
}
