using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequencer1 : MonoBehaviour
{
    [SerializeField]
    private bool playMusic;
    [SerializeField]
    private float tempo;
    private float workingTempo;
    private float ticsPerQuarter = 960;
    private float currentTic = 0;
    private float sequenceDuration;
    //[SerializeField]
    //private TextAsset sequenceTextFile;

    private float ticsPerMS = 1.9f; // at 120bpm
    private float frameRate = 50; // assumed?
    private float loopDurationTics = 15360; // ?

    private List<Note> notes;

    private LibPdInstance libPdInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (tempo > 0)
        {
            ticsPerMS = ticsPerQuarter / (60000 / tempo);
        }
        workingTempo = tempo;
        libPdInstance = GameObject.FindGameObjectWithTag("sound").GetComponent<LibPdInstance>();
        string f = Resources.Load("sequences/output2").ToString();
        notes = ParseSequenceFile(f);
        print("here's the list: ");
        foreach(Note note in notes)
        {
            string toPrint = "note " + note.getPitch();
            print(toPrint);
        }

        currentTic = 0;
    }

    List<Note> ParseSequenceFile(string sequence)
    {
        List<Note> notes = new List<Note>();
        string[] lines = sequence.Split('\n');
        foreach (string line in lines)
        {
            string[] lineContents = line.Split(' ');
            if(lineContents[0] == "note")
            {
                notes.Add(new Note(int.Parse(lineContents[1]), float.Parse(lineContents[2]), float.Parse(lineContents[3]), float.Parse(lineContents[4]), float.Parse(lineContents[5])));
            }
        }
        return notes;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo != workingTempo)
        {
            if (tempo > 0)
            {
                ticsPerMS = ticsPerQuarter / (60000 / tempo);
            }
        }
    }
    // 
    private void FixedUpdate()
    {
        if (playMusic)
        {
            //print("at tic " + currentTic);
            // start counting if we haven't
            foreach (Note note in notes)
            {
                //print("checking note " + note.getStartTime() + " " + note.getState());
                if (note.getState() == Note.state.ready &&
                    note.getStartTime() <= currentTic)
                {
                    print("playing " + note.getPitch() + " at " + note.getStartTime() + " " + currentTic);

                    note.setState(Note.state.playing);
                    string message = "channel" + note.getChannel() + "pitchIn";
                    libPdInstance.SendFloat(message, note.getPitch());

                }
            }
            // if too much time has elapsed, longer than the entire loop, reset timer
            // scan through list of notes, for this channel, if a note hasn't played and needs to, then play it
            currentTic += ticsPerMS * frameRate;
            if (currentTic >= loopDurationTics)
            {
                currentTic = 0;
                foreach (Note note in notes)
                {
                    note.setState(Note.state.ready);
                }
            }
        }
    }

}
