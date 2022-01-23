using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 5;
    float ballLifetime = 20;
    float ballSpawnTimeMin = 5;
    float ballSpawnTimeMax = 10;
    float ballsAvailableTotal = 10;
    float standardProb = 0.7f;
    float bonusProb = 0.2f;
    float freezerProb = 0.05f;
    float speedupProb = 0.05f;
    float standardPoint = 1;
    float bonusPoint = 2;
    float freezerPoint = 5;
    float speedupPoint = 5;
    float freezerDuration = 2;
    float speedupDuration = 2;
    float speedupChange = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the ball lifetime.
    /// </summary>
    /// <value>The ball lifetime.</value>
    public float BallLifetime
    {
        get { return ballLifetime; }
    }

    /// <summary>
    /// Gets the ball spawn time minimum.
    /// </summary>
    /// <value>The ball spawn time minimum.</value>
    public float BallSpawnTimeMin
    {
        get { return ballSpawnTimeMin; }
    }

    /// <summary>
    /// Gets the ball spawn time max.
    /// </summary>
    /// <value>The ball spawn time max.</value>
    public float BallSpawnTimeMax
    {
        get { return ballSpawnTimeMax; }
    }

    /// <summary>
    /// Gets the balls available total.
    /// </summary>
    /// <value>The balls available total.</value>
    public float BallsAvailableTotal
    {
        get { return ballsAvailableTotal; }
    }

    /// <summary>
    /// Gets the standard block probability.
    /// </summary>
    /// <value>The standard block probability.</value>
    public float StandardBlockProbability
    {
        get { return standardProb; }
    }

    /// <summary>
    /// Gets the bonus block probability.
    /// </summary>
    /// <value>The bonus block probability.</value>
    public float BonusBlockProbability
    {
        get { return bonusProb; }
    }

    /// <summary>
    /// Gets the freezer block probability.
    /// </summary>
    /// <value>The freezer block probability.</value>
    public float FreezerBlockProbability
    {
        get { return freezerProb; }
    }

    /// <summary>
    /// Gets the speedup block probability.
    /// </summary>
    /// <value>The speedup block probability.</value>
    public float SpeedupBlockProbability
    {
        get { return speedupProb; }
    }

    /// <summary>
    /// Gets the standard point.
    /// </summary>
    /// <value>The standard point.</value>
    public float StandardPoint
    {
        get { return standardPoint; }
    }

    /// <summary>
    /// Gets the bonus point.
    /// </summary>
    /// <value>The bonus point.</value>
    public float BonusPoint
    {
        get { return bonusPoint; }
    }

    /// <summary>
    /// Gets the freezer point.
    /// </summary>
    /// <value>The freezer point.</value>
    public float FreezerPoint
    {
        get { return freezerPoint; }
    }

    /// <summary>
    /// Gets the speedup point.
    /// </summary>
    /// <value>The speedup point.</value>
    public float SpeedupPoint
    {
        get { return speedupPoint; }
    }

    /// <summary>
    /// Gets the duration of the freezer.
    /// </summary>
    /// <value>The duration of the freezer.</value>
    public float FreezerDuration
    {
        get { return freezerDuration; }
    }

    /// <summary>
    /// Gets the duration of the speedup.
    /// </summary>
    /// <value>The duration of the speedup.</value>
    public float SpeedupDuration
    {
        get { return speedupDuration; }
    }

    /// <summary>
    /// Gets the speedup change.
    /// </summary>
    /// <value>The speedup change.</value>
    public float SpeedupChange
    {
        get { return speedupChange; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // assign the and values
            string[] value = values.Split(',');
            paddleMoveUnitsPerSecond = float.Parse(value[0]);
            ballImpulseForce = float.Parse(value[1]);
            ballLifetime = float.Parse(value[2]);
            ballSpawnTimeMin = float.Parse(value[3]);
            ballSpawnTimeMax = float.Parse(value[4]);
            ballsAvailableTotal = float.Parse(value[5]);
            standardProb = float.Parse(value[6]);
            bonusProb = float.Parse(value[7]);
            freezerProb = float.Parse(value[8]);
            speedupProb = float.Parse(value[9]);
            standardPoint = float.Parse(value[10]);
            bonusPoint = float.Parse(value[11]);
            freezerPoint = float.Parse(value[12]);
            speedupPoint = float.Parse(value[13]);
            freezerDuration = float.Parse(value[14]);
            speedupDuration = float.Parse(value[15]);
            speedupChange = float.Parse(value[16]);

        }

        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
           
        }
    }

    #endregion
}
