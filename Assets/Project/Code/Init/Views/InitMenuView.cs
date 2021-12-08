using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMenuView : MonoBehaviour
{
    private InitMenuViewModel _viewModel;

    public void SetViewModel(InitMenuViewModel viewModel)
    {
        _viewModel = viewModel;
    }
}
