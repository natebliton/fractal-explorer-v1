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

    public enum state
    {
        ready,
        playing,
        done
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
        noteState = state.ready;
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

    public state getState() {
        return noteState;
    }

    public void setState(state state)
    {
        noteState = state;
    }

    public void Play()
    {
        noteState = state.playing;
    }
}
