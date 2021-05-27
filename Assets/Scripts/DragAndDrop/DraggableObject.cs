using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    DroppableObject droppableObject;
    Vector2 initialPos;

    string match;
    bool isMatched;
    bool canMatch;

    void Start() {
        initialPos = transform.position;
        isMatched = canMatch = false;
    }

    private void OnMouseDrag() 
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
    private void OnMouseUp() 
    {
        if (!canMatch)
            return;

        MatchObject();            
    }

    public void MatchObject() 
    {
        if (droppableObject.GetMatchString() != match)
            return;
        
        transform.position = droppableObject.transform.position;
        isMatched = true;
    }

    public void AbleToMatch(bool canMatch, DroppableObject droppableObject) 
    {
        this.canMatch = canMatch;
        this.droppableObject = droppableObject;
    }
}
