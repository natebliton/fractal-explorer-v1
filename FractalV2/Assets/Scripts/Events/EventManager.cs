using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    static List<HUD> gameOverInvokers = new List<HUD>();
    static List<UnityAction> gameOverListeners = new List<UnityAction>();

    static List<WorldRevealer> enterWorldInvokers = new List<WorldRevealer>();
    static List<UnityAction<DestinationList.Worlds>> enterWorldListeners = new List<UnityAction<DestinationList.Worlds>>();

    static List<WorldRevealer> zoomCameraInvokers = new List<WorldRevealer>();
    static List<UnityAction<float>> zoomCameraListeners = new List<UnityAction<float>>();
 /*
    static List<FreezerBlock> freezerInvokers = new List<FreezerBlock>();
    static List<UnityAction> freezerListeners = new List<UnityAction>();

    static List<SpeedupBlock> speedupInvokers = new List<SpeedupBlock>();
    static List<UnityAction> speedupListeners = new List<UnityAction>();

    static List<SpeedupEffectMonitor> speedupSlowingInvokers = new List<SpeedupEffectMonitor>();
    static List<UnityAction> speedupSlowingListeners = new List<UnityAction>();

    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<float>> pointsAddedListeners = new List<UnityAction<float>>();

    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners = new List<UnityAction>();

    static List<HUD> spawnBallInvokers = new List<HUD>();
    static List<UnityAction> spawnBallListeners = new List<UnityAction>();

    static List<HUD> lastBallRemovedInvokers = new List<HUD>();
    static List<UnityAction> lastBallRemovedListeners = new List<UnityAction>();


    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction<BlockType>> blockDestroyedListeners = new List<UnityAction<BlockType>>();
*/
    #endregion

    #region public methods

        /// <summary>
    /// add enter world invoker
    /// </summary>
    /// <param name="script"></param>
    public static void AddEnterWorldInvoker(WorldRevealer script)
    {
        enterWorldInvokers.Add(script);
        foreach (UnityAction<DestinationList.Worlds> listener in enterWorldListeners)
        {
            script.AddEnterWorldEvent(listener);
        }
    }

    /// <summary>
    /// enter world listener adding
    /// </summary>
    /// <param name="listener"></param>
    public static void AddEnterWorldListener(UnityAction<DestinationList.Worlds> listener) {
        enterWorldListeners.Add(listener);
        foreach (WorldRevealer script in enterWorldInvokers)
        {
            script.AddEnterWorldEvent(listener);
        }
    }

        /// <summary>
    /// add camera zoom invoker
    /// </summary>
    /// <param name="script"></param>
    public static void AddZoomCameraInvoker(WorldRevealer script)
    {
        zoomCameraInvokers.Add(script);
        foreach (UnityAction<float> listener in zoomCameraListeners)
        {
            script.AddZoomCameraEvent(listener);
        }
    }

    /// <summary>
    /// enter world listener adding
    /// </summary>
    /// <param name="listener"></param>
    public static void AddZoomCameraListener(UnityAction<float> listener)
    {
        zoomCameraListeners.Add(listener);
        foreach (WorldRevealer script in zoomCameraInvokers)
        {
            script.AddZoomCameraEvent(listener);
        }
    }

