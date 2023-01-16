using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequencer1 : MonoBehaviour
{
    [SerializeField]
    private float tempo = 120;
    private float ticsPerQuarter = 960;
    private float sequenceDuration;
    [SerializeField]
    private TextAsset sequenceTextFile;


    private List<Note> notes;

    // Start is called before the first frame update
    void Start()
    {
        string f = Resources.Load("sequences/output2").ToString();
        notes = ParseSequenceFile(f);
        foreach(Note note in notes)
        {
            string toPrint = "note " + note.getPitch();
            print(toPrint);
        }
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
        
    }

    private void FixedUpdate()
    {
        
    }
}
