using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region fields

    static ConfigurationData ConfigurationData;

    #endregion


    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return ConfigurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the ball impulse force.
    /// </summary>
    /// <value>The ball impulse force.</value>
    public static float BallImpulseForce
    {
        get { return ConfigurationData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the ball lifetime.
    /// </summary>
    /// <value>The ball lifetime.</value>
    public static float BallLifetime
    {
        get { return ConfigurationData.BallLifetime; }
    }

    /// <summary>
    /// Gets the ball spawn time minimum.
    /// </summary>
    /// <value>The ball spawn time minimum.</value>
    public static float BallSpawnTimeMin
    {
        get { return ConfigurationData.BallSpawnTimeMin; }
    }

    /// <summary>
    /// Gets the ball spawn time max.
    /// </summary>
    /// <value>The ball spawn time max.</value>
    public static float BallSpawnTimeMax
    {
        get { return ConfigurationData.BallSpawnTimeMax; }
    }

    /// <summary>
    /// Gets the balls available total.
    /// </summary>
    /// <value>The balls available total.</value>
    public static float BallsAvailableTotal
    {
        get { return ConfigurationData.BallsAvailableTotal; }
    }

    /// <summary>
    /// Gets the standard block probability.
    /// </summary>
    /// <value>The standard block probability.</value>
    public static float StandardBlockProbability
    {
        get { return ConfigurationData.StandardBlockProbability; }
    }

    /// <summary>
    /// Gets the bonus block probability.
    /// </summary>
    /// <value>The bonus block probability.</value>
    public static float BonusBlockProbability
    {
        get { return ConfigurationData.BonusBlockProbability; }
    }

    /// <summary>
    /// Gets the freezer block probability.
    /// </summary>
    /// <value>The freezer block probability.</value>
    public static float FreezerBlockProbability
    {
        get { return ConfigurationData.FreezerBlockProbability; }
    }

    /// <summary>
    /// Gets the speedup block probability.
    /// </summary>
    /// <value>The speedup block probability.</value>
    public static float SpeedupBlockProbability
    {
        get { return ConfigurationData.SpeedupBlockProbability; }
    }


    /// <summary>
    /// Gets the standard point.
    /// </summary>
    /// <value>The standard point.</value>
    public static float StandardPoint
    {
        get { return ConfigurationData.StandardPoint; }
    }

    /// <summary>
    /// Gets the bonus point.
    /// </summary>
    /// <value>The bonus point.</value>
    public static float BonusPoint
    {
        get { return ConfigurationData.BonusPoint; }
    }

    /// <summary>
    /// Gets the freezer point.
    /// </summary>
    /// <value>The freezer point.</value>
    public static float FreezerPoint
    {
        get { return ConfigurationData.FreezerPoint; }
    }

    /// <summary>
    /// Gets the speedup point.
    /// </summary>
    /// <value>The speedup point.</value>
    public static float SpeedupPoint
    {
        get { return ConfigurationData.SpeedupPoint; }
    }

    /// <summary>
    /// Gets the duration of the freezer.
    /// </summary>
    /// <value>The duration of the freezer.</value>
    public static float FreezerDuration
    {
        get { return ConfigurationData.FreezerDuration; }
    }

    /// <summary>
    /// Gets the duration of the speedup.
    /// </summary>
    /// <value>The duration of the speedup.</value>
    public static float SpeedupDuration
    {
        get { return ConfigurationData.SpeedupDuration; }
    }

    /// <summary>
    /// Gets the speedup change.
    /// </summary>
    /// <value>The speedup change.</value>
    public static float SpeedupChange
    {
        get { return ConfigurationData.SpeedupChange; }
    }

    #endregion


    #region public methods
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        ConfigurationData = new ConfigurationData();
    }

    #endregion
}
