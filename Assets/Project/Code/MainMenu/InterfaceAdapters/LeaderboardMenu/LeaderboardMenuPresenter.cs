using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Code;

public class LeaderboardMenuPresenter: IDisposable
{
    private LeaderboardMenuViewModel _viewModel;
    private IEventDispatcherService _eventDispatcherService;

    public LeaderboardMenuPresenter(LeaderboardMenuViewModel viewModel,
        IEventDispatcherService eventDispatcherService)
    {
        _viewModel = viewModel;
        _eventDispatcherService = eventDispatcherService;

        _eventDispatcherService.Subscribe<List<KeyValuePair<string, Dictionary<string, string>>>>(OnLeaderboardUpdated);
    }

    public void Dispose()
    {
        _eventDispatcherService.Unsubscribe<List<KeyValuePair<string, Dictionary<string, string>>>>(OnLeaderboardUpdated);
    }

    void OnLeaderboardUpdated(List<KeyValuePair<string, Dictionary<string, string>>> values)
    {
        _viewModel.UpdateValues.Execute(values);
    }
}
