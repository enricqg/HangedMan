using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMenuView : MonoBehaviour
{
    private InitMenuViewModel _viewModel;

    public void SetViewModel(InitMenuViewModel viewModel)
    {
        _viewModel = viewModel;
    }
}
