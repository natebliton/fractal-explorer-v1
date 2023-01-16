using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note 
{
    private int channel;
    private float pitchMIDI;
    private float velocityMIDI;
    private float startTimeTics;
    private float durationTics;
  //  private string target;
    private state noteState;

    private enum state
    {
        stopped,
        playing
    }

/// <summary>
/// 
/// </summary>
/// <param name="channel"></param>
/// <param name="pitchIn"></param>
/// <param name="velocityIn"></param>
/// <param name="startTimeTicsIn"></param>
/// <param name="durationIn"></param>
    public Note(int channelIn, float pitchIn, float velocityIn, float startTimeTicsIn, float durationIn)
    {
        channel = channelIn;
        pitchMIDI = pitchIn;
        velocityMIDI = velocityIn;
        startTimeTics = startTimeTicsIn;
        durationTics = durationIn;
        noteState = state.stopped;
    }
    public int getChannel()
    {
        return channel;
    }

    public float getPitch()
    {
        return pitchMIDI;
    }
    public float getVelocity()
    {
        return velocityMIDI;
    }
    public float getDuration()
    {
        return durationTics;
    }
    public float getStartTime()
    {
        return startTimeTics;
    }
}
