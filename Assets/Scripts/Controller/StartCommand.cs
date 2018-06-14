using strange.extensions.command.impl;
using UnityEngine;

public class StartCommand:EventCommand
{
    public override void Execute()
    {
        Debug.Log( "StrangeIOC context started!!" );
    }
}