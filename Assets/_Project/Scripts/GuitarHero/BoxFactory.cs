using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFactory : MonoBehaviour
{
    [SerializeField] private Box _boxPrefab;

    private List<Box> _boxList;

    private Stack<Box> _stack = new Stack<Box>();

    private void OnEnable()
    {
        GuitarHeroManager.OnGameSuccessEvent += OnGameSuccess;
    }

    private void OnGameSuccess()
    {
        for (int i = 0; i < _boxList.Count; i++)
        {
            _boxList[i].gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        _stack = new Stack<Box>();
        _boxList = new List<Box>();
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
        {
            box = Instantiate(_boxPrefab);
            _boxList.Add(box);
        }

        box.gameObject.SetActive(true);
        return box;
    }

}