/*
    /// <summary>
    /// Adds the freezer invoker.
    /// </summary>
    /// <param name="script">Script.</param>
    public static void AddFreezerInvoker(FreezerBlock script)
    {
        freezerInvokers.Add(script);

        foreach (UnityAction listener in freezerListeners)
        {
            script.AddFreezerEventsListener(listener);
        }
    }

    /// <summary>
    /// Adds the freezer listener.
    /// </summary>
    /// <param name="handler">Handler.</param>
    public static void AddFreezerListener(UnityAction handler)
    {
        freezerListeners.Add(handler);

        foreach (FreezerBlock script in freezerInvokers)
        {
            script.AddFreezerEventsListener(handler);
        }
    }

    /// <summary>
    /// Adds the speedup invoker.
    /// </summary>
    /// <param name="script">Script.</param>
    public static void AddSpeedupInvoker(SpeedupBlock script)
    {
        speedupInvokers.Add(script);

        foreach (UnityAction listener in speedupListeners)
        {
            script.AddSpeedupEventsListener(listener);
        }

    }

    /// <summary>
    /// Adds the speedup listener.
    /// </summary>
    /// <param name="handler">Handler.</param>
    public static void AddSpeedupListener(UnityAction handler)
    {
        speedupListeners.Add(handler);

        foreach (SpeedupBlock script in speedupInvokers)
        {
            script.AddSpeedupEventsListener(handler);
        }

    }

    /// <summary>
    /// Adds the speedup invoker.
    /// </summary>
    /// <param name="script">Script.</param>
    public static void AddSpeedupSlowingInvoker(SpeedupEffectMonitor script)
    {
        speedupSlowingInvokers.Add(script);

        foreach (UnityAction listener in speedupSlowingListeners)
        {
            script.AddSpeedupSlowingEventsListener(listener);
        }

    }

    /// <summary>
    /// Adds the speedup listener.
    /// </summary>
    /// <param name="handler">Handler.</param>
    public static void AddSpeedupSlowingListener(UnityAction handler)
    {
        speedupSlowingListeners.Add(handler);

        foreach (SpeedupEffectMonitor script in speedupSlowingInvokers)
        {
            script.AddSpeedupSlowingEventsListener(handler);
        }
    }

    /// <summary>
    /// Adds points added invoker
    /// </summary>
    /// <param name="script"></param>
    public static void AddPointsAddedInvoker(Block script)
    {
        pointsAddedInvokers.Add(script);

        foreach (UnityAction<float> listener in pointsAddedListeners)
        {
            script.AddPointsAddedEvent(listener);
        }
    }

    /// <summary>
    /// Adds points added listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddPointsAddedListener(UnityAction<float> listener)
    {
        pointsAddedListeners.Add(listener);

        foreach(Block script in pointsAddedInvokers)
        {
            script.AddPointsAddedEvent(listener);
        }
    }

    /// <summary>
    /// ball counting invoker adding
    /// </summary>
    /// <param name="script"></param>
    public static void AddBallLostInvoker(Ball script)
    {
        ballLostInvokers.Add(script);
        foreach (UnityAction listener in ballLostListeners)
        {
            script.AddBallLostEvent(listener);
        }
    }

    /// <summary>
    /// ball counting listener adding
    /// </summary>
    /// <param name="listener"></param>
    public static void AddBallLostListener(UnityAction listener)
    {
        ballLostListeners.Add(listener);
        foreach (Ball script in ballLostInvokers)
        {
            script.AddBallLostEvent(listener);
        }
    }

    /// <summary>
    /// spawn new ball event invoker adding
    /// </summary>
    /// <param name="script"></param>
    public static void AddSpawnBallEventInvoker(HUD script)
    {
        spawnBallInvokers.Add(script);
        foreach (UnityAction listener in spawnBallListeners)
        {
            script.AddSpawnBallEventsListener(listener);
        }
    }

    /// <summary>
    /// spawn new ball event listener adding
    /// </summary>
    /// <param name="listener"></param>
    public static void AddSpawnBallEventListener(UnityAction listener)
    {
        spawnBallListeners.Add(listener);
        foreach (HUD script in spawnBallInvokers)
        {
            script.AddSpawnBallEventsListener(listener);
        }

    }

    /// <summary>
    /// last ball removed event invoker adding
    /// </summary>
    /// <param name="script"></param>
    public static void AddLastBallRemovedInvoker(HUD script)
    {
        lastBallRemovedInvokers.Add(script);
        foreach (UnityAction listener in lastBallRemovedListeners)
        {
            script.AddLastBallRemovedEventListener(listener);
        }
    }

    /// <summary>
    /// last ball removed event listener adding
    /// </summary>
    /// <param name="listener"></param>
    public static void AddLastBallRemovedListener(UnityAction listener)
    {
        lastBallRemovedListeners.Add(listener);
        foreach (HUD script in lastBallRemovedInvokers)
        {
            script.AddLastBallRemovedEventListener(listener);
        }

    }

    /// <summary>
    /// block destroyed event invoker adding
    /// </summary>
    /// <param name="script"></param>
    public static void AddBlockDestroyedInvoker(Block script)
    {
        blockDestroyedInvokers.Add(script);
        foreach (UnityAction<BlockType> listener in blockDestroyedListeners)
        {
            script.AddBlockDestroyedEventListener(listener);
        }
    }

    /// <summary>
    /// block destroyed event listener adding
    /// </summary>
    /// <param name="listener"></param>
    public static void AddBlockDestroyedListener(UnityAction<BlockType> listener)
    {
        blockDestroyedListeners.Add(listener);
        foreach (Block script in blockDestroyedInvokers)
        {
            script.AddBlockDestroyedEventListener(listener);
        }

    }
*/
    #endregion

}
