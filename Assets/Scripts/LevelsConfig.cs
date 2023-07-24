using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelsConfig : ScriptableObject
{
    [SerializeField]
    private List<TextAsset> _levels = new();

    public IReadOnlyList<TextAsset> Levels => _levels;
}