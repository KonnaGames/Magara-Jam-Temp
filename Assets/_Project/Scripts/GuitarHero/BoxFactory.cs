using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFactory : MonoBehaviour
{
    [SerializeField] private Box _boxPrefab;

    private Stack<Box> _stack = new Stack<Box>();

    private void Awake()
    {
        _stack = new Stack<Box>();
    }

    public Box Create()
    {
        Box box = Pop();
        return box;
    }

    public void Push(Box box)
    {
        box.gameObject.SetActive(false);
        _stack.Push(box);
    }

    public Box Pop()
    {
        Box box;

        if(_stack.Count > 0)
            box =_stack.Pop();
        else
            box = Instantiate(_boxPrefab);

        box.gameObject.SetActive(true);
        return box;
    }

}
