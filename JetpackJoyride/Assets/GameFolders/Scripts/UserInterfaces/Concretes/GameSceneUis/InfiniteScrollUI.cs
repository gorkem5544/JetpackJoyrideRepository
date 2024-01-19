using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScrollUI : MonoBehaviour
{
    [SerializeField] ScrollRect _scrollRect;
    [SerializeField] Transform _transform;
    [SerializeField] float _outOfRounds = 0;
    [SerializeField] float _childWidth = 125f;
    [SerializeField] float _childHeigh = 125f;
    [SerializeField] float _itemSpace = 10f;
}
